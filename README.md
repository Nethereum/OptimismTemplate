# OptimismTemplate
Simple template to get started working with Optimism

NOTE: WIP

## SETUP Local Environment
The first thing is to setup your enviroment to run your local l1 and l2 chains
Your will need docker, and if you are using windows you can run this in WSL2 too.
1. Clone https://github.com/ethereum-optimism/optimism-integration
2. run ```docker-compose pull```
3. then ```make up```

The address manager provides a way to retrieve all the addresses

ADDRESS_MANAGER = "0x3e4CFaa8730092552d9425575E49bB542e329981"

The test accounts in L1 can be found here:

https://github.com/Nethereum/OptimismTemplate/blob/main/OptimismTemplate.Testing/Erc20TokenTests.cs

L1: "http://localhost:9545", CHAINID: 31337 
L2: "http://localhost:8545", CHAINID: 420 

## SETUP Kovan Environment
You will need some KETH (eth) from Kovan.
1. L1 https://kovan.infura.io/v3/7238211010344719ad14a89db874158c CHAINID 42
2. L2 https://kovan.optimism.io CHAINID 69

The address manager provides a way to retrieve all the addresses:

ADDRESS_MANAGER = "0x72e6F5244828C10737cbC9659378B207246D26B2";

## Install optimism contracts and solc

RUN at root
```npm install @eth-optimism/contracts```
```npm install @eth-optimism/solc```

## COMPILING in Visual Studio code

If you open your environment with visual studio code, it is already configured to compile your ovm contracts with "eth-optimism\solc"
![image](https://user-images.githubusercontent.com/562371/112538411-c0490d80-8da7-11eb-9a3e-01248da54623.png)
For L1 EVM smart contracts just press F5

## Code generation of smart contract definitions
It is already preconfigured to autogenerate your code too :)

## Cross messaging example L1 to L2 and L2 to L1

This uses the SimpleStorage.sol smart contract here https://github.com/Nethereum/OptimismTemplate/blob/main/contracts/SimpleStorage.sol

```csharp
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
```

## Token bridge L1 to L2

```csharp
            var ourAdddress = "0x023ffdc1530468eb8c8eebc3e38380b5bc19cc5d";
            var web3l1 = new Web3(new Account("0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a", 31337), "http://localhost:9545");
            var web3l2 = new Web3(new Account("0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a", 420), "http://localhost:8545");
 
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
            //don't forget to init the l2DepositService
            await l2DepositedService.InitRequestAndWaitForReceiptAsync(ovmL1ERC20GatewayReceipt.ContractAddress);
            
            var balancesInL1 = await tokenService.BalanceOfQueryAsync(ourAdddress);
            var receiptApproval = await tokenService.ApproveRequestAndWaitForReceiptAsync(gatewayService.ContractHandler.ContractAddress, 100000);
            var receiptDeposit = await gatewayService.DepositRequestAndWaitForReceiptAsync(new DepositFunction() { Amount = 100000, Gas= 8000000 });

            balancesInL1 = await tokenService.BalanceOfQueryAsync(ourAdddress);
            //what the watcher does.. we do already have the txn receipt.. but for demo purpouses
            var messageHashes = GetMessageHashes(receiptDeposit);

            var txnReceipt = await GetMessageTransactionReceipt(web3l2, OVM_L2CrossDomainMessenger, messageHashes.First());

            var balancesInL2 = await l2DepositedService.BalanceOfQueryAsync(ourAdddress);

```

## Credits
* The Optimism team! All based on the tutorials here https://github.com/ethereum-optimism/optimism-tutorial
and integration tests https://github.com/ethereum-optimism/integration-tests/tree/master/contracts
