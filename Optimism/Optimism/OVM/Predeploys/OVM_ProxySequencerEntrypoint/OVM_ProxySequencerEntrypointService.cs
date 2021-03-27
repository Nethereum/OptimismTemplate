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
using Optimism.Contracts.OVM.Predeploys.OVM_ProxySequencerEntrypoint.ContractDefinition;

namespace Optimism.Contracts.OVM.Predeploys.OVM_ProxySequencerEntrypoint
{
    public partial class OVM_ProxySequencerEntrypointService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_ProxySequencerEntrypointDeployment oVM_ProxySequencerEntrypointDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_ProxySequencerEntrypointDeployment>().SendRequestAndWaitForReceiptAsync(oVM_ProxySequencerEntrypointDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_ProxySequencerEntrypointDeployment oVM_ProxySequencerEntrypointDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_ProxySequencerEntrypointDeployment>().SendRequestAsync(oVM_ProxySequencerEntrypointDeployment);
        }

        public static async Task<OVM_ProxySequencerEntrypointService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_ProxySequencerEntrypointDeployment oVM_ProxySequencerEntrypointDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_ProxySequencerEntrypointDeployment, cancellationTokenSource);
            return new OVM_ProxySequencerEntrypointService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_ProxySequencerEntrypointService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> InitRequestAsync(InitFunction initFunction)
        {
             return ContractHandler.SendRequestAsync(initFunction);
        }

        public Task<TransactionReceipt> InitRequestAndWaitForReceiptAsync(InitFunction initFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initFunction, cancellationToken);
        }

        public Task<string> InitRequestAsync(string implementation, string owner)
        {
            var initFunction = new InitFunction();
                initFunction.Implementation = implementation;
                initFunction.Owner = owner;
            
             return ContractHandler.SendRequestAsync(initFunction);
        }

        public Task<TransactionReceipt> InitRequestAndWaitForReceiptAsync(string implementation, string owner, CancellationTokenSource cancellationToken = null)
        {
            var initFunction = new InitFunction();
                initFunction.Implementation = implementation;
                initFunction.Owner = owner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initFunction, cancellationToken);
        }

        public Task<string> UpgradeRequestAsync(UpgradeFunction upgradeFunction)
        {
             return ContractHandler.SendRequestAsync(upgradeFunction);
        }

        public Task<TransactionReceipt> UpgradeRequestAndWaitForReceiptAsync(UpgradeFunction upgradeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upgradeFunction, cancellationToken);
        }

        public Task<string> UpgradeRequestAsync(string implementation)
        {
            var upgradeFunction = new UpgradeFunction();
                upgradeFunction.Implementation = implementation;
            
             return ContractHandler.SendRequestAsync(upgradeFunction);
        }

        public Task<TransactionReceipt> UpgradeRequestAndWaitForReceiptAsync(string implementation, CancellationTokenSource cancellationToken = null)
        {
            var upgradeFunction = new UpgradeFunction();
                upgradeFunction.Implementation = implementation;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upgradeFunction, cancellationToken);
        }
    }
}
