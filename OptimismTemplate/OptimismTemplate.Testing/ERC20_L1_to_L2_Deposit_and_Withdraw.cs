using System.Linq;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Optimism;
using Optimism.Contracts.L1StandardBridge;
using Optimism.Contracts.L1StandardBridge.ContractDefinition;
using Optimism.Contracts.L2StandardBridge;
using Optimism.Contracts.L2StandardERC20;
using Optimism.Contracts.L2StandardERC20.ContractDefinition;
using Optimism.Contracts.L2StandardTokenFactory.ContractDefinition;
using Optimism.Contracts.Lib_AddressManager;
using OptimismTemplate.Contracts.ERC20;
using OptimismTemplate.Contracts.ERC20.ContractDefinition;

using Xunit;
using TransferEventDTO = OptimismTemplate.Contracts.ERC20.ContractDefinition.TransferEventDTO;
using WithdrawFunction = Optimism.Contracts.L2StandardBridge.ContractDefinition.WithdrawFunction;

namespace OptimismTemplate.Testing
{
    public class ERC20_L1_to_L2_Deposit_and_Withdraw
    {

        
        //This is the addres manager for the local node
        string ADDRESS_MANAGER = "0x3e4CFaa8730092552d9425575E49bB542e329981";
        string KOVAN_ADDRESS_MANAGER = "0x100Dd3b414Df5BbA2B542864fF94aF8024aFdf3a";
        [Fact]
        public async void ShouldBeAbleToDepositErc20AndWithdrawUsingTheGateway()
        {


            var web3l1 = new Web3(new Account("YOUR PRIVATE KEY", 42), "https://kovan.infura.io/v3/<<InfuraId>>");
            var web3l2 = new Web3(new Account("YOUR PRIVATE KEY", 69), "https://kovan.optimism.io");
            web3l2.TransactionManager.UseLegacyAsDefault = true;

            var ourAdddress = web3l1.TransactionManager.Account.Address;
            var watcher = new CrossMessagingWatcherService();

            ////CHAINID 31337
            ////PORT 9454
            //var ourAdddress = "0x023ffdc1530468eb8c8eebc3e38380b5bc19cc5d";
            //var web3l1 = new Web3(new Account("0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a", 31337), "http://localhost:9545");
            //var web3l2 = new Web3(new Account("0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a", 420), "http://localhost:8545");
            
            var addressManagerService = new Lib_AddressManagerService(web3l1, KOVAN_ADDRESS_MANAGER);
            var L2CrossDomainMessengerAddress = await addressManagerService.GetAddressQueryAsync("L2CrossDomainMessenger");
            var L1StandardBridgeAddress = await addressManagerService.GetAddressQueryAsync(StandardAddressManagerKeys.L1StandardBridge);
            var L1CrossDomainMessengerAddress = await addressManagerService.GetAddressQueryAsync(StandardAddressManagerKeys.L1CrossDomainMessenger);

            var L2StandardBridgeAddress = PredeployedAddresses.L2StandardBridge;

            var l2StandardBridgeService = new L2StandardBridgeService(web3l2, L2StandardBridgeAddress);
            var l1StandardBridgeAddress = await l2StandardBridgeService.L1TokenBridgeQueryAsync();
            var l1StandardBridgeService = new L1StandardBridgeService(web3l1, l1StandardBridgeAddress);

            var tokenName = "OPNETH";
            var tokenSymbol = "OPNETH";

            var erc20TokenDeployment = new ERC20Deployment()
                { Name = tokenName, InitialSupply = 100000, Symbol = tokenSymbol, Decimals = 18 };

            //Deploy our custom token
            var tokenDeploymentReceipt = await ERC20Service.DeployContractAndWaitForReceiptAsync(web3l1, erc20TokenDeployment);

            var l2Erc20TokenDeployment = new L2StandardERC20Deployment();
            l2Erc20TokenDeployment.L1Token = tokenDeploymentReceipt.ContractAddress;
            l2Erc20TokenDeployment.L2Bridge = L2StandardBridgeAddress;
            l2Erc20TokenDeployment.Name = tokenName;
            l2Erc20TokenDeployment.Symbol = tokenSymbol;

            var l2Erc20TokenDeploymentReceipt = await L2StandardERC20Service.DeployContractAndWaitForReceiptAsync(web3l2, l2Erc20TokenDeployment);

            var l2StandardErc20Service = new L2StandardERC20Service(web3l2, l2Erc20TokenDeploymentReceipt.ContractAddress);
            //Creating a new service
            var tokenService = new ERC20Service(web3l1, tokenDeploymentReceipt.ContractAddress);
            
            
            
            var balancesInL1 = await tokenService.BalanceOfQueryAsync(ourAdddress);
            var receiptApproval = await tokenService.ApproveRequestAndWaitForReceiptAsync(l1StandardBridgeAddress, 1);
           
            
            var receiptDeposit = await l1StandardBridgeService.DepositERC20RequestAndWaitForReceiptAsync(new DepositERC20Function()
            {
                L1Token = tokenDeploymentReceipt.ContractAddress,
                L2Token = l2Erc20TokenDeploymentReceipt.ContractAddress,
                Amount = 1, L2Gas = 2000000, Data = "0x".HexToByteArray()
            });

            balancesInL1 = await tokenService.BalanceOfQueryAsync(ourAdddress);
            //what the watcher does.. we do already have the txn receipt.. but for demo purpouses
            var messageHashes = watcher.GetMessageHashes(receiptDeposit);

            var txnReceipt = await watcher.GetCrossMessageMessageTransactionReceipt(web3l2, L2CrossDomainMessengerAddress, messageHashes.First());

            var balancesInL2 = await l2StandardErc20Service.BalanceOfQueryAsync(ourAdddress);

            Assert.Equal(1, balancesInL2);

            var withdrawErc20Token = new WithdrawFunction()
            {
                L2Token = l2Erc20TokenDeploymentReceipt.ContractAddress,
                Amount = 1,
                L1Gas = 2000000,
                Data = "0x".HexToByteArray()
            };

            var receiptWidthdraw = await l2StandardBridgeService.WithdrawRequestAndWaitForReceiptAsync(withdrawErc20Token);

             messageHashes = watcher.GetMessageHashes(receiptWidthdraw);

             balancesInL2 = await l2StandardErc20Service.BalanceOfQueryAsync(ourAdddress);

             Assert.Equal(0, balancesInL2);

            //txnReceipt = await watcher.GetCrossMessageMessageTransactionReceipt(web3l1, L1CrossDomainMessengerAddress, messageHashes.First());


        }

    }
}
