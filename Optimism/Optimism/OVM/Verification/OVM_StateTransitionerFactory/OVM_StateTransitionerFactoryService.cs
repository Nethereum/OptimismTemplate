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
using Optimism.Contracts.OVM.Verification.OVM_StateTransitionerFactory.ContractDefinition;

namespace Optimism.Contracts.OVM.Verification.OVM_StateTransitionerFactory
{
    public partial class OVM_StateTransitionerFactoryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_StateTransitionerFactoryDeployment oVM_StateTransitionerFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_StateTransitionerFactoryDeployment>().SendRequestAndWaitForReceiptAsync(oVM_StateTransitionerFactoryDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_StateTransitionerFactoryDeployment oVM_StateTransitionerFactoryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_StateTransitionerFactoryDeployment>().SendRequestAsync(oVM_StateTransitionerFactoryDeployment);
        }

        public static async Task<OVM_StateTransitionerFactoryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_StateTransitionerFactoryDeployment oVM_StateTransitionerFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_StateTransitionerFactoryDeployment, cancellationTokenSource);
            return new OVM_StateTransitionerFactoryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_StateTransitionerFactoryService(Nethereum.Web3.Web3 web3, string contractAddress)
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

        public Task<string> CreateRequestAsync(string libAddressManager, BigInteger stateTransitionIndex, byte[] preStateRoot, byte[] transactionHash)
        {
            var createFunction = new CreateFunction();
                createFunction.LibAddressManager = libAddressManager;
                createFunction.StateTransitionIndex = stateTransitionIndex;
                createFunction.PreStateRoot = preStateRoot;
                createFunction.TransactionHash = transactionHash;
            
             return ContractHandler.SendRequestAsync(createFunction);
        }

        public Task<TransactionReceipt> CreateRequestAndWaitForReceiptAsync(string libAddressManager, BigInteger stateTransitionIndex, byte[] preStateRoot, byte[] transactionHash, CancellationTokenSource cancellationToken = null)
        {
            var createFunction = new CreateFunction();
                createFunction.LibAddressManager = libAddressManager;
                createFunction.StateTransitionIndex = stateTransitionIndex;
                createFunction.PreStateRoot = preStateRoot;
                createFunction.TransactionHash = transactionHash;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createFunction, cancellationToken);
        }

        public Task<string> LibAddressManagerQueryAsync(LibAddressManagerFunction libAddressManagerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LibAddressManagerFunction, string>(libAddressManagerFunction, blockParameter);
        }

        
        public Task<string> LibAddressManagerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LibAddressManagerFunction, string>(null, blockParameter);
        }

        public Task<string> ResolveQueryAsync(ResolveFunction resolveFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ResolveFunction, string>(resolveFunction, blockParameter);
        }

        
        public Task<string> ResolveQueryAsync(string name, BlockParameter blockParameter = null)
        {
            var resolveFunction = new ResolveFunction();
                resolveFunction.Name = name;
            
            return ContractHandler.QueryAsync<ResolveFunction, string>(resolveFunction, blockParameter);
        }
    }
}
