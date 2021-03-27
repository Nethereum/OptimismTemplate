using Nethereum.Contracts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using OptimismTemplate.Contracts.SimpleStorage;
using OptimismTemplate.Contracts.SimpleStorage.ContractDefinition;
using OptimismTemplate.Contracts.SimpleStorageL2;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Optimism;
using Optimism.Contracts.Libraries.Resolver.Lib_AddressManager;
using Optimism.Contracts.OVM.Bridge.Messaging.OVM_L1CrossDomainMessenger;
using Optimism.Contracts.OVM.Bridge.Messaging.OVM_L2CrossDomainMessenger;
using Optimism.Contracts.OVM.Bridge.Messaging.OVM_L2CrossDomainMessenger.ContractDefinition;
using Optimism.Contracts.OVM.Bridge.Tokens.OVM_L1ETHGateway;
using Optimism.Contracts.OVM.Predeploys.OVM_ETH;
using Xunit;

namespace OptimismTemplate.Testing
{
    public class StorageCrossPlatformTests
    {
        //This is the addres manager for the local node
        string ADDRESS_MANAGER = "0x3e4CFaa8730092552d9425575E49bB542e329981";

        [Fact]
        public async void ShouldSetStorageXPlatform()
        {
            var web3l1 = new Web3(new Account("0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a", 31337), "http://localhost:9545");
            var web3l2 = new Web3(new Account("0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a", 420), "http://localhost:8545");
            var watcher = new CrossMessagingWatcherService();
            //var web3l1 = new Web3(new Account("", 42), "https://kovan.infura.io/v3/7238211010344719ad14a89db874158c");
            //var web3l2 = new Web3(new Account("", 69), "https://kovan.optimism.io");
            //ADDRESS_MANAGER = "0x72e6F5244828C10737cbC9659378B207246D26B2";

            var addressManagerService = new Lib_AddressManagerService(web3l1, ADDRESS_MANAGER);
            var OVM_L2CrossDomainMessenger = await addressManagerService.GetAddressQueryAsync("OVM_L2CrossDomainMessenger");
            var Proxy__OVM_L1CrossDomainMessenger = await addressManagerService.GetAddressQueryAsync("Proxy__OVM_L1CrossDomainMessenger");

            var storageServiceL1 = await SimpleStorageService.DeployContractAndGetServiceAsync(web3l1, new Contracts.SimpleStorage.ContractDefinition.SimpleStorageDeployment());
            var storageServiceL2 = await SimpleStorageL2Service.DeployContractAndGetServiceAsync(web3l2, new Contracts.SimpleStorageL2.ContractDefinition.SimpleStorageL2Deployment());

            //from l2 to l1

            var l2CrossDomainMessengerService = new OVM_L2CrossDomainMessengerService(web3l2, OVM_L2CrossDomainMessenger);
            var message = new SendMessageFunction()
            {
                Message = new SetValueFunction() { NewValue = "3e4cfaa8730092552d9425575e49bb542e329981000000000000000000000000".HexToByteArray() }.GetCallData(),
                Target = storageServiceL1.ContractHandler.ContractAddress,
                GasLimit = 7000000
            };

            var messageTransactionReceipt = await l2CrossDomainMessengerService.SendMessageRequestAndWaitForReceiptAsync(message);

            var messageHashes = watcher.GetMessageHashes(messageTransactionReceipt);

            var receiptMessageSent = await watcher.GetCrossMessageMessageTransactionReceipt(web3l1, Proxy__OVM_L1CrossDomainMessenger, messageHashes.First());

            var value = await storageServiceL1.ValueQueryAsync();

            Assert.Equal("3e4cfaa8730092552d9425575e49bb542e329981000000000000000000000000", value.ToHex());

            //from l1 to l2

            var l1CrossDomainMessengerService = new OVM_L1CrossDomainMessengerService(web3l1, Proxy__OVM_L1CrossDomainMessenger);
            var messageL1 = new Optimism.Contracts.OVM.Bridge.Messaging.OVM_L1CrossDomainMessenger.ContractDefinition.SendMessageFunction()
            {
                Message = new SetValueFunction() { NewValue = "3e4cfaa8730092552d9425575e49bb542e329982000000000000000000000000".HexToByteArray() }.GetCallData(),
                Target = storageServiceL2.ContractHandler.ContractAddress,
                GasLimit = 7000000
            };

            var messageL1TransactionReceipt = await l1CrossDomainMessengerService.SendMessageRequestAndWaitForReceiptAsync(messageL1);

            messageHashes = watcher.GetMessageHashes(messageL1TransactionReceipt);

            receiptMessageSent = await watcher.GetCrossMessageMessageTransactionReceipt(web3l2, OVM_L2CrossDomainMessenger, messageHashes.First());

            value = await storageServiceL2.ValueQueryAsync();

            Assert.Equal("3e4cfaa8730092552d9425575e49bb542e329982000000000000000000000000", value.ToHex());


        }
    }
}
