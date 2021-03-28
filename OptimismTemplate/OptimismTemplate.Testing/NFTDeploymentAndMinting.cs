using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ipfs;
using Ipfs.Http;
using Nethereum.Contracts;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Newtonsoft.Json;
using OptimismTemplate.Contracts.MyERC721;
using OptimismTemplate.Contracts.MyERC721.ContractDefinition;
using Xunit;

namespace OptimismTemplate.Testing
{
    public class NFTDeploymentAndMinting
    {
        
        [Fact]
        public async void ShouldDeployContractCreateNftMetadataUploadToIpfsAndMint()
        {
            var web3l2 = new Web3(new Account("0x754fde3f5e60ef2c7649061e06957c29017fe21032a8017132c0078e37f6193a", 420), "http://localhost:8545");
            var ourAdddress = "0x023ffdc1530468eb8c8eebc3e38380b5bc19cc5d";
            var myERC721Deployment = new MyERC721Deployment()
            {
                BaseURI = "https://ipfs.io/ipfs/",
                Name = "OPTNETNFTS",
                Symbol = "OPTNETH",
                Gas = 7000000
            };

            var receipt = await MyERC721Service.DeployContractAndWaitForReceiptAsync(web3l2, myERC721Deployment);

            var byteCode = await web3l2.Eth.GetCode.SendRequestAsync(receipt.ContractAddress);

            var service = new MyERC721Service(web3l2, receipt.ContractAddress);
            var imageNode = await AddImageToIpfs("Images/image1.png");
            var metadataNode = await AddNftsMetadataToIpfs(new NftMetadata()
                { Name = "NethereumLovesOptimism", ExternalUrl = "https://github.com/Nethereum/OptimismTemplate/", Image = "https://ipfs.infura.io/ipfs/" + imageNode.Id.ToString() });

            var receiptMint = await service.MintRequestAndWaitForReceiptAsync(ourAdddress, metadataNode.Id.ToString());
            var mintedInfo = receiptMint
                .DecodeAllEvents<OptimismTemplate.Contracts.MyERC721.ContractDefinition.TransferEventDTO>().FirstOrDefault();


            var tokenMetadataUri = await service.TokenURIQueryAsync(mintedInfo.Event.TokenId);

            var client = new WebClient();

            var nftMetadataJson = await client.DownloadStringTaskAsync(new Uri(tokenMetadataUri));

            var nftMetadata = JsonConvert.DeserializeObject<NftMetadata>(nftMetadataJson);

            Assert.Equal("https://ipfs.infura.io/ipfs/" + imageNode.Id.ToString(), nftMetadata.Image);

            var ps = new ProcessStartInfo(nftMetadata.Image)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);

        }


        public class NftMetadata
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("description")]
            public string Description { get; set; }
            [JsonProperty("external_url")]
            public string ExternalUrl { get; set; }
            [JsonProperty("image")]
            public string Image { get; set; }
        }


        public async Task<IFileSystemNode> AddNftsMetadataToIpfs(NftMetadata metadata)
        {
            var ipfsClient = new IpfsClient("https://ipfs.infura.io:5001");
            using (var ms = new MemoryStream())
            {
                var serializer = new JsonSerializer();
                var jsonTextWriter = new JsonTextWriter(new StreamWriter(ms));
                serializer.Serialize(jsonTextWriter, metadata);
                jsonTextWriter.Flush();
                ms.Position = 0;
                var node = await ipfsClient.FileSystem.AddAsync(ms);
                await ipfsClient.Pin.AddAsync(node.Id);
                return node;
            }
        }

        public async Task<IFileSystemNode> AddImageToIpfs(string path)
        {
            var ipfsClient = new IpfsClient("https://ipfs.infura.io:5001");
            var node = await ipfsClient.FileSystem.AddFileAsync(path);
            await ipfsClient.Pin.AddAsync(node.Id);
            return node;

        }
    }
}