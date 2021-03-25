using System.Numerics;
using Nethereum.Signer;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Xunit;
using OptimismTemplate.Contracts.ERC20;
using Nethereum.Web3;
using OptimismTemplate.Contracts.ERC20.ContractDefinition;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using Nethereum.BlockchainProcessing.ProgressRepositories;
using OptimismTemplate.Contracts.L2DepositedERC20.ContractDefinition;
using OptimismTemplate.Contracts.L2DepositedERC20;
using TransferEventDTO = OptimismTemplate.Contracts.ERC20.ContractDefinition.TransferEventDTO;
using OptimismTemplate.Contracts.L1ERC20Gateway.ContractDefinition;
using OptimismTemplate.Contracts.L1ERC20Gateway;
using System.Runtime.InteropServices;
using OptimismTemplate.Contracts.OVM_L1CrossDomainMessenger.ContractDefinition;
using Nethereum.Hex.HexConvertors.Extensions;
using System.Linq;
using OptimismTemplate.Contracts.AddressManager;
using OptimismTemplate.Contracts.SimpleStorage;
using OptimismTemplate.Contracts.SimpleStorageL2;
using OptimismTemplate.Contracts.OVM_L2CrossDomainMessenger;
using OptimismTemplate.Contracts.SimpleStorage.ContractDefinition;
using OptimismTemplate.Contracts.OVM_L1CrossDomainMessenger;

namespace OptimismTemplate.Testing
{

    public class Erc20TokenTests
    {
        public Erc20TokenTests()
        {

        }

        /*
| Accounts
| ========
| Account #0: 0x023ffdc1530468eb8c8eebc3e38380b5bc19cc5d (10000 ETH)
| Private Key: 0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a
|
| Account #1: 0x0e0e05cf14349469ee3b45dc2fce50e11b9449b8 (10000 ETH)
| Private Key: 0xd2ab07f7c10ac88d5f86f1b4c1035d5195e81f27dbe62ad65e59cbf88205629b
|
| Account #2: 0x432c38a44381668eda4a3152209abbfae065b44d (10000 ETH)
| Private Key: 0x23d9aeeaa08ab710a57972eb56fc711d9ab13afdecc92c89586e0150bfa380a6
|
| Account #3: 0x5eeabfdd0f31cebf32f8abf22da451fe46eac131 (10000 ETH)
| Private Key: 0x5b1c2653250e5c580dcb4e51c2944455e144c57ebd6a0645bd359d2e69ca0f0c
|
| Account #4: 0x640e7cc27b750144ed08ba09515f3416a988b6a3 (10000 ETH)
| Private Key: 0xea8b000efb33c49d819e8d6452f681eed55cdf7de47d655887fc0e318906f2e7
|
| Account #5: 0xa687c8fdf7025bbe7f195b3a1c7cc94031e76020 (10000 ETH)
| Private Key: 0x33ffe6a4233e1797557a8231e7be573ff7c46cd60f66632088141e111be5ab03
|
| Account #6: 0xb0dd88dfcc929a78fec13daa1bd77843e267c729 (10000 ETH)
| Private Key: 0xce2b97944c381b369135a9b5f58481e288627e23f963692a03e1464490316d99
|
| Account #7: 0xd4e5e29f63655d756060aaeaa24beae76df52837 (10000 ETH)
| Private Key: 0xd646b23c678dff961e84bf934a0481ca4e9faf9f69578580648f7f18d701a9cb


deployer_1              |   "AddressManager": "0x3e4CFaa8730092552d9425575E49bB542e329981",
deployer_1              |   "OVM_Sequencer": "0x0E0E05Cf14349469ee3B45dc2fcE50E11B9449B8",
deployer_1              |   "Deployer": "0x023fFdC1530468eb8c8EEbC3e38380b5bc19Cc5d",
deployer_1              |   "OVM_L2CrossDomainMessenger": "0x3C67B82D67B4f31A54C0A516dE8d3e93D010EDb3",
deployer_1              |   "OVM_L1CrossDomainMessenger": "0xE08570AF306057221ed7F377a10009a111396748",
deployer_1              |   "Proxy__OVM_L1CrossDomainMessenger": "0x6418E5Da52A3d7543d393ADD3Fa98B0795d27736",
deployer_1              |   "OVM_L1ETHGateway": "0x9934FC453d11334e6bFbE5D3856A2c0E917D26f1",
deployer_1              |   "OVM_L1MultiMessageRelayer": "0x6F239103bD7d869FE983215B009A3544C9640b60",
deployer_1              |   "OVM_CanonicalTransactionChain": "0x16Af4Db6548234c6463Ad6F0cf355260E96E741b",
deployer_1              |   "OVM_StateCommitmentChain": "0x5736b4030Dc0A2aEC72c42C5f1b937E8CAFe46CE",
deployer_1              |   "OVM_DeployerWhitelist": "0xa45cE0Ea52b81c2e578A70f8417f066B6903b5E7",
deployer_1              |   "OVM_L1MessageSender": "0xcdB44B1EC9F2aDd7740EeAc4701c928B80727469",
deployer_1              |   "OVM_L2ToL1MessagePasser": "0x5bD12f0B56C8973ac98446435E07Df8311Aa362c",
deployer_1              |   "OVM_SafetyChecker": "0xA6404B184Ad3f6F41b6472f02ba45f25C6A66d49",
deployer_1              |   "OVM_ExecutionManager": "0xcF76fd262F9105a69A2AFe66aE11fc6930A267e7",
deployer_1              |   "OVM_StateManager": "0xeB4cbbCE5B52ca1b167898dac418da2C68ca9c01",
deployer_1              |   "OVM_StateManagerFactory": "0x50Ec78369D8C391b1e8e636680f5B240921408B7",
deployer_1              |   "OVM_FraudVerifier": "0x7C9b37e50Ea69eB033216A3dce5e758Af086c2b4",
deployer_1              |   "OVM_StateTransitionerFactory": "0x16aB7a77057AaF5ac5dAC5Fc8CC1F19A89F20d33",
deployer_1              |   "OVM_ECDSAContractAccount": "0xB0DA7F0a2F77C49e874FAB35533537c978A661E8",
deployer_1              |   "OVM_SequencerEntrypoint": "0xDf168CE974F7348684ab19417a52b9a14EfAbCba",
deployer_1              |   "OVM_ProxySequencerEntrypoint": "0xEFA3B6C1203ED5fF8f4E1f6F7A09dCe529Fb9EbF",
deployer_1              |   "mockOVM_ECDSAContractAccount": "0x4F53A01556Dc6f120db9a1b4caE786D5f0b5792C",
deployer_1              |   "OVM_BondManager": "0x5e57c76f679B235E5D62C42D8EdC07510FF4548f",
deployer_1              |   "OVM_ETH": "0x60ba97F7cE0CD19Df71bAd0C3BE9400541f6548E",
deployer_1              |   "OVM_ChainStorageContainer:CTC:batches": "0x6353d6c697cc36446EC727Ae032B518b7FbEc82d",
deployer_1              |   "OVM_ChainStorageContainer:CTC:queue": "0x6C024eeE101AdB6b5d211947fD4B7f6182042978",
deployer_1              |   "OVM_ChainStorageContainer:SCC:batches": "0xcD46d1D296466e7F2842A718576d49576fe76a9f",
deployer_1              |   "ERC1820Registry": "0xB3FdF320A0bb4b9eBedf4726F0C9Bf49D1268cf9"



        //l1local "http://localhost:9545", chainId: 31337 
        //l2Local: "http://localhost:9545", chainId: 420 
        //l2Kovan: "https://kovan.optimism.io", chainId: 69 

        //string L2_CROSS_DOMAIN_MESSENGER_ADDRESS = "0x4200000000000000000000000000000000000007";
        //string L1_MESSENGER = "0x6418E5Da52A3d7543d393ADD3Fa98B0795d27736";
        */

        string ADDRESS_MANAGER = "0x3e4CFaa8730092552d9425575E49bB542e329981";

        [Fact]
        public async void ShouldSetStorageXPlatform()
        {
            var web3l1 = new Web3(new Account("0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a", 31337), "http://localhost:9545");
            var web3l2 = new Web3(new Account("0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a", 420), "http://localhost:8545");

            var addressManagerService = new AddressManagerService(web3l1, ADDRESS_MANAGER);
            var OVM_L2CrossDomainMessenger = await addressManagerService.GetAddressQueryAsync("OVM_L2CrossDomainMessenger");
            var Proxy__OVM_L1CrossDomainMessenger = await addressManagerService.GetAddressQueryAsync("Proxy__OVM_L1CrossDomainMessenger");

            var storageServiceL1 = await SimpleStorageService.DeployContractAndGetServiceAsync(web3l1, new Contracts.SimpleStorage.ContractDefinition.SimpleStorageDeployment());
            var storageServiceL2 = await SimpleStorageL2Service.DeployContractAndGetServiceAsync(web3l2, new Contracts.SimpleStorageL2.ContractDefinition.SimpleStorageL2Deployment());

            //from l2 to l1

            var l2CrossDomainMessengerService = new OVM_L2CrossDomainMessengerService(web3l2, OVM_L2CrossDomainMessenger);
            var message = new Contracts.OVM_L2CrossDomainMessenger.ContractDefinition.SendMessageFunction()
            {
                Message = new SetValueFunction() { NewValue = "3e4cfaa8730092552d9425575e49bb542e329981000000000000000000000000".HexToByteArray() }.GetCallData(),
                Target = storageServiceL1.ContractHandler.ContractAddress,
                GasLimit = 7000000
            };

            var messageTransactionReceipt = await l2CrossDomainMessengerService.SendMessageRequestAndWaitForReceiptAsync(message);

            var messageHashes = GetMessageHashes(messageTransactionReceipt);

            var receiptMessageSent = await GetMessageTransactionReceipt(web3l1, Proxy__OVM_L1CrossDomainMessenger, messageHashes.First());

            var value = await storageServiceL1.ValueQueryAsync();

            Assert.Equal("3e4cfaa8730092552d9425575e49bb542e329981000000000000000000000000", value.ToHex());

            //from l1 to l2

            var l1CrossDomainMessengerService = new OVM_L1CrossDomainMessengerService(web3l1, Proxy__OVM_L1CrossDomainMessenger);
            var messagel1 = new Contracts.OVM_L1CrossDomainMessenger.ContractDefinition.SendMessageFunction()
            {
                Message = new SetValueFunction() { NewValue = "3e4cfaa8730092552d9425575e49bb542e329982000000000000000000000000".HexToByteArray() }.GetCallData(),
                Target = storageServiceL2.ContractHandler.ContractAddress,
                GasLimit = 7000000
            };

            var messagel1TransactionReceipt = await l1CrossDomainMessengerService.SendMessageRequestAndWaitForReceiptAsync(messagel1);

            messageHashes = GetMessageHashes(messagel1TransactionReceipt);

            receiptMessageSent = await GetMessageTransactionReceipt(web3l2, OVM_L2CrossDomainMessenger, messageHashes.First());

            value = await storageServiceL2.ValueQueryAsync();

            Assert.Equal("3e4cfaa8730092552d9425575e49bb542e329982000000000000000000000000", value.ToHex());


        }

        [Fact]
        public async void ShouldTransferToken()
        {

            //CHAINID 31337
            //PORT 9454
            var ourAdddress = "0x023ffdc1530468eb8c8eebc3e38380b5bc19cc5d";
            var web3l1 = new Web3(new Account("0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a", 31337), "http://localhost:9545");
            var web3l2 = new Web3(new Account("0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a", 420), "http://localhost:8545");

            //var web3l1 = new Web3(new Account("xx", 42), "https://kovan.infura.io/v3/7238211010344719ad14a89db874158c");
            //var web3l2 = new Web3(new Account("xx", 69), "https://kovan.optimism.io");
           // ADDRESS_MANAGER = "0x72e6F5244828C10737cbC9659378B207246D26B2";
            var addressManagerService = new AddressManagerService(web3l1, ADDRESS_MANAGER);
            var OVM_L2CrossDomainMessenger = await addressManagerService.GetAddressQueryAsync("OVM_L2CrossDomainMessenger");
            var Proxy__OVM_L1CrossDomainMessenger = await addressManagerService.GetAddressQueryAsync("Proxy__OVM_L1CrossDomainMessenger");


            var tokenName = "OPNETH";
            var tokenSymbol = "OPNETH";

            var erc20TokenDeployment = new ERC20Deployment() { Name = tokenName, InitialSupply = Web3.Convert.ToWei(1000000000000000000), Symbol = tokenSymbol, Decimals = 18};

            //Deploy our custom token
            var tokenDeploymentReceipt = await ERC20Service.DeployContractAndWaitForReceiptAsync(web3l1, erc20TokenDeployment);

            //Deploy our ERC20 contract deployed
            var ovmL2DepositedERC20 = new L2DepositedERC20Deployment() { L2CrossDomainMessenger = OVM_L2CrossDomainMessenger, Name = tokenName, Symbol = tokenSymbol, Decimals = 18 };

            var ovmL2DepositedERC20Receipt = await L2DepositedERC20Service.DeployContractAndWaitForReceiptAsync(web3l2, ovmL2DepositedERC20);

            var ovmL1ERC20Gateway = new L1ERC20GatewayDeployment() { L2DepositedERC20 = ovmL2DepositedERC20Receipt.ContractAddress, L1ERC20 = tokenDeploymentReceipt.ContractAddress, L1messenger = Proxy__OVM_L1CrossDomainMessenger };

            var ovmL1ERC20GatewayReceipt = await L1ERC20GatewayService.DeployContractAndWaitForReceiptAsync(web3l1, ovmL1ERC20Gateway);



            //Creating a new service
            var tokenService = new ERC20Service(web3l1, tokenDeploymentReceipt.ContractAddress);

            var gatewayService = new L1ERC20GatewayService(web3l1, ovmL1ERC20GatewayReceipt.ContractAddress);
            var l2DepositedService = new L2DepositedERC20Service(web3l2, ovmL2DepositedERC20Receipt.ContractAddress);

            var balancesInL1 = await tokenService.BalanceOfQueryAsync(ourAdddress);
            var receiptApproval = await tokenService.ApproveRequestAndWaitForReceiptAsync(gatewayService.ContractHandler.ContractAddress, 100000);
            var receiptDeposit = await gatewayService.DepositRequestAndWaitForReceiptAsync(new DepositFunction() { Amount = 100000, Gas= 8000000 });

            balancesInL1 = await tokenService.BalanceOfQueryAsync(ourAdddress);
            //what the watcher does.. we do already have the txn receipt.. but for demo purpouses
            var messageHashes = GetMessageHashes(receiptDeposit);

            var txnReceipt = await GetMessageTransactionReceipt(web3l2, OVM_L2CrossDomainMessenger, messageHashes.First());

            var balancesInL2 = await l2DepositedService.BalanceOfQueryAsync(ourAdddress);



        }

        public async Task<List<byte[]>> GetMessageHashes(Web3 web3, string txnHash)
        {
            var txnReceipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(txnHash);
            return GetMessageHashes(txnReceipt);
        }

        public List<byte[]> GetMessageHashes(TransactionReceipt receipt)
        {

            var sentMessagesEvents = receipt.DecodeAllEvents<SentMessageEventDTO>();
            var sentMessages = new List<byte[]>();
            foreach (var sentMessageEvent in sentMessagesEvents)
            {
                sentMessages.Add(Sha3Keccack.Current.CalculateHash(sentMessageEvent.Event.Message));
            }
            return sentMessages;
        }

        public async Task<TransactionReceipt> GetMessageTransactionReceipt(Web3 web3, string messengerAddress, byte[] msgHash)
        {
            //this needs a time out cancellation process.
            var blockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
            var startingBlock = BigInteger.Max(blockNumber.Value - 1000000, 0);
            var eventRelayedMessage = web3.Eth.GetEvent<RelayedMessageEventDTO>(messengerAddress);
            var filterInput = eventRelayedMessage.CreateFilterInput(new BlockParameter((ulong)startingBlock), BlockParameter.CreateLatest());

            var logs = await eventRelayedMessage.GetAllChanges(filterInput);
            var logsFiltered = logs.Where(x => x.Event.MsgHash.ToHex() == msgHash.ToHex());
            while (logsFiltered.Count() == 0)
            {
                Thread.Sleep(1000);
                logs = await eventRelayedMessage.GetAllChanges(filterInput);
                logsFiltered = logs.Where(x => x.Event.MsgHash.ToHex() == msgHash.ToHex());
            }

            return await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(logsFiltered.First().Log.TransactionHash);
        }


    }
}
