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
using Optimism.Contracts.OVM.Predeploys.OVM_DeployerWhitelist.ContractDefinition;

namespace Optimism.Contracts.OVM.Predeploys.OVM_DeployerWhitelist
{
    public partial class OVM_DeployerWhitelistService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_DeployerWhitelistDeployment oVM_DeployerWhitelistDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_DeployerWhitelistDeployment>().SendRequestAndWaitForReceiptAsync(oVM_DeployerWhitelistDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_DeployerWhitelistDeployment oVM_DeployerWhitelistDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_DeployerWhitelistDeployment>().SendRequestAsync(oVM_DeployerWhitelistDeployment);
        }

        public static async Task<OVM_DeployerWhitelistService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_DeployerWhitelistDeployment oVM_DeployerWhitelistDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_DeployerWhitelistDeployment, cancellationTokenSource);
            return new OVM_DeployerWhitelistService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_DeployerWhitelistService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> EnableArbitraryContractDeploymentRequestAsync(EnableArbitraryContractDeploymentFunction enableArbitraryContractDeploymentFunction)
        {
             return ContractHandler.SendRequestAsync(enableArbitraryContractDeploymentFunction);
        }

        public Task<string> EnableArbitraryContractDeploymentRequestAsync()
        {
             return ContractHandler.SendRequestAsync<EnableArbitraryContractDeploymentFunction>();
        }

        public Task<TransactionReceipt> EnableArbitraryContractDeploymentRequestAndWaitForReceiptAsync(EnableArbitraryContractDeploymentFunction enableArbitraryContractDeploymentFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(enableArbitraryContractDeploymentFunction, cancellationToken);
        }

        public Task<TransactionReceipt> EnableArbitraryContractDeploymentRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<EnableArbitraryContractDeploymentFunction>(null, cancellationToken);
        }

        public Task<string> GetOwnerRequestAsync(GetOwnerFunction getOwnerFunction)
        {
             return ContractHandler.SendRequestAsync(getOwnerFunction);
        }

        public Task<string> GetOwnerRequestAsync()
        {
             return ContractHandler.SendRequestAsync<GetOwnerFunction>();
        }

        public Task<TransactionReceipt> GetOwnerRequestAndWaitForReceiptAsync(GetOwnerFunction getOwnerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(getOwnerFunction, cancellationToken);
        }

        public Task<TransactionReceipt> GetOwnerRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<GetOwnerFunction>(null, cancellationToken);
        }

        public Task<string> InitializeRequestAsync(InitializeFunction initializeFunction)
        {
             return ContractHandler.SendRequestAsync(initializeFunction);
        }

        public Task<TransactionReceipt> InitializeRequestAndWaitForReceiptAsync(InitializeFunction initializeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initializeFunction, cancellationToken);
        }

        public Task<string> InitializeRequestAsync(string owner, bool allowArbitraryDeployment)
        {
            var initializeFunction = new InitializeFunction();
                initializeFunction.Owner = owner;
                initializeFunction.AllowArbitraryDeployment = allowArbitraryDeployment;
            
             return ContractHandler.SendRequestAsync(initializeFunction);
        }

        public Task<TransactionReceipt> InitializeRequestAndWaitForReceiptAsync(string owner, bool allowArbitraryDeployment, CancellationTokenSource cancellationToken = null)
        {
            var initializeFunction = new InitializeFunction();
                initializeFunction.Owner = owner;
                initializeFunction.AllowArbitraryDeployment = allowArbitraryDeployment;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initializeFunction, cancellationToken);
        }

        public Task<string> IsDeployerAllowedRequestAsync(IsDeployerAllowedFunction isDeployerAllowedFunction)
        {
             return ContractHandler.SendRequestAsync(isDeployerAllowedFunction);
        }

        public Task<TransactionReceipt> IsDeployerAllowedRequestAndWaitForReceiptAsync(IsDeployerAllowedFunction isDeployerAllowedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(isDeployerAllowedFunction, cancellationToken);
        }

        public Task<string> IsDeployerAllowedRequestAsync(string deployer)
        {
            var isDeployerAllowedFunction = new IsDeployerAllowedFunction();
                isDeployerAllowedFunction.Deployer = deployer;
            
             return ContractHandler.SendRequestAsync(isDeployerAllowedFunction);
        }

        public Task<TransactionReceipt> IsDeployerAllowedRequestAndWaitForReceiptAsync(string deployer, CancellationTokenSource cancellationToken = null)
        {
            var isDeployerAllowedFunction = new IsDeployerAllowedFunction();
                isDeployerAllowedFunction.Deployer = deployer;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(isDeployerAllowedFunction, cancellationToken);
        }

        public Task<string> SetAllowArbitraryDeploymentRequestAsync(SetAllowArbitraryDeploymentFunction setAllowArbitraryDeploymentFunction)
        {
             return ContractHandler.SendRequestAsync(setAllowArbitraryDeploymentFunction);
        }

        public Task<TransactionReceipt> SetAllowArbitraryDeploymentRequestAndWaitForReceiptAsync(SetAllowArbitraryDeploymentFunction setAllowArbitraryDeploymentFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAllowArbitraryDeploymentFunction, cancellationToken);
        }

        public Task<string> SetAllowArbitraryDeploymentRequestAsync(bool allowArbitraryDeployment)
        {
            var setAllowArbitraryDeploymentFunction = new SetAllowArbitraryDeploymentFunction();
                setAllowArbitraryDeploymentFunction.AllowArbitraryDeployment = allowArbitraryDeployment;
            
             return ContractHandler.SendRequestAsync(setAllowArbitraryDeploymentFunction);
        }

        public Task<TransactionReceipt> SetAllowArbitraryDeploymentRequestAndWaitForReceiptAsync(bool allowArbitraryDeployment, CancellationTokenSource cancellationToken = null)
        {
            var setAllowArbitraryDeploymentFunction = new SetAllowArbitraryDeploymentFunction();
                setAllowArbitraryDeploymentFunction.AllowArbitraryDeployment = allowArbitraryDeployment;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAllowArbitraryDeploymentFunction, cancellationToken);
        }

        public Task<string> SetOwnerRequestAsync(SetOwnerFunction setOwnerFunction)
        {
             return ContractHandler.SendRequestAsync(setOwnerFunction);
        }

        public Task<TransactionReceipt> SetOwnerRequestAndWaitForReceiptAsync(SetOwnerFunction setOwnerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setOwnerFunction, cancellationToken);
        }

        public Task<string> SetOwnerRequestAsync(string owner)
        {
            var setOwnerFunction = new SetOwnerFunction();
                setOwnerFunction.Owner = owner;
            
             return ContractHandler.SendRequestAsync(setOwnerFunction);
        }

        public Task<TransactionReceipt> SetOwnerRequestAndWaitForReceiptAsync(string owner, CancellationTokenSource cancellationToken = null)
        {
            var setOwnerFunction = new SetOwnerFunction();
                setOwnerFunction.Owner = owner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setOwnerFunction, cancellationToken);
        }

        public Task<string> SetWhitelistedDeployerRequestAsync(SetWhitelistedDeployerFunction setWhitelistedDeployerFunction)
        {
             return ContractHandler.SendRequestAsync(setWhitelistedDeployerFunction);
        }

        public Task<TransactionReceipt> SetWhitelistedDeployerRequestAndWaitForReceiptAsync(SetWhitelistedDeployerFunction setWhitelistedDeployerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setWhitelistedDeployerFunction, cancellationToken);
        }

        public Task<string> SetWhitelistedDeployerRequestAsync(string deployer, bool isWhitelisted)
        {
            var setWhitelistedDeployerFunction = new SetWhitelistedDeployerFunction();
                setWhitelistedDeployerFunction.Deployer = deployer;
                setWhitelistedDeployerFunction.IsWhitelisted = isWhitelisted;
            
             return ContractHandler.SendRequestAsync(setWhitelistedDeployerFunction);
        }

        public Task<TransactionReceipt> SetWhitelistedDeployerRequestAndWaitForReceiptAsync(string deployer, bool isWhitelisted, CancellationTokenSource cancellationToken = null)
        {
            var setWhitelistedDeployerFunction = new SetWhitelistedDeployerFunction();
                setWhitelistedDeployerFunction.Deployer = deployer;
                setWhitelistedDeployerFunction.IsWhitelisted = isWhitelisted;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setWhitelistedDeployerFunction, cancellationToken);
        }
    }
}
