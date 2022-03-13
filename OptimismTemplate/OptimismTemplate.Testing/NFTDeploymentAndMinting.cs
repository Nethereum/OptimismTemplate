using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ERC721ContractLibrary.Testing;
using Ipfs;
using Ipfs.Http;
using Nethereum.Contracts;
using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Newtonsoft.Json;
using OptimismTemplate.Contracts.ERC721EnumerableUriStorage;
using OptimismTemplate.Contracts.ERC721EnumerableUriStorage.ContractDefinition;

using Xunit;

namespace OptimismTemplate.Testing
{
    public class NFTDeploymentAndMinting
    {
        
        [Fact]
        public async void ShouldDeployContractCreateNftMetadataUploadToIpfsAndMint()
        {
            //This is the same as ERC721 in mainnet
          
            var web3 = new Web3(new Account("YOUR PRIVATE KEY", 69), "https://kovan.optimism.io");
            web3.Eth.TransactionManager.UseLegacyAsDefault = true;

            //creating our deployment information (this includes the bytecode already)
            //This example creates an NFT Property (Real state) registry
            var erc721Deployment = new ERC721EnumerableUriStorageDeployment() { Name = "Property Registry", Symbol = "PR" };

            //Deploy the erc721Minter
            var deploymentReceipt = await ERC721EnumerableUriStorageService.DeployContractAndWaitForReceiptAsync(web3, erc721Deployment);

            //creating a new service with the new contract address
            var erc721Service = new ERC721EnumerableUriStorageService(web3, deploymentReceipt.ContractAddress);

            //uploading to ipfs our documents
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

        }
    }
}