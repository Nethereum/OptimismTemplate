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
using Optimism.Contracts.OVM.Execution.OVM_StateManagerFactory.ContractDefinition;

namespace Optimism.Contracts.OVM.Execution.OVM_StateManagerFactory
{
    public partial class OVM_StateManagerFactoryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_StateManagerFactoryDeployment oVM_StateManagerFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_StateManagerFactoryDeployment>().SendRequestAndWaitForReceiptAsync(oVM_StateManagerFactoryDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_StateManagerFactoryDeployment oVM_StateManagerFactoryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_StateManagerFactoryDeployment>().SendRequestAsync(oVM_StateManagerFactoryDeployment);
        }

        public static async Task<OVM_StateManagerFactoryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_StateManagerFactoryDeployment oVM_StateManagerFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_StateManagerFactoryDeployment, cancellationTokenSource);
            return new OVM_StateManagerFactoryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_StateManagerFactoryService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> CreateRequestAsync(CreateFunction createFunction)
        {
             return ContractHandler.SendRequestAsync(createFunction);
        }

        public Task<TransactionReceipt> CreateRequestAndWaitForReceiptAsync(CreateFunction createFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createFunction, cancellationToken);
        }

        public Task<string> CreateRequestAsync(string owner)
        {
            var createFunction = new CreateFunction();
                createFunction.Owner = owner;
            
             return ContractHandler.SendRequestAsync(createFunction);
        }

        public Task<TransactionReceipt> CreateRequestAndWaitForReceiptAsync(string owner, CancellationTokenSource cancellationToken = null)
        {
            var createFunction = new CreateFunction();
                createFunction.Owner = owner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createFunction, cancellationToken);
        }
    }
}
