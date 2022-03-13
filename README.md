# OptimismTemplate
Simple template to get started example of working with Optimism

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

ADDRESS_MANAGER = "0x100Dd3b414Df5BbA2B542864fF94aF8024aFdf3a";

## Install optimism contracts

RUN at root
```npm install @eth-optimism/contracts```


## Code generation of smart contract definitions
It is already preconfigured to autogenerate your code too :)

## Eth bride L1 <-> L2
```csharp
     //var web3l1 = new Web3(new Account("0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a", 31337), "http://localhost:9545");
            //var web3l2 = new Web3(new Account("0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a", 420), "http://localhost:8545");


            var web3l1 = new Web3(new Account("YOUR PRIVATE KEY", 42), "https://kovan.infura.io/v3/3e2d593aa68042cc8cce973b4b5d23ef");
            var web3l2 = new Web3(new Account("YOUR PRIVATE KEY", 69), "https://kovan.optimism.io");

            var ourAdddress = web3l1.TransactionManager.Account.Address;
            var watcher = new CrossMessagingWatcherService();

            var addressManagerService = new Lib_AddressManagerService(web3l1, KOVAN_ADDRESS_MANAGER);
            var L2CrossDomainMessengerAddress = await addressManagerService.GetAddressQueryAsync("L2CrossDomainMessenger");
            var L1StandardBridgeAddress = await addressManagerService.GetAddressQueryAsync(StandardAddressManagerKeys.L1StandardBridge);
            var L1CrossDomainMessengerAddress = await addressManagerService.GetAddressQueryAsync(StandardAddressManagerKeys.L1CrossDomainMessenger);
            var L2StandardBridgeAddress = PredeployedAddresses.L2StandardBridge;
            
            var l2StandardBridgeService = new L2StandardBridgeService(web3l2, L2StandardBridgeAddress);
            var l1StandardBridgeAddress = await l2StandardBridgeService.L1TokenBridgeQueryAsync();
            var l1StandardBridgeService = new L1StandardBridgeService(web3l1, l1StandardBridgeAddress);
     

            var amount = Web3.Convert.ToWei(0.05);
            var currentBalanceInL2 = await web3l2.Eth.GetBalance.SendRequestAsync(ourAdddress);
            var depositEther = new DepositETHFunction()
            {
                AmountToSend = amount,
                L2Gas = 700000,
                Data = "0x".HexToByteArray()
            };

            var estimateGas = await l1StandardBridgeService.ContractHandler.EstimateGasAsync(depositEther);

            var receiptDeposit = await l1StandardBridgeService.DepositETHRequestAndWaitForReceiptAsync(depositEther);

            var messageHashes = watcher.GetMessageHashes(receiptDeposit);

            var txnReceipt = await watcher.GetCrossMessageMessageTransactionReceipt(web3l2, L2CrossDomainMessengerAddress, messageHashes.First());


            if (txnReceipt.HasErrors() == true)
            {
                var error =
                     await web3l2.Eth.GetContractTransactionErrorReason.SendRequestAsync(txnReceipt.TransactionHash);
                //throw new Exception(error);
            }

            var balancesInL2 = await web3l2.Eth.GetBalance.SendRequestAsync(ourAdddress); ;

            Assert.Equal(amount, balancesInL2.Value - currentBalanceInL2.Value);

            var withdrawEther = new WithdrawFunction()
            {
                L2Token = TokenAddresses.ETH,
                Amount = amount,
                //AmountToSend = amount,
                L1Gas = 700000,
                Data = "0x".HexToByteArray()
            };
            var receiptWidthdraw = await l2StandardBridgeService.WithdrawRequestAndWaitForReceiptAsync(withdrawEther);

            messageHashes = watcher.GetMessageHashes(receiptWidthdraw);

            //txnReceipt = await watcher.GetCrossMessageMessageTransactionReceipt(web3l1, L1CrossDomainMessengerAddress, messageHashes.First());

            //balancesInL2 = await web3l2.Eth.GetBalance.SendRequestAsync(ourAdddress);

            //Assert.Equal(currentBalanceInL2, balancesInL2);

```

## Token bridge L1 <-> L2

```csharp
               var web3l1 = new Web3(new Account("YOUR PRIVATE KEY", 42), "https://kovan.infura.io/v3/3e2d593aa68042cc8cce973b4b5d23ef");
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

```
## NFT sample ERC721
ERC721 in optimism is the same as in mainnet

```csharp
    //This is the same as ERC721 in mainnet
          
            var web3 = new Web3(new Account("YOUR PRIVATE KEY", 69), "https://kovan.optimism.io");
            web3.Eth.TransactionManager.UseLegacyAsDefault = true;

            //creating our deployment information (this includes the bytecode already)
            var erc721Deployment = new ERC721EnumerableUriStorageDeployment() { Name = "Property Registry", Symbol = "PR" };

            //Deploy the erc721Minter
            var deploymentReceipt = await ERC721EnumerableUriStorageService.DeployContractAndWaitForReceiptAsync(web3, erc721Deployment);

            //creating a new service with the new contract address
            var erc721Service = new ERC721EnumerableUriStorageService(web3, deploymentReceipt.ContractAddress);

            //uploading to ipfs our image
            var nftIpfsService = new NFTIpfsService("https://ipfs.infura.io:5001");
            var imageIpfs = await nftIpfsService.AddFileToIpfsAsync("Images/image1.png");
            //adding all our document ipfs links to the metadata and the description
            var metadataNFT = new NftMetadata()
            {
                Name = "Nethereum + Optimism",
                Image = "ipfs://" + imageIpfs.Hash, 
                ExternalUrl = "https://github.com/Nethereum/OptimismTemplate"

            };

            //Adding the metadata to ipfs
            var metadataIpfs =
                await nftIpfsService.AddNftsMetadataToIpfsAsync(metadataNFT, "Metadata.json");

            var addressToRegisterOwnership = "0xe612205919814b1995D861Bdf6C2fE2f20cDBd68";

            //Minting the nft with the url to the ipfs metadata
            var mintReceipt = await erc721Service.MintRequestAndWaitForReceiptAsync(
                addressToRegisterOwnership, "ipfs://" + metadataIpfs.Hash);

            //we have just minted our first nft so the nft will have the id of 0. 
            var ownerOfToken = await erc721Service.OwnerOfQueryAsync(0);

            Assert.True(ownerOfToken.IsTheSameAddress(addressToRegisterOwnership));

            var addressOfToken = await erc721Service.TokenURIQueryAsync(0);

            Assert.Equal("ipfs://" + metadataIpfs.Hash, addressOfToken);

            var ps = new ProcessStartInfo("https://ipfs.infura.io/ipfs/" + imageIpfs.Hash)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);

```
When you run this sample, you will see your browser open the NFT image:

![image](https://user-images.githubusercontent.com/562371/112763780-d8b26580-8ffd-11eb-91a0-b4670d9434d0.png)


## Credits
* The Optimism team! 

## TODO: 
+ Move to Nethereum core =
+ Improve Helper classes 
+ Message tracking (L1 mapping)
+ New simple messaging example
