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
using OptimismTemplate.Contracts.OVM_L1CrossDomainMessenger.ContractDefinition;

namespace OptimismTemplate.Contracts.OVM_L1CrossDomainMessenger
{
    public partial class OVM_L1CrossDomainMessengerService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_L1CrossDomainMessengerDeployment oVM_L1CrossDomainMessengerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_L1CrossDomainMessengerDeployment>().SendRequestAndWaitForReceiptAsync(oVM_L1CrossDomainMessengerDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_L1CrossDomainMessengerDeployment oVM_L1CrossDomainMessengerDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_L1CrossDomainMessengerDeployment>().SendRequestAsync(oVM_L1CrossDomainMessengerDeployment);
        }

        public static async Task<OVM_L1CrossDomainMessengerService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_L1CrossDomainMessengerDeployment oVM_L1CrossDomainMessengerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_L1CrossDomainMessengerDeployment, cancellationTokenSource);
            return new OVM_L1CrossDomainMessengerService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_L1CrossDomainMessengerService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> InitializeRequestAsync(InitializeFunction initializeFunction)
        {
             return ContractHandler.SendRequestAsync(initializeFunction);
        }

        public Task<TransactionReceipt> InitializeRequestAndWaitForReceiptAsync(InitializeFunction initializeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initializeFunction, cancellationToken);
        }

        public Task<string> InitializeRequestAsync(string libAddressManager)
        {
            var initializeFunction = new InitializeFunction();
                initializeFunction.LibAddressManager = libAddressManager;
            
             return ContractHandler.SendRequestAsync(initializeFunction);
        }

        public Task<TransactionReceipt> InitializeRequestAndWaitForReceiptAsync(string libAddressManager, CancellationTokenSource cancellationToken = null)
        {
            var initializeFunction = new InitializeFunction();
                initializeFunction.LibAddressManager = libAddressManager;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initializeFunction, cancellationToken);
        }

        public Task<BigInteger> MessageNonceQueryAsync(MessageNonceFunction messageNonceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MessageNonceFunction, BigInteger>(messageNonceFunction, blockParameter);
        }

        
        public Task<BigInteger> MessageNonceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MessageNonceFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> RelayMessageRequestAsync(RelayMessageFunction relayMessageFunction)
        {
             return ContractHandler.SendRequestAsync(relayMessageFunction);
        }

        public Task<TransactionReceipt> RelayMessageRequestAndWaitForReceiptAsync(RelayMessageFunction relayMessageFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(relayMessageFunction, cancellationToken);
        }

        public Task<string> RelayMessageRequestAsync(string target, string sender, byte[] message, BigInteger messageNonce, L2MessageInclusionProof proof)
        {
            var relayMessageFunction = new RelayMessageFunction();
                relayMessageFunction.Target = target;
                relayMessageFunction.Sender = sender;
                relayMessageFunction.Message = message;
                relayMessageFunction.MessageNonce = messageNonce;
                relayMessageFunction.Proof = proof;
            
             return ContractHandler.SendRequestAsync(relayMessageFunction);
        }

        public Task<TransactionReceipt> RelayMessageRequestAndWaitForReceiptAsync(string target, string sender, byte[] message, BigInteger messageNonce, L2MessageInclusionProof proof, CancellationTokenSource cancellationToken = null)
        {
            var relayMessageFunction = new RelayMessageFunction();
                relayMessageFunction.Target = target;
                relayMessageFunction.Sender = sender;
                relayMessageFunction.Message = message;
                relayMessageFunction.MessageNonce = messageNonce;
                relayMessageFunction.Proof = proof;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(relayMessageFunction, cancellationToken);
        }

        public Task<bool> RelayedMessagesQueryAsync(RelayedMessagesFunction relayedMessagesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RelayedMessagesFunction, bool>(relayedMessagesFunction, blockParameter);
        }

        
        public Task<bool> RelayedMessagesQueryAsync(byte[] returnValue1, BlockParameter blockParameter = null)
        {
            var relayedMessagesFunction = new RelayedMessagesFunction();
                relayedMessagesFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<RelayedMessagesFunction, bool>(relayedMessagesFunction, blockParameter);
        }

        public Task<string> ReplayMessageRequestAsync(ReplayMessageFunction replayMessageFunction)
        {
             return ContractHandler.SendRequestAsync(replayMessageFunction);
        }

        public Task<TransactionReceipt> ReplayMessageRequestAndWaitForReceiptAsync(ReplayMessageFunction replayMessageFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(replayMessageFunction, cancellationToken);
        }

        public Task<string> ReplayMessageRequestAsync(string target, string sender, byte[] message, BigInteger messageNonce, uint gasLimit)
        {
            var replayMessageFunction = new ReplayMessageFunction();
                replayMessageFunction.Target = target;
                replayMessageFunction.Sender = sender;
                replayMessageFunction.Message = message;
                replayMessageFunction.MessageNonce = messageNonce;
                replayMessageFunction.GasLimit = gasLimit;
            
             return ContractHandler.SendRequestAsync(replayMessageFunction);
        }

        public Task<TransactionReceipt> ReplayMessageRequestAndWaitForReceiptAsync(string target, string sender, byte[] message, BigInteger messageNonce, uint gasLimit, CancellationTokenSource cancellationToken = null)
        {
            var replayMessageFunction = new ReplayMessageFunction();
                replayMessageFunction.Target = target;
                replayMessageFunction.Sender = sender;
                replayMessageFunction.Message = message;
                replayMessageFunction.MessageNonce = messageNonce;
                replayMessageFunction.GasLimit = gasLimit;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(replayMessageFunction, cancellationToken);
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

        public Task<string> SendMessageRequestAsync(SendMessageFunction sendMessageFunction)
        {
             return ContractHandler.SendRequestAsync(sendMessageFunction);
        }

        public Task<TransactionReceipt> SendMessageRequestAndWaitForReceiptAsync(SendMessageFunction sendMessageFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sendMessageFunction, cancellationToken);
        }

        public Task<string> SendMessageRequestAsync(string target, byte[] message, uint gasLimit)
        {
            var sendMessageFunction = new SendMessageFunction();
                sendMessageFunction.Target = target;
                sendMessageFunction.Message = message;
                sendMessageFunction.GasLimit = gasLimit;
            
             return ContractHandler.SendRequestAsync(sendMessageFunction);
        }

        public Task<TransactionReceipt> SendMessageRequestAndWaitForReceiptAsync(string target, byte[] message, uint gasLimit, CancellationTokenSource cancellationToken = null)
        {
            var sendMessageFunction = new SendMessageFunction();
                sendMessageFunction.Target = target;
                sendMessageFunction.Message = message;
                sendMessageFunction.GasLimit = gasLimit;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sendMessageFunction, cancellationToken);
        }

        public Task<bool> SentMessagesQueryAsync(SentMessagesFunction sentMessagesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SentMessagesFunction, bool>(sentMessagesFunction, blockParameter);
        }

        
        public Task<bool> SentMessagesQueryAsync(byte[] returnValue1, BlockParameter blockParameter = null)
        {
            var sentMessagesFunction = new SentMessagesFunction();
                sentMessagesFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<SentMessagesFunction, bool>(sentMessagesFunction, blockParameter);
        }

        public Task<bool> SuccessfulMessagesQueryAsync(SuccessfulMessagesFunction successfulMessagesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SuccessfulMessagesFunction, bool>(successfulMessagesFunction, blockParameter);
        }

        
        public Task<bool> SuccessfulMessagesQueryAsync(byte[] returnValue1, BlockParameter blockParameter = null)
        {
            var successfulMessagesFunction = new SuccessfulMessagesFunction();
                successfulMessagesFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<SuccessfulMessagesFunction, bool>(successfulMessagesFunction, blockParameter);
        }

        public Task<string> XDomainMessageSenderQueryAsync(XDomainMessageSenderFunction xDomainMessageSenderFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<XDomainMessageSenderFunction, string>(xDomainMessageSenderFunction, blockParameter);
        }

        
        public Task<string> XDomainMessageSenderQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<XDomainMessageSenderFunction, string>(null, blockParameter);
        }
    }
}
