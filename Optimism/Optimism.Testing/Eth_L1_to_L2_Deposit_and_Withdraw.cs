using System;
using Nethereum.Contracts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Optimism.Contracts.Libraries.Resolver.Lib_AddressManager;
using Optimism.Contracts.OVM.Bridge.Messaging.OVM_L1CrossDomainMessenger.ContractDefinition;
using Optimism.Contracts.OVM.Bridge.Tokens.OVM_L1ETHGateway;
using Optimism.Contracts.OVM.Bridge.Tokens.OVM_L1ETHGateway.ContractDefinition;
using Optimism.Contracts.OVM.Predeploys.OVM_ETH;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Optimism.Testing
{

    public class Eth_L1_to_L2_Deposit_and_Withdraw
    {

        //This is the addres manager for the local node
        string ADDRESS_MANAGER = "0x3e4CFaa8730092552d9425575E49bB542e329981";

        [Fact]
        public async void ShouldBeAbleToDepositEtherAndWithdrawUsingTheGateway()
        {
            var ourAdddress = "0x023ffdc1530468eb8c8eebc3e38380b5bc19cc5d";
            var web3l1 = new Web3(new Account("0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a", 31337), "http://localhost:9545");
            var web3l2 = new Web3(new Account("0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a", 420), "http://localhost:8545");
            var watcher = new CrossMessagingWatcherService();

            var addressManagerService = new Lib_AddressManagerService(web3l1, ADDRESS_MANAGER);

            var OVM_L2CrossDomainMessenger = await addressManagerService.GetAddressQueryAsync("OVM_L2CrossDomainMessenger");
            var Proxy__OVM_L1CrossDomainMessenger = await addressManagerService.GetAddressQueryAsync("Proxy__OVM_L1CrossDomainMessenger");
            var OVM_L1ETHGateway_Address = await addressManagerService.GetAddressQueryAsync("OVM_L1ETHGateway");
            var OVM_ETH_Address = await addressManagerService.GetAddressQueryAsync("OVM_ETH");
            OVM_ETH_Address = "0x4200000000000000000000000000000000000006"; // <-- This the token you are looking for

            var gatewayL1EthService = new OVM_L1ETHGatewayService(web3l1, OVM_L1ETHGateway_Address);
            var ovmEthAdress = await gatewayL1EthService.OvmEthQueryAsync();

            var ovmWEthTokenDepositedService = new OVM_ETHService(web3l2, OVM_ETH_Address);
            var ovml1tokenGateway = await ovmWEthTokenDepositedService.L1TokenGatewayQueryAsync();
            var ovmEthMessenger = await ovmWEthTokenDepositedService.MessengerQueryAsync();

            var amount = Web3.Convert.ToWei(1);
            var currentBalanceInL2 = await ovmWEthTokenDepositedService.BalanceOfQueryAsync(ourAdddress);
            var depositEther = new DepositFunction()
            {
                AmountToSend = amount,
                Gas = 700000
            };

            var receiptDeposit = await gatewayL1EthService.DepositRequestAndWaitForReceiptAsync(depositEther);

            var messageHashes = watcher.GetMessageHashes(receiptDeposit);

            var txnReceipt = await watcher.GetCrossMessageMessageTransactionReceipt(web3l2, OVM_L2CrossDomainMessenger, messageHashes.First());
           

            //if (txnReceipt.HasErrors() == true)
            //{
               var error =
                    await web3l2.Eth.GetContractTransactionErrorReason.SendRequestAsync(txnReceipt.TransactionHash);
                //throw new Exception(error);
            //}

            var balancesInL2 = await ovmWEthTokenDepositedService.BalanceOfQueryAsync(ourAdddress);

            Assert.Equal(amount, balancesInL2 - currentBalanceInL2);

            var receiptWidthdraw = await ovmWEthTokenDepositedService.WithdrawRequestAndWaitForReceiptAsync(amount);

            messageHashes = watcher.GetMessageHashes(receiptWidthdraw);

            txnReceipt = await watcher.GetCrossMessageMessageTransactionReceipt(web3l1, Proxy__OVM_L1CrossDomainMessenger, messageHashes.First());

            balancesInL2 = await ovmWEthTokenDepositedService.BalanceOfQueryAsync(ourAdddress);

            Assert.Equal(currentBalanceInL2, balancesInL2);
        }

    }
}
