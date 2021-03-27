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
using Optimism.Contracts.OVM.Predeploys.OVM_SequencerEntrypoint.ContractDefinition;

namespace Optimism.Contracts.OVM.Predeploys.OVM_SequencerEntrypoint
{
    public partial class OVM_SequencerEntrypointService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_SequencerEntrypointDeployment oVM_SequencerEntrypointDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_SequencerEntrypointDeployment>().SendRequestAndWaitForReceiptAsync(oVM_SequencerEntrypointDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_SequencerEntrypointDeployment oVM_SequencerEntrypointDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_SequencerEntrypointDeployment>().SendRequestAsync(oVM_SequencerEntrypointDeployment);
        }

        public static async Task<OVM_SequencerEntrypointService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_SequencerEntrypointDeployment oVM_SequencerEntrypointDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_SequencerEntrypointDeployment, cancellationTokenSource);
            return new OVM_SequencerEntrypointService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_SequencerEntrypointService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
