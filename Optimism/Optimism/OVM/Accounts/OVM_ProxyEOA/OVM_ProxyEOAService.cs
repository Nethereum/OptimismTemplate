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
using Optimism.Contracts.OVM.Accounts.OVM_ProxyEOA.ContractDefinition;

namespace Optimism.Contracts.OVM.Accounts.OVM_ProxyEOA
{
    public partial class OVM_ProxyEOAService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_ProxyEOADeployment oVM_ProxyEOADeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_ProxyEOADeployment>().SendRequestAndWaitForReceiptAsync(oVM_ProxyEOADeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_ProxyEOADeployment oVM_ProxyEOADeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_ProxyEOADeployment>().SendRequestAsync(oVM_ProxyEOADeployment);
        }

        public static async Task<OVM_ProxyEOAService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_ProxyEOADeployment oVM_ProxyEOADeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_ProxyEOADeployment, cancellationTokenSource);
            return new OVM_ProxyEOAService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_ProxyEOAService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> GetImplementationRequestAsync(GetImplementationFunction getImplementationFunction)
        {
             return ContractHandler.SendRequestAsync(getImplementationFunction);
        }

        public Task<string> GetImplementationRequestAsync()
        {
             return ContractHandler.SendRequestAsync<GetImplementationFunction>();
        }

        public Task<TransactionReceipt> GetImplementationRequestAndWaitForReceiptAsync(GetImplementationFunction getImplementationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(getImplementationFunction, cancellationToken);
        }

        public Task<TransactionReceipt> GetImplementationRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<GetImplementationFunction>(null, cancellationToken);
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
