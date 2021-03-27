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
using Optimism.Contracts.OVM.Verification.OVM_StateTransitioner.ContractDefinition;

namespace Optimism.Contracts.OVM.Verification.OVM_StateTransitioner
{
    public partial class OVM_StateTransitionerService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_StateTransitionerDeployment oVM_StateTransitionerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_StateTransitionerDeployment>().SendRequestAndWaitForReceiptAsync(oVM_StateTransitionerDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_StateTransitionerDeployment oVM_StateTransitionerDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_StateTransitionerDeployment>().SendRequestAsync(oVM_StateTransitionerDeployment);
        }

        public static async Task<OVM_StateTransitionerService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_StateTransitionerDeployment oVM_StateTransitionerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_StateTransitionerDeployment, cancellationTokenSource);
            return new OVM_StateTransitionerService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_StateTransitionerService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> ApplyTransactionRequestAsync(ApplyTransactionFunction applyTransactionFunction)
        {
             return ContractHandler.SendRequestAsync(applyTransactionFunction);
        }

        public Task<TransactionReceipt> ApplyTransactionRequestAndWaitForReceiptAsync(ApplyTransactionFunction applyTransactionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(applyTransactionFunction, cancellationToken);
        }

        public Task<string> ApplyTransactionRequestAsync(OvmTransaction transaction)
        {
            var applyTransactionFunction = new ApplyTransactionFunction();
                applyTransactionFunction.Transaction = transaction;
            
             return ContractHandler.SendRequestAsync(applyTransactionFunction);
        }

        public Task<TransactionReceipt> ApplyTransactionRequestAndWaitForReceiptAsync(OvmTransaction transaction, CancellationTokenSource cancellationToken = null)
        {
            var applyTransactionFunction = new ApplyTransactionFunction();
                applyTransactionFunction.Transaction = transaction;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(applyTransactionFunction, cancellationToken);
        }

        public Task<string> CommitContractStateRequestAsync(CommitContractStateFunction commitContractStateFunction)
        {
             return ContractHandler.SendRequestAsync(commitContractStateFunction);
        }

        public Task<TransactionReceipt> CommitContractStateRequestAndWaitForReceiptAsync(CommitContractStateFunction commitContractStateFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(commitContractStateFunction, cancellationToken);
        }

        public Task<string> CommitContractStateRequestAsync(string ovmContractAddress, byte[] stateTrieWitness)
        {
            var commitContractStateFunction = new CommitContractStateFunction();
                commitContractStateFunction.OvmContractAddress = ovmContractAddress;
                commitContractStateFunction.StateTrieWitness = stateTrieWitness;
            
             return ContractHandler.SendRequestAsync(commitContractStateFunction);
        }

        public Task<TransactionReceipt> CommitContractStateRequestAndWaitForReceiptAsync(string ovmContractAddress, byte[] stateTrieWitness, CancellationTokenSource cancellationToken = null)
        {
            var commitContractStateFunction = new CommitContractStateFunction();
                commitContractStateFunction.OvmContractAddress = ovmContractAddress;
                commitContractStateFunction.StateTrieWitness = stateTrieWitness;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(commitContractStateFunction, cancellationToken);
        }

        public Task<string> CommitStorageSlotRequestAsync(CommitStorageSlotFunction commitStorageSlotFunction)
        {
             return ContractHandler.SendRequestAsync(commitStorageSlotFunction);
        }

        public Task<TransactionReceipt> CommitStorageSlotRequestAndWaitForReceiptAsync(CommitStorageSlotFunction commitStorageSlotFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(commitStorageSlotFunction, cancellationToken);
        }

        public Task<string> CommitStorageSlotRequestAsync(string ovmContractAddress, byte[] key, byte[] storageTrieWitness)
        {
            var commitStorageSlotFunction = new CommitStorageSlotFunction();
                commitStorageSlotFunction.OvmContractAddress = ovmContractAddress;
                commitStorageSlotFunction.Key = key;
                commitStorageSlotFunction.StorageTrieWitness = storageTrieWitness;
            
             return ContractHandler.SendRequestAsync(commitStorageSlotFunction);
        }

        public Task<TransactionReceipt> CommitStorageSlotRequestAndWaitForReceiptAsync(string ovmContractAddress, byte[] key, byte[] storageTrieWitness, CancellationTokenSource cancellationToken = null)
        {
            var commitStorageSlotFunction = new CommitStorageSlotFunction();
                commitStorageSlotFunction.OvmContractAddress = ovmContractAddress;
                commitStorageSlotFunction.Key = key;
                commitStorageSlotFunction.StorageTrieWitness = storageTrieWitness;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(commitStorageSlotFunction, cancellationToken);
        }

        public Task<string> CompleteTransitionRequestAsync(CompleteTransitionFunction completeTransitionFunction)
        {
             return ContractHandler.SendRequestAsync(completeTransitionFunction);
        }

        public Task<string> CompleteTransitionRequestAsync()
        {
             return ContractHandler.SendRequestAsync<CompleteTransitionFunction>();
        }

        public Task<TransactionReceipt> CompleteTransitionRequestAndWaitForReceiptAsync(CompleteTransitionFunction completeTransitionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(completeTransitionFunction, cancellationToken);
        }

        public Task<TransactionReceipt> CompleteTransitionRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<CompleteTransitionFunction>(null, cancellationToken);
        }

        public Task<byte[]> GetPostStateRootQueryAsync(GetPostStateRootFunction getPostStateRootFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPostStateRootFunction, byte[]>(getPostStateRootFunction, blockParameter);
        }

        
        public Task<byte[]> GetPostStateRootQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPostStateRootFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> GetPreStateRootQueryAsync(GetPreStateRootFunction getPreStateRootFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPreStateRootFunction, byte[]>(getPreStateRootFunction, blockParameter);
        }

        
        public Task<byte[]> GetPreStateRootQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPreStateRootFunction, byte[]>(null, blockParameter);
        }

        public Task<bool> IsCompleteQueryAsync(IsCompleteFunction isCompleteFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsCompleteFunction, bool>(isCompleteFunction, blockParameter);
        }

        
        public Task<bool> IsCompleteQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsCompleteFunction, bool>(null, blockParameter);
        }

        public Task<string> LibAddressManagerQueryAsync(LibAddressManagerFunction libAddressManagerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LibAddressManagerFunction, string>(libAddressManagerFunction, blockParameter);
        }

        
        public Task<string> LibAddressManagerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LibAddressManagerFunction, string>(null, blockParameter);
        }

        public Task<string> OvmStateManagerQueryAsync(OvmStateManagerFunction ovmStateManagerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmStateManagerFunction, string>(ovmStateManagerFunction, blockParameter);
        }

        
        public Task<string> OvmStateManagerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmStateManagerFunction, string>(null, blockParameter);
        }

        public Task<byte> PhaseQueryAsync(PhaseFunction phaseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PhaseFunction, byte>(phaseFunction, blockParameter);
        }

        
        public Task<byte> PhaseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PhaseFunction, byte>(null, blockParameter);
        }

        public Task<string> ProveContractStateRequestAsync(ProveContractStateFunction proveContractStateFunction)
        {
             return ContractHandler.SendRequestAsync(proveContractStateFunction);
        }

        public Task<TransactionReceipt> ProveContractStateRequestAndWaitForReceiptAsync(ProveContractStateFunction proveContractStateFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(proveContractStateFunction, cancellationToken);
        }

        public Task<string> ProveContractStateRequestAsync(string ovmContractAddress, string ethContractAddress, byte[] stateTrieWitness)
        {
            var proveContractStateFunction = new ProveContractStateFunction();
                proveContractStateFunction.OvmContractAddress = ovmContractAddress;
                proveContractStateFunction.EthContractAddress = ethContractAddress;
                proveContractStateFunction.StateTrieWitness = stateTrieWitness;
            
             return ContractHandler.SendRequestAsync(proveContractStateFunction);
        }

        public Task<TransactionReceipt> ProveContractStateRequestAndWaitForReceiptAsync(string ovmContractAddress, string ethContractAddress, byte[] stateTrieWitness, CancellationTokenSource cancellationToken = null)
        {
            var proveContractStateFunction = new ProveContractStateFunction();
                proveContractStateFunction.OvmContractAddress = ovmContractAddress;
                proveContractStateFunction.EthContractAddress = ethContractAddress;
                proveContractStateFunction.StateTrieWitness = stateTrieWitness;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(proveContractStateFunction, cancellationToken);
        }

        public Task<string> ProveStorageSlotRequestAsync(ProveStorageSlotFunction proveStorageSlotFunction)
        {
             return ContractHandler.SendRequestAsync(proveStorageSlotFunction);
        }

        public Task<TransactionReceipt> ProveStorageSlotRequestAndWaitForReceiptAsync(ProveStorageSlotFunction proveStorageSlotFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(proveStorageSlotFunction, cancellationToken);
        }

        public Task<string> ProveStorageSlotRequestAsync(string ovmContractAddress, byte[] key, byte[] storageTrieWitness)
        {
            var proveStorageSlotFunction = new ProveStorageSlotFunction();
                proveStorageSlotFunction.OvmContractAddress = ovmContractAddress;
                proveStorageSlotFunction.Key = key;
                proveStorageSlotFunction.StorageTrieWitness = storageTrieWitness;
            
             return ContractHandler.SendRequestAsync(proveStorageSlotFunction);
        }

        public Task<TransactionReceipt> ProveStorageSlotRequestAndWaitForReceiptAsync(string ovmContractAddress, byte[] key, byte[] storageTrieWitness, CancellationTokenSource cancellationToken = null)
        {
            var proveStorageSlotFunction = new ProveStorageSlotFunction();
                proveStorageSlotFunction.OvmContractAddress = ovmContractAddress;
                proveStorageSlotFunction.Key = key;
                proveStorageSlotFunction.StorageTrieWitness = storageTrieWitness;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(proveStorageSlotFunction, cancellationToken);
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
