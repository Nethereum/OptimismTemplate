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
using Optimism.Contracts.OVM.Accounts.OVM_ECDSAContractAccount.ContractDefinition;

namespace Optimism.Contracts.OVM.Accounts.OVM_ECDSAContractAccount
{
    public partial class OVM_ECDSAContractAccountService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_ECDSAContractAccountDeployment oVM_ECDSAContractAccountDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_ECDSAContractAccountDeployment>().SendRequestAndWaitForReceiptAsync(oVM_ECDSAContractAccountDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_ECDSAContractAccountDeployment oVM_ECDSAContractAccountDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_ECDSAContractAccountDeployment>().SendRequestAsync(oVM_ECDSAContractAccountDeployment);
        }

        public static async Task<OVM_ECDSAContractAccountService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_ECDSAContractAccountDeployment oVM_ECDSAContractAccountDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_ECDSAContractAccountDeployment, cancellationTokenSource);
            return new OVM_ECDSAContractAccountService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_ECDSAContractAccountService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> ExecuteRequestAsync(ExecuteFunction executeFunction)
        {
             return ContractHandler.SendRequestAsync(executeFunction);
        }

        public Task<TransactionReceipt> ExecuteRequestAndWaitForReceiptAsync(ExecuteFunction executeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(executeFunction, cancellationToken);
        }

        public Task<string> ExecuteRequestAsync(byte[] transaction, byte signatureType, byte v, byte[] r, byte[] s)
        {
            var executeFunction = new ExecuteFunction();
                executeFunction.Transaction = transaction;
                executeFunction.SignatureType = signatureType;
                executeFunction.V = v;
                executeFunction.R = r;
                executeFunction.S = s;
            
             return ContractHandler.SendRequestAsync(executeFunction);
        }

        public Task<TransactionReceipt> ExecuteRequestAndWaitForReceiptAsync(byte[] transaction, byte signatureType, byte v, byte[] r, byte[] s, CancellationTokenSource cancellationToken = null)
        {
            var executeFunction = new ExecuteFunction();
                executeFunction.Transaction = transaction;
                executeFunction.SignatureType = signatureType;
                executeFunction.V = v;
                executeFunction.R = r;
                executeFunction.S = s;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(executeFunction, cancellationToken);
        }
    }
}
