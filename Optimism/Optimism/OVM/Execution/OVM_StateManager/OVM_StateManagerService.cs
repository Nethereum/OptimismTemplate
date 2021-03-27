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
using Optimism.Contracts.OVM.Execution.OVM_StateManager.ContractDefinition;

namespace Optimism.Contracts.OVM.Execution.OVM_StateManager
{
    public partial class OVM_StateManagerService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_StateManagerDeployment oVM_StateManagerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_StateManagerDeployment>().SendRequestAndWaitForReceiptAsync(oVM_StateManagerDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_StateManagerDeployment oVM_StateManagerDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_StateManagerDeployment>().SendRequestAsync(oVM_StateManagerDeployment);
        }

        public static async Task<OVM_StateManagerService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_StateManagerDeployment oVM_StateManagerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_StateManagerDeployment, cancellationTokenSource);
            return new OVM_StateManagerService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_StateManagerService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> CommitAccountRequestAsync(CommitAccountFunction commitAccountFunction)
        {
             return ContractHandler.SendRequestAsync(commitAccountFunction);
        }

        public Task<TransactionReceipt> CommitAccountRequestAndWaitForReceiptAsync(CommitAccountFunction commitAccountFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(commitAccountFunction, cancellationToken);
        }

        public Task<string> CommitAccountRequestAsync(string address)
        {
            var commitAccountFunction = new CommitAccountFunction();
                commitAccountFunction.Address = address;
            
             return ContractHandler.SendRequestAsync(commitAccountFunction);
        }

        public Task<TransactionReceipt> CommitAccountRequestAndWaitForReceiptAsync(string address, CancellationTokenSource cancellationToken = null)
        {
            var commitAccountFunction = new CommitAccountFunction();
                commitAccountFunction.Address = address;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(commitAccountFunction, cancellationToken);
        }

        public Task<string> CommitContractStorageRequestAsync(CommitContractStorageFunction commitContractStorageFunction)
        {
             return ContractHandler.SendRequestAsync(commitContractStorageFunction);
        }

        public Task<TransactionReceipt> CommitContractStorageRequestAndWaitForReceiptAsync(CommitContractStorageFunction commitContractStorageFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(commitContractStorageFunction, cancellationToken);
        }

        public Task<string> CommitContractStorageRequestAsync(string contract, byte[] key)
        {
            var commitContractStorageFunction = new CommitContractStorageFunction();
                commitContractStorageFunction.Contract = contract;
                commitContractStorageFunction.Key = key;
            
             return ContractHandler.SendRequestAsync(commitContractStorageFunction);
        }

        public Task<TransactionReceipt> CommitContractStorageRequestAndWaitForReceiptAsync(string contract, byte[] key, CancellationTokenSource cancellationToken = null)
        {
            var commitContractStorageFunction = new CommitContractStorageFunction();
                commitContractStorageFunction.Contract = contract;
                commitContractStorageFunction.Key = key;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(commitContractStorageFunction, cancellationToken);
        }

        public Task<string> CommitPendingAccountRequestAsync(CommitPendingAccountFunction commitPendingAccountFunction)
        {
             return ContractHandler.SendRequestAsync(commitPendingAccountFunction);
        }

        public Task<TransactionReceipt> CommitPendingAccountRequestAndWaitForReceiptAsync(CommitPendingAccountFunction commitPendingAccountFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(commitPendingAccountFunction, cancellationToken);
        }

        public Task<string> CommitPendingAccountRequestAsync(string address, string ethAddress, byte[] codeHash)
        {
            var commitPendingAccountFunction = new CommitPendingAccountFunction();
                commitPendingAccountFunction.Address = address;
                commitPendingAccountFunction.EthAddress = ethAddress;
                commitPendingAccountFunction.CodeHash = codeHash;
            
             return ContractHandler.SendRequestAsync(commitPendingAccountFunction);
        }

        public Task<TransactionReceipt> CommitPendingAccountRequestAndWaitForReceiptAsync(string address, string ethAddress, byte[] codeHash, CancellationTokenSource cancellationToken = null)
        {
            var commitPendingAccountFunction = new CommitPendingAccountFunction();
                commitPendingAccountFunction.Address = address;
                commitPendingAccountFunction.EthAddress = ethAddress;
                commitPendingAccountFunction.CodeHash = codeHash;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(commitPendingAccountFunction, cancellationToken);
        }

        public Task<GetAccountOutputDTO> GetAccountQueryAsync(GetAccountFunction getAccountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAccountFunction, GetAccountOutputDTO>(getAccountFunction, blockParameter);
        }

        public Task<GetAccountOutputDTO> GetAccountQueryAsync(string address, BlockParameter blockParameter = null)
        {
            var getAccountFunction = new GetAccountFunction();
                getAccountFunction.Address = address;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetAccountFunction, GetAccountOutputDTO>(getAccountFunction, blockParameter);
        }

        public Task<string> GetAccountEthAddressQueryAsync(GetAccountEthAddressFunction getAccountEthAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAccountEthAddressFunction, string>(getAccountEthAddressFunction, blockParameter);
        }

        
        public Task<string> GetAccountEthAddressQueryAsync(string address, BlockParameter blockParameter = null)
        {
            var getAccountEthAddressFunction = new GetAccountEthAddressFunction();
                getAccountEthAddressFunction.Address = address;
            
            return ContractHandler.QueryAsync<GetAccountEthAddressFunction, string>(getAccountEthAddressFunction, blockParameter);
        }

        public Task<BigInteger> GetAccountNonceQueryAsync(GetAccountNonceFunction getAccountNonceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAccountNonceFunction, BigInteger>(getAccountNonceFunction, blockParameter);
        }

        
        public Task<BigInteger> GetAccountNonceQueryAsync(string address, BlockParameter blockParameter = null)
        {
            var getAccountNonceFunction = new GetAccountNonceFunction();
                getAccountNonceFunction.Address = address;
            
            return ContractHandler.QueryAsync<GetAccountNonceFunction, BigInteger>(getAccountNonceFunction, blockParameter);
        }

        public Task<byte[]> GetAccountStorageRootQueryAsync(GetAccountStorageRootFunction getAccountStorageRootFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAccountStorageRootFunction, byte[]>(getAccountStorageRootFunction, blockParameter);
        }

        
        public Task<byte[]> GetAccountStorageRootQueryAsync(string address, BlockParameter blockParameter = null)
        {
            var getAccountStorageRootFunction = new GetAccountStorageRootFunction();
                getAccountStorageRootFunction.Address = address;
            
            return ContractHandler.QueryAsync<GetAccountStorageRootFunction, byte[]>(getAccountStorageRootFunction, blockParameter);
        }

        public Task<byte[]> GetContractStorageQueryAsync(GetContractStorageFunction getContractStorageFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContractStorageFunction, byte[]>(getContractStorageFunction, blockParameter);
        }

        
        public Task<byte[]> GetContractStorageQueryAsync(string contract, byte[] key, BlockParameter blockParameter = null)
        {
            var getContractStorageFunction = new GetContractStorageFunction();
                getContractStorageFunction.Contract = contract;
                getContractStorageFunction.Key = key;
            
            return ContractHandler.QueryAsync<GetContractStorageFunction, byte[]>(getContractStorageFunction, blockParameter);
        }

        public Task<BigInteger> GetTotalUncommittedAccountsQueryAsync(GetTotalUncommittedAccountsFunction getTotalUncommittedAccountsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTotalUncommittedAccountsFunction, BigInteger>(getTotalUncommittedAccountsFunction, blockParameter);
        }

        
        public Task<BigInteger> GetTotalUncommittedAccountsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTotalUncommittedAccountsFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> GetTotalUncommittedContractStorageQueryAsync(GetTotalUncommittedContractStorageFunction getTotalUncommittedContractStorageFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTotalUncommittedContractStorageFunction, BigInteger>(getTotalUncommittedContractStorageFunction, blockParameter);
        }

        
        public Task<BigInteger> GetTotalUncommittedContractStorageQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTotalUncommittedContractStorageFunction, BigInteger>(null, blockParameter);
        }

        public Task<bool> HasAccountQueryAsync(HasAccountFunction hasAccountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasAccountFunction, bool>(hasAccountFunction, blockParameter);
        }

        
        public Task<bool> HasAccountQueryAsync(string address, BlockParameter blockParameter = null)
        {
            var hasAccountFunction = new HasAccountFunction();
                hasAccountFunction.Address = address;
            
            return ContractHandler.QueryAsync<HasAccountFunction, bool>(hasAccountFunction, blockParameter);
        }

        public Task<bool> HasContractStorageQueryAsync(HasContractStorageFunction hasContractStorageFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasContractStorageFunction, bool>(hasContractStorageFunction, blockParameter);
        }

        
        public Task<bool> HasContractStorageQueryAsync(string contract, byte[] key, BlockParameter blockParameter = null)
        {
            var hasContractStorageFunction = new HasContractStorageFunction();
                hasContractStorageFunction.Contract = contract;
                hasContractStorageFunction.Key = key;
            
            return ContractHandler.QueryAsync<HasContractStorageFunction, bool>(hasContractStorageFunction, blockParameter);
        }

        public Task<bool> HasEmptyAccountQueryAsync(HasEmptyAccountFunction hasEmptyAccountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasEmptyAccountFunction, bool>(hasEmptyAccountFunction, blockParameter);
        }

        
        public Task<bool> HasEmptyAccountQueryAsync(string address, BlockParameter blockParameter = null)
        {
            var hasEmptyAccountFunction = new HasEmptyAccountFunction();
                hasEmptyAccountFunction.Address = address;
            
            return ContractHandler.QueryAsync<HasEmptyAccountFunction, bool>(hasEmptyAccountFunction, blockParameter);
        }

        public Task<string> IncrementTotalUncommittedAccountsRequestAsync(IncrementTotalUncommittedAccountsFunction incrementTotalUncommittedAccountsFunction)
        {
             return ContractHandler.SendRequestAsync(incrementTotalUncommittedAccountsFunction);
        }

        public Task<string> IncrementTotalUncommittedAccountsRequestAsync()
        {
             return ContractHandler.SendRequestAsync<IncrementTotalUncommittedAccountsFunction>();
        }

        public Task<TransactionReceipt> IncrementTotalUncommittedAccountsRequestAndWaitForReceiptAsync(IncrementTotalUncommittedAccountsFunction incrementTotalUncommittedAccountsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(incrementTotalUncommittedAccountsFunction, cancellationToken);
        }

        public Task<TransactionReceipt> IncrementTotalUncommittedAccountsRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<IncrementTotalUncommittedAccountsFunction>(null, cancellationToken);
        }

        public Task<string> IncrementTotalUncommittedContractStorageRequestAsync(IncrementTotalUncommittedContractStorageFunction incrementTotalUncommittedContractStorageFunction)
        {
             return ContractHandler.SendRequestAsync(incrementTotalUncommittedContractStorageFunction);
        }

        public Task<string> IncrementTotalUncommittedContractStorageRequestAsync()
        {
             return ContractHandler.SendRequestAsync<IncrementTotalUncommittedContractStorageFunction>();
        }

        public Task<TransactionReceipt> IncrementTotalUncommittedContractStorageRequestAndWaitForReceiptAsync(IncrementTotalUncommittedContractStorageFunction incrementTotalUncommittedContractStorageFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(incrementTotalUncommittedContractStorageFunction, cancellationToken);
        }

        public Task<TransactionReceipt> IncrementTotalUncommittedContractStorageRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<IncrementTotalUncommittedContractStorageFunction>(null, cancellationToken);
        }

        public Task<string> InitPendingAccountRequestAsync(InitPendingAccountFunction initPendingAccountFunction)
        {
             return ContractHandler.SendRequestAsync(initPendingAccountFunction);
        }

        public Task<TransactionReceipt> InitPendingAccountRequestAndWaitForReceiptAsync(InitPendingAccountFunction initPendingAccountFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initPendingAccountFunction, cancellationToken);
        }

        public Task<string> InitPendingAccountRequestAsync(string address)
        {
            var initPendingAccountFunction = new InitPendingAccountFunction();
                initPendingAccountFunction.Address = address;
            
             return ContractHandler.SendRequestAsync(initPendingAccountFunction);
        }

        public Task<TransactionReceipt> InitPendingAccountRequestAndWaitForReceiptAsync(string address, CancellationTokenSource cancellationToken = null)
        {
            var initPendingAccountFunction = new InitPendingAccountFunction();
                initPendingAccountFunction.Address = address;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initPendingAccountFunction, cancellationToken);
        }

        public Task<bool> IsAuthenticatedQueryAsync(IsAuthenticatedFunction isAuthenticatedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsAuthenticatedFunction, bool>(isAuthenticatedFunction, blockParameter);
        }

        
        public Task<bool> IsAuthenticatedQueryAsync(string address, BlockParameter blockParameter = null)
        {
            var isAuthenticatedFunction = new IsAuthenticatedFunction();
                isAuthenticatedFunction.Address = address;
            
            return ContractHandler.QueryAsync<IsAuthenticatedFunction, bool>(isAuthenticatedFunction, blockParameter);
        }

        public Task<string> OvmExecutionManagerQueryAsync(OvmExecutionManagerFunction ovmExecutionManagerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmExecutionManagerFunction, string>(ovmExecutionManagerFunction, blockParameter);
        }

        
        public Task<string> OvmExecutionManagerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmExecutionManagerFunction, string>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> PutAccountRequestAsync(PutAccountFunction putAccountFunction)
        {
             return ContractHandler.SendRequestAsync(putAccountFunction);
        }

        public Task<TransactionReceipt> PutAccountRequestAndWaitForReceiptAsync(PutAccountFunction putAccountFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(putAccountFunction, cancellationToken);
        }

        public Task<string> PutAccountRequestAsync(string address, Account account)
        {
            var putAccountFunction = new PutAccountFunction();
                putAccountFunction.Address = address;
                putAccountFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(putAccountFunction);
        }

        public Task<TransactionReceipt> PutAccountRequestAndWaitForReceiptAsync(string address, Account account, CancellationTokenSource cancellationToken = null)
        {
            var putAccountFunction = new PutAccountFunction();
                putAccountFunction.Address = address;
                putAccountFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(putAccountFunction, cancellationToken);
        }

        public Task<string> PutContractStorageRequestAsync(PutContractStorageFunction putContractStorageFunction)
        {
             return ContractHandler.SendRequestAsync(putContractStorageFunction);
        }

        public Task<TransactionReceipt> PutContractStorageRequestAndWaitForReceiptAsync(PutContractStorageFunction putContractStorageFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(putContractStorageFunction, cancellationToken);
        }

        public Task<string> PutContractStorageRequestAsync(string contract, byte[] key, byte[] value)
        {
            var putContractStorageFunction = new PutContractStorageFunction();
                putContractStorageFunction.Contract = contract;
                putContractStorageFunction.Key = key;
                putContractStorageFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(putContractStorageFunction);
        }

        public Task<TransactionReceipt> PutContractStorageRequestAndWaitForReceiptAsync(string contract, byte[] key, byte[] value, CancellationTokenSource cancellationToken = null)
        {
            var putContractStorageFunction = new PutContractStorageFunction();
                putContractStorageFunction.Contract = contract;
                putContractStorageFunction.Key = key;
                putContractStorageFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(putContractStorageFunction, cancellationToken);
        }

        public Task<string> PutEmptyAccountRequestAsync(PutEmptyAccountFunction putEmptyAccountFunction)
        {
             return ContractHandler.SendRequestAsync(putEmptyAccountFunction);
        }

        public Task<TransactionReceipt> PutEmptyAccountRequestAndWaitForReceiptAsync(PutEmptyAccountFunction putEmptyAccountFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(putEmptyAccountFunction, cancellationToken);
        }

        public Task<string> PutEmptyAccountRequestAsync(string address)
        {
            var putEmptyAccountFunction = new PutEmptyAccountFunction();
                putEmptyAccountFunction.Address = address;
            
             return ContractHandler.SendRequestAsync(putEmptyAccountFunction);
        }

        public Task<TransactionReceipt> PutEmptyAccountRequestAndWaitForReceiptAsync(string address, CancellationTokenSource cancellationToken = null)
        {
            var putEmptyAccountFunction = new PutEmptyAccountFunction();
                putEmptyAccountFunction.Address = address;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(putEmptyAccountFunction, cancellationToken);
        }

        public Task<string> SetAccountNonceRequestAsync(SetAccountNonceFunction setAccountNonceFunction)
        {
             return ContractHandler.SendRequestAsync(setAccountNonceFunction);
        }

        public Task<TransactionReceipt> SetAccountNonceRequestAndWaitForReceiptAsync(SetAccountNonceFunction setAccountNonceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAccountNonceFunction, cancellationToken);
        }

        public Task<string> SetAccountNonceRequestAsync(string address, BigInteger nonce)
        {
            var setAccountNonceFunction = new SetAccountNonceFunction();
                setAccountNonceFunction.Address = address;
                setAccountNonceFunction.Nonce = nonce;
            
             return ContractHandler.SendRequestAsync(setAccountNonceFunction);
        }

        public Task<TransactionReceipt> SetAccountNonceRequestAndWaitForReceiptAsync(string address, BigInteger nonce, CancellationTokenSource cancellationToken = null)
        {
            var setAccountNonceFunction = new SetAccountNonceFunction();
                setAccountNonceFunction.Address = address;
                setAccountNonceFunction.Nonce = nonce;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAccountNonceFunction, cancellationToken);
        }

        public Task<string> SetExecutionManagerRequestAsync(SetExecutionManagerFunction setExecutionManagerFunction)
        {
             return ContractHandler.SendRequestAsync(setExecutionManagerFunction);
        }

        public Task<TransactionReceipt> SetExecutionManagerRequestAndWaitForReceiptAsync(SetExecutionManagerFunction setExecutionManagerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setExecutionManagerFunction, cancellationToken);
        }

        public Task<string> SetExecutionManagerRequestAsync(string ovmExecutionManager)
        {
            var setExecutionManagerFunction = new SetExecutionManagerFunction();
                setExecutionManagerFunction.OvmExecutionManager = ovmExecutionManager;
            
             return ContractHandler.SendRequestAsync(setExecutionManagerFunction);
        }

        public Task<TransactionReceipt> SetExecutionManagerRequestAndWaitForReceiptAsync(string ovmExecutionManager, CancellationTokenSource cancellationToken = null)
        {
            var setExecutionManagerFunction = new SetExecutionManagerFunction();
                setExecutionManagerFunction.OvmExecutionManager = ovmExecutionManager;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setExecutionManagerFunction, cancellationToken);
        }

        public Task<string> TestAndSetAccountChangedRequestAsync(TestAndSetAccountChangedFunction testAndSetAccountChangedFunction)
        {
             return ContractHandler.SendRequestAsync(testAndSetAccountChangedFunction);
        }

        public Task<TransactionReceipt> TestAndSetAccountChangedRequestAndWaitForReceiptAsync(TestAndSetAccountChangedFunction testAndSetAccountChangedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(testAndSetAccountChangedFunction, cancellationToken);
        }

        public Task<string> TestAndSetAccountChangedRequestAsync(string address)
        {
            var testAndSetAccountChangedFunction = new TestAndSetAccountChangedFunction();
                testAndSetAccountChangedFunction.Address = address;
            
             return ContractHandler.SendRequestAsync(testAndSetAccountChangedFunction);
        }

        public Task<TransactionReceipt> TestAndSetAccountChangedRequestAndWaitForReceiptAsync(string address, CancellationTokenSource cancellationToken = null)
        {
            var testAndSetAccountChangedFunction = new TestAndSetAccountChangedFunction();
                testAndSetAccountChangedFunction.Address = address;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(testAndSetAccountChangedFunction, cancellationToken);
        }

        public Task<string> TestAndSetAccountLoadedRequestAsync(TestAndSetAccountLoadedFunction testAndSetAccountLoadedFunction)
        {
             return ContractHandler.SendRequestAsync(testAndSetAccountLoadedFunction);
        }

        public Task<TransactionReceipt> TestAndSetAccountLoadedRequestAndWaitForReceiptAsync(TestAndSetAccountLoadedFunction testAndSetAccountLoadedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(testAndSetAccountLoadedFunction, cancellationToken);
        }

        public Task<string> TestAndSetAccountLoadedRequestAsync(string address)
        {
            var testAndSetAccountLoadedFunction = new TestAndSetAccountLoadedFunction();
                testAndSetAccountLoadedFunction.Address = address;
            
             return ContractHandler.SendRequestAsync(testAndSetAccountLoadedFunction);
        }

        public Task<TransactionReceipt> TestAndSetAccountLoadedRequestAndWaitForReceiptAsync(string address, CancellationTokenSource cancellationToken = null)
        {
            var testAndSetAccountLoadedFunction = new TestAndSetAccountLoadedFunction();
                testAndSetAccountLoadedFunction.Address = address;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(testAndSetAccountLoadedFunction, cancellationToken);
        }

        public Task<string> TestAndSetContractStorageChangedRequestAsync(TestAndSetContractStorageChangedFunction testAndSetContractStorageChangedFunction)
        {
             return ContractHandler.SendRequestAsync(testAndSetContractStorageChangedFunction);
        }

        public Task<TransactionReceipt> TestAndSetContractStorageChangedRequestAndWaitForReceiptAsync(TestAndSetContractStorageChangedFunction testAndSetContractStorageChangedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(testAndSetContractStorageChangedFunction, cancellationToken);
        }

        public Task<string> TestAndSetContractStorageChangedRequestAsync(string contract, byte[] key)
        {
            var testAndSetContractStorageChangedFunction = new TestAndSetContractStorageChangedFunction();
                testAndSetContractStorageChangedFunction.Contract = contract;
                testAndSetContractStorageChangedFunction.Key = key;
            
             return ContractHandler.SendRequestAsync(testAndSetContractStorageChangedFunction);
        }

        public Task<TransactionReceipt> TestAndSetContractStorageChangedRequestAndWaitForReceiptAsync(string contract, byte[] key, CancellationTokenSource cancellationToken = null)
        {
            var testAndSetContractStorageChangedFunction = new TestAndSetContractStorageChangedFunction();
                testAndSetContractStorageChangedFunction.Contract = contract;
                testAndSetContractStorageChangedFunction.Key = key;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(testAndSetContractStorageChangedFunction, cancellationToken);
        }

        public Task<string> TestAndSetContractStorageLoadedRequestAsync(TestAndSetContractStorageLoadedFunction testAndSetContractStorageLoadedFunction)
        {
             return ContractHandler.SendRequestAsync(testAndSetContractStorageLoadedFunction);
        }

        public Task<TransactionReceipt> TestAndSetContractStorageLoadedRequestAndWaitForReceiptAsync(TestAndSetContractStorageLoadedFunction testAndSetContractStorageLoadedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(testAndSetContractStorageLoadedFunction, cancellationToken);
        }

        public Task<string> TestAndSetContractStorageLoadedRequestAsync(string contract, byte[] key)
        {
            var testAndSetContractStorageLoadedFunction = new TestAndSetContractStorageLoadedFunction();
                testAndSetContractStorageLoadedFunction.Contract = contract;
                testAndSetContractStorageLoadedFunction.Key = key;
            
             return ContractHandler.SendRequestAsync(testAndSetContractStorageLoadedFunction);
        }

        public Task<TransactionReceipt> TestAndSetContractStorageLoadedRequestAndWaitForReceiptAsync(string contract, byte[] key, CancellationTokenSource cancellationToken = null)
        {
            var testAndSetContractStorageLoadedFunction = new TestAndSetContractStorageLoadedFunction();
                testAndSetContractStorageLoadedFunction.Contract = contract;
                testAndSetContractStorageLoadedFunction.Key = key;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(testAndSetContractStorageLoadedFunction, cancellationToken);
        }

        public Task<bool> WasAccountChangedQueryAsync(WasAccountChangedFunction wasAccountChangedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WasAccountChangedFunction, bool>(wasAccountChangedFunction, blockParameter);
        }

        
        public Task<bool> WasAccountChangedQueryAsync(string address, BlockParameter blockParameter = null)
        {
            var wasAccountChangedFunction = new WasAccountChangedFunction();
                wasAccountChangedFunction.Address = address;
            
            return ContractHandler.QueryAsync<WasAccountChangedFunction, bool>(wasAccountChangedFunction, blockParameter);
        }

        public Task<bool> WasAccountCommittedQueryAsync(WasAccountCommittedFunction wasAccountCommittedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WasAccountCommittedFunction, bool>(wasAccountCommittedFunction, blockParameter);
        }

        
        public Task<bool> WasAccountCommittedQueryAsync(string address, BlockParameter blockParameter = null)
        {
            var wasAccountCommittedFunction = new WasAccountCommittedFunction();
                wasAccountCommittedFunction.Address = address;
            
            return ContractHandler.QueryAsync<WasAccountCommittedFunction, bool>(wasAccountCommittedFunction, blockParameter);
        }

        public Task<bool> WasContractStorageChangedQueryAsync(WasContractStorageChangedFunction wasContractStorageChangedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WasContractStorageChangedFunction, bool>(wasContractStorageChangedFunction, blockParameter);
        }

        
        public Task<bool> WasContractStorageChangedQueryAsync(string contract, byte[] key, BlockParameter blockParameter = null)
        {
            var wasContractStorageChangedFunction = new WasContractStorageChangedFunction();
                wasContractStorageChangedFunction.Contract = contract;
                wasContractStorageChangedFunction.Key = key;
            
            return ContractHandler.QueryAsync<WasContractStorageChangedFunction, bool>(wasContractStorageChangedFunction, blockParameter);
        }

        public Task<bool> WasContractStorageCommittedQueryAsync(WasContractStorageCommittedFunction wasContractStorageCommittedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WasContractStorageCommittedFunction, bool>(wasContractStorageCommittedFunction, blockParameter);
        }

        
        public Task<bool> WasContractStorageCommittedQueryAsync(string contract, byte[] key, BlockParameter blockParameter = null)
        {
            var wasContractStorageCommittedFunction = new WasContractStorageCommittedFunction();
                wasContractStorageCommittedFunction.Contract = contract;
                wasContractStorageCommittedFunction.Key = key;
            
            return ContractHandler.QueryAsync<WasContractStorageCommittedFunction, bool>(wasContractStorageCommittedFunction, blockParameter);
        }
    }
}
