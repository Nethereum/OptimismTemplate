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
using Optimism.Contracts.OVM.Execution.OVM_SafetyChecker.ContractDefinition;

namespace Optimism.Contracts.OVM.Execution.OVM_SafetyChecker
{
    public partial class OVM_SafetyCheckerService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_SafetyCheckerDeployment oVM_SafetyCheckerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_SafetyCheckerDeployment>().SendRequestAndWaitForReceiptAsync(oVM_SafetyCheckerDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_SafetyCheckerDeployment oVM_SafetyCheckerDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_SafetyCheckerDeployment>().SendRequestAsync(oVM_SafetyCheckerDeployment);
        }

        public static async Task<OVM_SafetyCheckerService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_SafetyCheckerDeployment oVM_SafetyCheckerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_SafetyCheckerDeployment, cancellationTokenSource);
            return new OVM_SafetyCheckerService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_SafetyCheckerService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<bool> IsBytecodeSafeQueryAsync(IsBytecodeSafeFunction isBytecodeSafeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsBytecodeSafeFunction, bool>(isBytecodeSafeFunction, blockParameter);
        }

        
        public Task<bool> IsBytecodeSafeQueryAsync(byte[] bytecode, BlockParameter blockParameter = null)
        {
            var isBytecodeSafeFunction = new IsBytecodeSafeFunction();
                isBytecodeSafeFunction.Bytecode = bytecode;
            
            return ContractHandler.QueryAsync<IsBytecodeSafeFunction, bool>(isBytecodeSafeFunction, blockParameter);
        }
    }
}
