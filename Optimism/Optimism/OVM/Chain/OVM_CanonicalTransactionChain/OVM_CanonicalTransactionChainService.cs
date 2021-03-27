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
using Optimism.Contracts.OVM.Chain.OVM_CanonicalTransactionChain.ContractDefinition;

namespace Optimism.Contracts.OVM.Chain.OVM_CanonicalTransactionChain
{
    public partial class OVM_CanonicalTransactionChainService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_CanonicalTransactionChainDeployment oVM_CanonicalTransactionChainDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_CanonicalTransactionChainDeployment>().SendRequestAndWaitForReceiptAsync(oVM_CanonicalTransactionChainDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_CanonicalTransactionChainDeployment oVM_CanonicalTransactionChainDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_CanonicalTransactionChainDeployment>().SendRequestAsync(oVM_CanonicalTransactionChainDeployment);
        }

        public static async Task<OVM_CanonicalTransactionChainService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_CanonicalTransactionChainDeployment oVM_CanonicalTransactionChainDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_CanonicalTransactionChainDeployment, cancellationTokenSource);
            return new OVM_CanonicalTransactionChainService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_CanonicalTransactionChainService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> L2_GAS_DISCOUNT_DIVISORQueryAsync(L2_GAS_DISCOUNT_DIVISORFunction l2_GAS_DISCOUNT_DIVISORFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<L2_GAS_DISCOUNT_DIVISORFunction, BigInteger>(l2_GAS_DISCOUNT_DIVISORFunction, blockParameter);
        }

        
        public Task<BigInteger> L2_GAS_DISCOUNT_DIVISORQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<L2_GAS_DISCOUNT_DIVISORFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> MAX_ROLLUP_TX_SIZEQueryAsync(MAX_ROLLUP_TX_SIZEFunction mAX_ROLLUP_TX_SIZEFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MAX_ROLLUP_TX_SIZEFunction, BigInteger>(mAX_ROLLUP_TX_SIZEFunction, blockParameter);
        }

        
        public Task<BigInteger> MAX_ROLLUP_TX_SIZEQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MAX_ROLLUP_TX_SIZEFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> MIN_ROLLUP_TX_GASQueryAsync(MIN_ROLLUP_TX_GASFunction mIN_ROLLUP_TX_GASFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MIN_ROLLUP_TX_GASFunction, BigInteger>(mIN_ROLLUP_TX_GASFunction, blockParameter);
        }

        
        public Task<BigInteger> MIN_ROLLUP_TX_GASQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MIN_ROLLUP_TX_GASFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> AppendQueueBatchRequestAsync(AppendQueueBatchFunction appendQueueBatchFunction)
        {
             return ContractHandler.SendRequestAsync(appendQueueBatchFunction);
        }

        public Task<TransactionReceipt> AppendQueueBatchRequestAndWaitForReceiptAsync(AppendQueueBatchFunction appendQueueBatchFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(appendQueueBatchFunction, cancellationToken);
        }

        public Task<string> AppendQueueBatchRequestAsync(BigInteger returnValue1)
        {
            var appendQueueBatchFunction = new AppendQueueBatchFunction();
                appendQueueBatchFunction.ReturnValue1 = returnValue1;
            
             return ContractHandler.SendRequestAsync(appendQueueBatchFunction);
        }

        public Task<TransactionReceipt> AppendQueueBatchRequestAndWaitForReceiptAsync(BigInteger returnValue1, CancellationTokenSource cancellationToken = null)
        {
            var appendQueueBatchFunction = new AppendQueueBatchFunction();
                appendQueueBatchFunction.ReturnValue1 = returnValue1;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(appendQueueBatchFunction, cancellationToken);
        }

        public Task<string> AppendSequencerBatchRequestAsync(AppendSequencerBatchFunction appendSequencerBatchFunction)
        {
             return ContractHandler.SendRequestAsync(appendSequencerBatchFunction);
        }

        public Task<string> AppendSequencerBatchRequestAsync()
        {
             return ContractHandler.SendRequestAsync<AppendSequencerBatchFunction>();
        }

        public Task<TransactionReceipt> AppendSequencerBatchRequestAndWaitForReceiptAsync(AppendSequencerBatchFunction appendSequencerBatchFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(appendSequencerBatchFunction, cancellationToken);
        }

        public Task<TransactionReceipt> AppendSequencerBatchRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<AppendSequencerBatchFunction>(null, cancellationToken);
        }

        public Task<string> BatchesQueryAsync(BatchesFunction batchesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BatchesFunction, string>(batchesFunction, blockParameter);
        }

        
        public Task<string> BatchesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BatchesFunction, string>(null, blockParameter);
        }

        public Task<string> EnqueueRequestAsync(EnqueueFunction enqueueFunction)
        {
             return ContractHandler.SendRequestAsync(enqueueFunction);
        }

        public Task<TransactionReceipt> EnqueueRequestAndWaitForReceiptAsync(EnqueueFunction enqueueFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(enqueueFunction, cancellationToken);
        }

        public Task<string> EnqueueRequestAsync(string target, BigInteger gasLimit, byte[] data)
        {
            var enqueueFunction = new EnqueueFunction();
                enqueueFunction.Target = target;
                enqueueFunction.GasLimit = gasLimit;
                enqueueFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(enqueueFunction);
        }

        public Task<TransactionReceipt> EnqueueRequestAndWaitForReceiptAsync(string target, BigInteger gasLimit, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var enqueueFunction = new EnqueueFunction();
                enqueueFunction.Target = target;
                enqueueFunction.GasLimit = gasLimit;
                enqueueFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(enqueueFunction, cancellationToken);
        }

        public Task<BigInteger> ForceInclusionPeriodBlocksQueryAsync(ForceInclusionPeriodBlocksFunction forceInclusionPeriodBlocksFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ForceInclusionPeriodBlocksFunction, BigInteger>(forceInclusionPeriodBlocksFunction, blockParameter);
        }

        
        public Task<BigInteger> ForceInclusionPeriodBlocksQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ForceInclusionPeriodBlocksFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> ForceInclusionPeriodSecondsQueryAsync(ForceInclusionPeriodSecondsFunction forceInclusionPeriodSecondsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ForceInclusionPeriodSecondsFunction, BigInteger>(forceInclusionPeriodSecondsFunction, blockParameter);
        }

        
        public Task<BigInteger> ForceInclusionPeriodSecondsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ForceInclusionPeriodSecondsFunction, BigInteger>(null, blockParameter);
        }

        public Task<ulong> GetLastBlockNumberQueryAsync(GetLastBlockNumberFunction getLastBlockNumberFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetLastBlockNumberFunction, ulong>(getLastBlockNumberFunction, blockParameter);
        }

        
        public Task<ulong> GetLastBlockNumberQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetLastBlockNumberFunction, ulong>(null, blockParameter);
        }

        public Task<ulong> GetLastTimestampQueryAsync(GetLastTimestampFunction getLastTimestampFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetLastTimestampFunction, ulong>(getLastTimestampFunction, blockParameter);
        }

        
        public Task<ulong> GetLastTimestampQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetLastTimestampFunction, ulong>(null, blockParameter);
        }

        public Task<ulong> GetNextQueueIndexQueryAsync(GetNextQueueIndexFunction getNextQueueIndexFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetNextQueueIndexFunction, ulong>(getNextQueueIndexFunction, blockParameter);
        }

        
        public Task<ulong> GetNextQueueIndexQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetNextQueueIndexFunction, ulong>(null, blockParameter);
        }

        public Task<ulong> GetNumPendingQueueElementsQueryAsync(GetNumPendingQueueElementsFunction getNumPendingQueueElementsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetNumPendingQueueElementsFunction, ulong>(getNumPendingQueueElementsFunction, blockParameter);
        }

        
        public Task<ulong> GetNumPendingQueueElementsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetNumPendingQueueElementsFunction, ulong>(null, blockParameter);
        }

        public Task<GetQueueElementOutputDTO> GetQueueElementQueryAsync(GetQueueElementFunction getQueueElementFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetQueueElementFunction, GetQueueElementOutputDTO>(getQueueElementFunction, blockParameter);
        }

        public Task<GetQueueElementOutputDTO> GetQueueElementQueryAsync(BigInteger index, BlockParameter blockParameter = null)
        {
            var getQueueElementFunction = new GetQueueElementFunction();
                getQueueElementFunction.Index = index;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetQueueElementFunction, GetQueueElementOutputDTO>(getQueueElementFunction, blockParameter);
        }

        public Task<ulong> GetQueueLengthQueryAsync(GetQueueLengthFunction getQueueLengthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetQueueLengthFunction, ulong>(getQueueLengthFunction, blockParameter);
        }

        
        public Task<ulong> GetQueueLengthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetQueueLengthFunction, ulong>(null, blockParameter);
        }

        public Task<BigInteger> GetTotalBatchesQueryAsync(GetTotalBatchesFunction getTotalBatchesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTotalBatchesFunction, BigInteger>(getTotalBatchesFunction, blockParameter);
        }

        
        public Task<BigInteger> GetTotalBatchesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTotalBatchesFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> GetTotalElementsQueryAsync(GetTotalElementsFunction getTotalElementsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTotalElementsFunction, BigInteger>(getTotalElementsFunction, blockParameter);
        }

        
        public Task<BigInteger> GetTotalElementsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTotalElementsFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> LibAddressManagerQueryAsync(LibAddressManagerFunction libAddressManagerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LibAddressManagerFunction, string>(libAddressManagerFunction, blockParameter);
        }

        
        public Task<string> LibAddressManagerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LibAddressManagerFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> MaxTransactionGasLimitQueryAsync(MaxTransactionGasLimitFunction maxTransactionGasLimitFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MaxTransactionGasLimitFunction, BigInteger>(maxTransactionGasLimitFunction, blockParameter);
        }

        
        public Task<BigInteger> MaxTransactionGasLimitQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MaxTransactionGasLimitFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> QueueQueryAsync(QueueFunction queueFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<QueueFunction, string>(queueFunction, blockParameter);
        }

        
        public Task<string> QueueQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<QueueFunction, string>(null, blockParameter);
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

        public Task<bool> VerifyTransactionQueryAsync(VerifyTransactionFunction verifyTransactionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VerifyTransactionFunction, bool>(verifyTransactionFunction, blockParameter);
        }

        
        public Task<bool> VerifyTransactionQueryAsync(OvmTransaction transaction, TransactionChainElement txChainElement, ChainBatchHeader batchHeader, ChainInclusionProof inclusionProof, BlockParameter blockParameter = null)
        {
            var verifyTransactionFunction = new VerifyTransactionFunction();
                verifyTransactionFunction.Transaction = transaction;
                verifyTransactionFunction.TxChainElement = txChainElement;
                verifyTransactionFunction.BatchHeader = batchHeader;
                verifyTransactionFunction.InclusionProof = inclusionProof;
            
            return ContractHandler.QueryAsync<VerifyTransactionFunction, bool>(verifyTransactionFunction, blockParameter);
        }
    }
}
