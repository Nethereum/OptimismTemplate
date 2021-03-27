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
using Optimism.Contracts.OVM.Bridge.Messaging.OVM_L1MultiMessageRelayer.ContractDefinition;

namespace Optimism.Contracts.OVM.Bridge.Messaging.OVM_L1MultiMessageRelayer
{
    public partial class OVM_L1MultiMessageRelayerService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_L1MultiMessageRelayerDeployment oVM_L1MultiMessageRelayerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_L1MultiMessageRelayerDeployment>().SendRequestAndWaitForReceiptAsync(oVM_L1MultiMessageRelayerDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_L1MultiMessageRelayerDeployment oVM_L1MultiMessageRelayerDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_L1MultiMessageRelayerDeployment>().SendRequestAsync(oVM_L1MultiMessageRelayerDeployment);
        }

        public static async Task<OVM_L1MultiMessageRelayerService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_L1MultiMessageRelayerDeployment oVM_L1MultiMessageRelayerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_L1MultiMessageRelayerDeployment, cancellationTokenSource);
            return new OVM_L1MultiMessageRelayerService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_L1MultiMessageRelayerService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> BatchRelayMessagesRequestAsync(BatchRelayMessagesFunction batchRelayMessagesFunction)
        {
             return ContractHandler.SendRequestAsync(batchRelayMessagesFunction);
        }

        public Task<TransactionReceipt> BatchRelayMessagesRequestAndWaitForReceiptAsync(BatchRelayMessagesFunction batchRelayMessagesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(batchRelayMessagesFunction, cancellationToken);
        }

        public Task<string> BatchRelayMessagesRequestAsync(List<L2ToL1Message> messages)
        {
            var batchRelayMessagesFunction = new BatchRelayMessagesFunction();
                batchRelayMessagesFunction.Messages = messages;
            
             return ContractHandler.SendRequestAsync(batchRelayMessagesFunction);
        }

        public Task<TransactionReceipt> BatchRelayMessagesRequestAndWaitForReceiptAsync(List<L2ToL1Message> messages, CancellationTokenSource cancellationToken = null)
        {
            var batchRelayMessagesFunction = new BatchRelayMessagesFunction();
                batchRelayMessagesFunction.Messages = messages;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(batchRelayMessagesFunction, cancellationToken);
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
