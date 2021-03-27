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
using Optimism.Contracts.OVM.Bridge.Tokens.OVM_L2DepositedERC20.ContractDefinition;

namespace Optimism.Contracts.OVM.Bridge.Tokens.OVM_L2DepositedERC20
{
    public partial class OVM_L2DepositedERC20Service
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_L2DepositedERC20Deployment oVM_L2DepositedERC20Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_L2DepositedERC20Deployment>().SendRequestAndWaitForReceiptAsync(oVM_L2DepositedERC20Deployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_L2DepositedERC20Deployment oVM_L2DepositedERC20Deployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_L2DepositedERC20Deployment>().SendRequestAsync(oVM_L2DepositedERC20Deployment);
        }

        public static async Task<OVM_L2DepositedERC20Service> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_L2DepositedERC20Deployment oVM_L2DepositedERC20Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_L2DepositedERC20Deployment, cancellationTokenSource);
            return new OVM_L2DepositedERC20Service(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_L2DepositedERC20Service(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<byte[]> DOMAIN_SEPARATORQueryAsync(DOMAIN_SEPARATORFunction dOMAIN_SEPARATORFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DOMAIN_SEPARATORFunction, byte[]>(dOMAIN_SEPARATORFunction, blockParameter);
        }

        
        public Task<byte[]> DOMAIN_SEPARATORQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DOMAIN_SEPARATORFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> PERMIT_TYPEHASHQueryAsync(PERMIT_TYPEHASHFunction pERMIT_TYPEHASHFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PERMIT_TYPEHASHFunction, byte[]>(pERMIT_TYPEHASHFunction, blockParameter);
        }

        
        public Task<byte[]> PERMIT_TYPEHASHQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PERMIT_TYPEHASHFunction, byte[]>(null, blockParameter);
        }

        public Task<BigInteger> AllowanceQueryAsync(AllowanceFunction allowanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        
        public Task<BigInteger> AllowanceQueryAsync(string returnValue1, string returnValue2, BlockParameter blockParameter = null)
        {
            var allowanceFunction = new AllowanceFunction();
                allowanceFunction.ReturnValue1 = returnValue1;
                allowanceFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string spender, BigInteger value)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string spender, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<byte> DecimalsQueryAsync(DecimalsFunction decimalsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(decimalsFunction, blockParameter);
        }

        
        public Task<byte> DecimalsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(null, blockParameter);
        }

        public Task<string> FinalizeDepositRequestAsync(FinalizeDepositFunction finalizeDepositFunction)
        {
             return ContractHandler.SendRequestAsync(finalizeDepositFunction);
        }

        public Task<TransactionReceipt> FinalizeDepositRequestAndWaitForReceiptAsync(FinalizeDepositFunction finalizeDepositFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(finalizeDepositFunction, cancellationToken);
        }

        public Task<string> FinalizeDepositRequestAsync(string to, BigInteger amount)
        {
            var finalizeDepositFunction = new FinalizeDepositFunction();
                finalizeDepositFunction.To = to;
                finalizeDepositFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(finalizeDepositFunction);
        }

        public Task<TransactionReceipt> FinalizeDepositRequestAndWaitForReceiptAsync(string to, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var finalizeDepositFunction = new FinalizeDepositFunction();
                finalizeDepositFunction.To = to;
                finalizeDepositFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(finalizeDepositFunction, cancellationToken);
        }

        public Task<uint> GetFinalizeWithdrawalL1GasQueryAsync(GetFinalizeWithdrawalL1GasFunction getFinalizeWithdrawalL1GasFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetFinalizeWithdrawalL1GasFunction, uint>(getFinalizeWithdrawalL1GasFunction, blockParameter);
        }

        
        public Task<uint> GetFinalizeWithdrawalL1GasQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetFinalizeWithdrawalL1GasFunction, uint>(null, blockParameter);
        }

        public Task<string> InitRequestAsync(InitFunction initFunction)
        {
             return ContractHandler.SendRequestAsync(initFunction);
        }

        public Task<TransactionReceipt> InitRequestAndWaitForReceiptAsync(InitFunction initFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initFunction, cancellationToken);
        }

        public Task<string> InitRequestAsync(string l1TokenGateway)
        {
            var initFunction = new InitFunction();
                initFunction.L1TokenGateway = l1TokenGateway;
            
             return ContractHandler.SendRequestAsync(initFunction);
        }

        public Task<TransactionReceipt> InitRequestAndWaitForReceiptAsync(string l1TokenGateway, CancellationTokenSource cancellationToken = null)
        {
            var initFunction = new InitFunction();
                initFunction.L1TokenGateway = l1TokenGateway;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initFunction, cancellationToken);
        }

        public Task<string> L1TokenGatewayQueryAsync(L1TokenGatewayFunction l1TokenGatewayFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<L1TokenGatewayFunction, string>(l1TokenGatewayFunction, blockParameter);
        }

        
        public Task<string> L1TokenGatewayQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<L1TokenGatewayFunction, string>(null, blockParameter);
        }

        public Task<string> MessengerQueryAsync(MessengerFunction messengerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MessengerFunction, string>(messengerFunction, blockParameter);
        }

        
        public Task<string> MessengerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MessengerFunction, string>(null, blockParameter);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> NoncesQueryAsync(NoncesFunction noncesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NoncesFunction, BigInteger>(noncesFunction, blockParameter);
        }

        
        public Task<BigInteger> NoncesQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var noncesFunction = new NoncesFunction();
                noncesFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<NoncesFunction, BigInteger>(noncesFunction, blockParameter);
        }

        public Task<string> PermitRequestAsync(PermitFunction permitFunction)
        {
             return ContractHandler.SendRequestAsync(permitFunction);
        }

        public Task<TransactionReceipt> PermitRequestAndWaitForReceiptAsync(PermitFunction permitFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(permitFunction, cancellationToken);
        }

        public Task<string> PermitRequestAsync(string owner, string spender, BigInteger value, BigInteger deadline, byte v, byte[] r, byte[] s)
        {
            var permitFunction = new PermitFunction();
                permitFunction.Owner = owner;
                permitFunction.Spender = spender;
                permitFunction.Value = value;
                permitFunction.Deadline = deadline;
                permitFunction.V = v;
                permitFunction.R = r;
                permitFunction.S = s;
            
             return ContractHandler.SendRequestAsync(permitFunction);
        }

        public Task<TransactionReceipt> PermitRequestAndWaitForReceiptAsync(string owner, string spender, BigInteger value, BigInteger deadline, byte v, byte[] r, byte[] s, CancellationTokenSource cancellationToken = null)
        {
            var permitFunction = new PermitFunction();
                permitFunction.Owner = owner;
                permitFunction.Spender = spender;
                permitFunction.Value = value;
                permitFunction.Deadline = deadline;
                permitFunction.V = v;
                permitFunction.R = r;
                permitFunction.S = s;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(permitFunction, cancellationToken);
        }

        public Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(symbolFunction, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferRequestAsync(TransferFunction transferFunction)
        {
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(TransferFunction transferFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferRequestAsync(string to, BigInteger value)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(string to, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string from, string to, BigInteger value)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(WithdrawFunction withdrawFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(BigInteger amount)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<string> WithdrawToRequestAsync(WithdrawToFunction withdrawToFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawToFunction);
        }

        public Task<TransactionReceipt> WithdrawToRequestAndWaitForReceiptAsync(WithdrawToFunction withdrawToFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawToFunction, cancellationToken);
        }

        public Task<string> WithdrawToRequestAsync(string to, BigInteger amount)
        {
            var withdrawToFunction = new WithdrawToFunction();
                withdrawToFunction.To = to;
                withdrawToFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(withdrawToFunction);
        }

        public Task<TransactionReceipt> WithdrawToRequestAndWaitForReceiptAsync(string to, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var withdrawToFunction = new WithdrawToFunction();
                withdrawToFunction.To = to;
                withdrawToFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawToFunction, cancellationToken);
        }
    }
}
