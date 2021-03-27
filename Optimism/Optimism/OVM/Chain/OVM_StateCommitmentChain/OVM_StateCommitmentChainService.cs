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
using Optimism.Contracts.OVM.Chain.OVM_StateCommitmentChain.ContractDefinition;

namespace Optimism.Contracts.OVM.Chain.OVM_StateCommitmentChain
{
    public partial class OVM_StateCommitmentChainService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_StateCommitmentChainDeployment oVM_StateCommitmentChainDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_StateCommitmentChainDeployment>().SendRequestAndWaitForReceiptAsync(oVM_StateCommitmentChainDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_StateCommitmentChainDeployment oVM_StateCommitmentChainDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_StateCommitmentChainDeployment>().SendRequestAsync(oVM_StateCommitmentChainDeployment);
        }

        public static async Task<OVM_StateCommitmentChainService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_StateCommitmentChainDeployment oVM_StateCommitmentChainDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_StateCommitmentChainDeployment, cancellationTokenSource);
            return new OVM_StateCommitmentChainService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_StateCommitmentChainService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> FRAUD_PROOF_WINDOWQueryAsync(FRAUD_PROOF_WINDOWFunction fRAUD_PROOF_WINDOWFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FRAUD_PROOF_WINDOWFunction, BigInteger>(fRAUD_PROOF_WINDOWFunction, blockParameter);
        }

        
        public Task<BigInteger> FRAUD_PROOF_WINDOWQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FRAUD_PROOF_WINDOWFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> SEQUENCER_PUBLISH_WINDOWQueryAsync(SEQUENCER_PUBLISH_WINDOWFunction sEQUENCER_PUBLISH_WINDOWFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SEQUENCER_PUBLISH_WINDOWFunction, BigInteger>(sEQUENCER_PUBLISH_WINDOWFunction, blockParameter);
        }

        
        public Task<BigInteger> SEQUENCER_PUBLISH_WINDOWQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SEQUENCER_PUBLISH_WINDOWFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> AppendStateBatchRequestAsync(AppendStateBatchFunction appendStateBatchFunction)
        {
             return ContractHandler.SendRequestAsync(appendStateBatchFunction);
        }

        public Task<TransactionReceipt> AppendStateBatchRequestAndWaitForReceiptAsync(AppendStateBatchFunction appendStateBatchFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(appendStateBatchFunction, cancellationToken);
        }

        public Task<string> AppendStateBatchRequestAsync(List<byte[]> batch, BigInteger shouldStartAtElement)
        {
            var appendStateBatchFunction = new AppendStateBatchFunction();
                appendStateBatchFunction.Batch = batch;
                appendStateBatchFunction.ShouldStartAtElement = shouldStartAtElement;
            
             return ContractHandler.SendRequestAsync(appendStateBatchFunction);
        }

        public Task<TransactionReceipt> AppendStateBatchRequestAndWaitForReceiptAsync(List<byte[]> batch, BigInteger shouldStartAtElement, CancellationTokenSource cancellationToken = null)
        {
            var appendStateBatchFunction = new AppendStateBatchFunction();
                appendStateBatchFunction.Batch = batch;
                appendStateBatchFunction.ShouldStartAtElement = shouldStartAtElement;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(appendStateBatchFunction, cancellationToken);
        }

        public Task<string> BatchesQueryAsync(BatchesFunction batchesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BatchesFunction, string>(batchesFunction, blockParameter);
        }

        
        public Task<string> BatchesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BatchesFunction, string>(null, blockParameter);
        }

        public Task<string> DeleteStateBatchRequestAsync(DeleteStateBatchFunction deleteStateBatchFunction)
        {
             return ContractHandler.SendRequestAsync(deleteStateBatchFunction);
        }

        public Task<TransactionReceipt> DeleteStateBatchRequestAndWaitForReceiptAsync(DeleteStateBatchFunction deleteStateBatchFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(deleteStateBatchFunction, cancellationToken);
        }

        public Task<string> DeleteStateBatchRequestAsync(ChainBatchHeader batchHeader)
        {
            var deleteStateBatchFunction = new DeleteStateBatchFunction();
                deleteStateBatchFunction.BatchHeader = batchHeader;
            
             return ContractHandler.SendRequestAsync(deleteStateBatchFunction);
        }

        public Task<TransactionReceipt> DeleteStateBatchRequestAndWaitForReceiptAsync(ChainBatchHeader batchHeader, CancellationTokenSource cancellationToken = null)
        {
            var deleteStateBatchFunction = new DeleteStateBatchFunction();
                deleteStateBatchFunction.BatchHeader = batchHeader;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(deleteStateBatchFunction, cancellationToken);
        }

        public Task<BigInteger> GetLastSequencerTimestampQueryAsync(GetLastSequencerTimestampFunction getLastSequencerTimestampFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetLastSequencerTimestampFunction, BigInteger>(getLastSequencerTimestampFunction, blockParameter);
        }

        
        public Task<BigInteger> GetLastSequencerTimestampQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetLastSequencerTimestampFunction, BigInteger>(null, blockParameter);
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

        public Task<bool> InsideFraudProofWindowQueryAsync(InsideFraudProofWindowFunction insideFraudProofWindowFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<InsideFraudProofWindowFunction, bool>(insideFraudProofWindowFunction, blockParameter);
        }

        
        public Task<bool> InsideFraudProofWindowQueryAsync(ChainBatchHeader batchHeader, BlockParameter blockParameter = null)
        {
            var insideFraudProofWindowFunction = new InsideFraudProofWindowFunction();
                insideFraudProofWindowFunction.BatchHeader = batchHeader;
            
            return ContractHandler.QueryAsync<InsideFraudProofWindowFunction, bool>(insideFraudProofWindowFunction, blockParameter);
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

        public Task<bool> VerifyStateCommitmentQueryAsync(VerifyStateCommitmentFunction verifyStateCommitmentFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VerifyStateCommitmentFunction, bool>(verifyStateCommitmentFunction, blockParameter);
        }

        
        public Task<bool> VerifyStateCommitmentQueryAsync(byte[] element, ChainBatchHeader batchHeader, ChainInclusionProof proof, BlockParameter blockParameter = null)
        {
            var verifyStateCommitmentFunction = new VerifyStateCommitmentFunction();
                verifyStateCommitmentFunction.Element = element;
                verifyStateCommitmentFunction.BatchHeader = batchHeader;
                verifyStateCommitmentFunction.Proof = proof;
            
            return ContractHandler.QueryAsync<VerifyStateCommitmentFunction, bool>(verifyStateCommitmentFunction, blockParameter);
        }
    }
}
