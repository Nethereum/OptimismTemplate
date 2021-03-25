using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using OptimismTemplate.Contracts.ICrossDomainMessenger.ContractDefinition;

namespace OptimismTemplate.Contracts.ICrossDomainMessenger
{
    public partial class ICrossDomainMessengerService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ICrossDomainMessengerDeployment iCrossDomainMessengerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ICrossDomainMessengerDeployment>().SendRequestAndWaitForReceiptAsync(iCrossDomainMessengerDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ICrossDomainMessengerDeployment iCrossDomainMessengerDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ICrossDomainMessengerDeployment>().SendRequestAsync(iCrossDomainMessengerDeployment);
        }

        public static async Task<ICrossDomainMessengerService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ICrossDomainMessengerDeployment iCrossDomainMessengerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iCrossDomainMessengerDeployment, cancellationTokenSource);
            return new ICrossDomainMessengerService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ICrossDomainMessengerService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> XDomainMessageSenderQueryAsync(XDomainMessageSenderFunction xDomainMessageSenderFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<XDomainMessageSenderFunction, string>(xDomainMessageSenderFunction, blockParameter);
        }

        
        public Task<string> XDomainMessageSenderQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<XDomainMessageSenderFunction, string>(null, blockParameter);
        }
    }
}
