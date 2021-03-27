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
using Optimism.Contracts.OVM.Bridge.Tokens.OVM_L1ERC20Gateway.ContractDefinition;

namespace Optimism.Contracts.OVM.Bridge.Tokens.OVM_L1ERC20Gateway
{
    public partial class OVM_L1ERC20GatewayService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_L1ERC20GatewayDeployment oVM_L1ERC20GatewayDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_L1ERC20GatewayDeployment>().SendRequestAndWaitForReceiptAsync(oVM_L1ERC20GatewayDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_L1ERC20GatewayDeployment oVM_L1ERC20GatewayDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_L1ERC20GatewayDeployment>().SendRequestAsync(oVM_L1ERC20GatewayDeployment);
        }

        public static async Task<OVM_L1ERC20GatewayService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_L1ERC20GatewayDeployment oVM_L1ERC20GatewayDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_L1ERC20GatewayDeployment, cancellationTokenSource);
            return new OVM_L1ERC20GatewayService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_L1ERC20GatewayService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<uint> DEFAULT_FINALIZE_DEPOSIT_L2_GASQueryAsync(DEFAULT_FINALIZE_DEPOSIT_L2_GASFunction dEFAULT_FINALIZE_DEPOSIT_L2_GASFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DEFAULT_FINALIZE_DEPOSIT_L2_GASFunction, uint>(dEFAULT_FINALIZE_DEPOSIT_L2_GASFunction, blockParameter);
        }

        
        public Task<uint> DEFAULT_FINALIZE_DEPOSIT_L2_GASQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DEFAULT_FINALIZE_DEPOSIT_L2_GASFunction, uint>(null, blockParameter);
        }

        public Task<string> DepositRequestAsync(DepositFunction depositFunction)
        {
             return ContractHandler.SendRequestAsync(depositFunction);
        }

        public Task<TransactionReceipt> DepositRequestAndWaitForReceiptAsync(DepositFunction depositFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depositFunction, cancellationToken);
        }

        public Task<string> DepositRequestAsync(BigInteger amount)
        {
            var depositFunction = new DepositFunction();
                depositFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(depositFunction);
        }

        public Task<TransactionReceipt> DepositRequestAndWaitForReceiptAsync(BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var depositFunction = new DepositFunction();
                depositFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depositFunction, cancellationToken);
        }

        public Task<string> DepositToRequestAsync(DepositToFunction depositToFunction)
        {
             return ContractHandler.SendRequestAsync(depositToFunction);
        }

        public Task<TransactionReceipt> DepositToRequestAndWaitForReceiptAsync(DepositToFunction depositToFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depositToFunction, cancellationToken);
        }

        public Task<string> DepositToRequestAsync(string to, BigInteger amount)
        {
            var depositToFunction = new DepositToFunction();
                depositToFunction.To = to;
                depositToFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(depositToFunction);
        }

        public Task<TransactionReceipt> DepositToRequestAndWaitForReceiptAsync(string to, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var depositToFunction = new DepositToFunction();
                depositToFunction.To = to;
                depositToFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depositToFunction, cancellationToken);
        }

        public Task<string> FinalizeWithdrawalRequestAsync(FinalizeWithdrawalFunction finalizeWithdrawalFunction)
        {
             return ContractHandler.SendRequestAsync(finalizeWithdrawalFunction);
        }

        public Task<TransactionReceipt> FinalizeWithdrawalRequestAndWaitForReceiptAsync(FinalizeWithdrawalFunction finalizeWithdrawalFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(finalizeWithdrawalFunction, cancellationToken);
        }

        public Task<string> FinalizeWithdrawalRequestAsync(string to, BigInteger amount)
        {
            var finalizeWithdrawalFunction = new FinalizeWithdrawalFunction();
                finalizeWithdrawalFunction.To = to;
                finalizeWithdrawalFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(finalizeWithdrawalFunction);
        }

        public Task<TransactionReceipt> FinalizeWithdrawalRequestAndWaitForReceiptAsync(string to, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var finalizeWithdrawalFunction = new FinalizeWithdrawalFunction();
                finalizeWithdrawalFunction.To = to;
                finalizeWithdrawalFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(finalizeWithdrawalFunction, cancellationToken);
        }

        public Task<uint> GetFinalizeDepositL2GasQueryAsync(GetFinalizeDepositL2GasFunction getFinalizeDepositL2GasFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetFinalizeDepositL2GasFunction, uint>(getFinalizeDepositL2GasFunction, blockParameter);
        }

        
        public Task<uint> GetFinalizeDepositL2GasQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetFinalizeDepositL2GasFunction, uint>(null, blockParameter);
        }

        public Task<string> L1ERC20QueryAsync(L1ERC20Function l1ERC20Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<L1ERC20Function, string>(l1ERC20Function, blockParameter);
        }

        
        public Task<string> L1ERC20QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<L1ERC20Function, string>(null, blockParameter);
        }

        public Task<string> L2DepositedTokenQueryAsync(L2DepositedTokenFunction l2DepositedTokenFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<L2DepositedTokenFunction, string>(l2DepositedTokenFunction, blockParameter);
        }

        
        public Task<string> L2DepositedTokenQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<L2DepositedTokenFunction, string>(null, blockParameter);
        }

        public Task<string> MessengerQueryAsync(MessengerFunction messengerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MessengerFunction, string>(messengerFunction, blockParameter);
        }

        
        public Task<string> MessengerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MessengerFunction, string>(null, blockParameter);
        }
    }
}
