using Nethereum.Contracts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using OptimismTemplate.Contracts.SimpleStorage;
using OptimismTemplate.Contracts.SimpleStorage.ContractDefinition;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Optimism;
using Optimism.Contracts.L1CrossDomainMessenger;
using Optimism.Contracts.L2CrossDomainMessenger;
using Optimism.Contracts.L2CrossDomainMessenger.ContractDefinition;
using Optimism.Contracts.Lib_AddressManager;

using Xunit;

namespace OptimismTemplate.Testing
{
    public class StorageCrossPlatformTests
    {
        //This is the addres manager for the local node
        string ADDRESS_MANAGER = "0x3e4CFaa8730092552d9425575E49bB542e329981";
        string KOVAN_ADDRESS_MANAGER = "0x100Dd3b414Df5BbA2B542864fF94aF8024aFdf3a";

        [Fact]
        public async void ShouldSetStorageXPlatform()
        {
            //var web3l1 = new Web3(new Account("YOUR PRIVATE KEY", 42), "https://kovan.infura.io/v3/<<InfuraId>>");
            //var web3l2 = new Web3(new Account("YOUR PRIVATE KEY", 69), "https://kovan.optimism.io");
            //web3l2.TransactionManager.UseLegacyAsDefault = true;
            //var watcher = new CrossMessagingWatcherService();

            //var addressManagerService = new Lib_AddressManagerService(web3l1, KOVAN_ADDRESS_MANAGER);
            //var L2CrossDomainMessengerAddress = await addressManagerService.GetAddressQueryAsync("L2CrossDomainMessenger");
            //var L1StandardBridgeAddress = await addressManagerService.GetAddressQueryAsync(StandardAddressManagerKeys.L1StandardBridge);
            //var L1CrossDomainMessengerAddress = await addressManagerService.GetAddressQueryAsync(StandardAddressManagerKeys.L1CrossDomainMessenger);

            //var storageServiceL1 = await SimpleStorageService.DeployContractAndGetServiceAsync(web3l1, new Contracts.SimpleStorage.ContractDefinition.SimpleStorageDeployment(){CrossDomainMessenger = L1CrossDomainMessengerAddress});
            //var storageServiceL2 = await SimpleStorageService.DeployContractAndGetServiceAsync(web3l2, new Contracts.SimpleStorage.ContractDefinition.SimpleStorageDeployment(){CrossDomainMessenger = L2CrossDomainMessengerAddress});

            ////from l1 to l2

            ////var l1CrossDomainMessengerService = new L1CrossDomainMessengerService(web3l1, L1CrossDomainMessengerAddress);
            //var messageL1 = new SendValueFunction()
            //{
            //    Message = new SetValueFunction() { NewValue = "3e4cfaa8730092552d9425575e49bb542e329982000000000000000000000000".HexToByteArray() }.GetCallData(),
            //    CrossDomainTarget = storageServiceL2.ContractHandler.ContractAddress,
            //    GasLimit = 7000000
            //};

            //var messageL1TransactionReceipt = await storageServiceL1.SendValueRequestAndWaitForReceiptAsync(messageL1);

            //var messageHashes = watcher.GetMessageHashes(messageL1TransactionReceipt);

            //var receiptMessageSent = await watcher.GetCrossMessageMessageTransactionReceipt(web3l2, L2CrossDomainMessengerAddress, messageHashes.First());

            //var value = await storageServiceL2.ValueQueryAsync();

            //Assert.Equal("3e4cfaa8730092552d9425575e49bb542e329982000000000000000000000000", value.ToHex());

            //from l2 to l1

            //var l2CrossDomainMessengerService = new L2CrossDomainMessengerService(web3l2, L2CrossDomainMessengerAddress);
            //var message = new SendMessageFunction()
            //{
            //    Message = new SetValueFunction() { NewValue = "3e4cfaa8730092552d9425575e49bb542e329981000000000000000000000000".HexToByteArray() }.GetCallData(),
            //    Target = storageServiceL1.ContractHandler.ContractAddress,
            //    GasLimit = 7000000
            //};

            //var messageTransactionReceipt = await l2CrossDomainMessengerService.SendMessageRequestAndWaitForReceiptAsync(message);

            // messageHashes = watcher.GetMessageHashes(messageTransactionReceipt);

            // receiptMessageSent = await watcher.GetCrossMessageMessageTransactionReceipt(web3l1, L1CrossDomainMessengerAddress, messageHashes.First());

            // value = await storageServiceL1.ValueQueryAsync();

            //Assert.Equal("3e4cfaa8730092552d9425575e49bb542e329981000000000000000000000000", value.ToHex());


        }
    }
}
