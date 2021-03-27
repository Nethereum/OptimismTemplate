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
using Optimism.Contracts.OVM.Execution.OVM_ExecutionManager.ContractDefinition;

namespace Optimism.Contracts.OVM.Execution.OVM_ExecutionManager
{
    public partial class OVM_ExecutionManagerService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OVM_ExecutionManagerDeployment oVM_ExecutionManagerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_ExecutionManagerDeployment>().SendRequestAndWaitForReceiptAsync(oVM_ExecutionManagerDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OVM_ExecutionManagerDeployment oVM_ExecutionManagerDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OVM_ExecutionManagerDeployment>().SendRequestAsync(oVM_ExecutionManagerDeployment);
        }

        public static async Task<OVM_ExecutionManagerService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OVM_ExecutionManagerDeployment oVM_ExecutionManagerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oVM_ExecutionManagerDeployment, cancellationTokenSource);
            return new OVM_ExecutionManagerService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OVM_ExecutionManagerService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> GetMaxTransactionGasLimitQueryAsync(GetMaxTransactionGasLimitFunction getMaxTransactionGasLimitFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetMaxTransactionGasLimitFunction, BigInteger>(getMaxTransactionGasLimitFunction, blockParameter);
        }

        
        public Task<BigInteger> GetMaxTransactionGasLimitQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetMaxTransactionGasLimitFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> LibAddressManagerQueryAsync(LibAddressManagerFunction libAddressManagerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LibAddressManagerFunction, string>(libAddressManagerFunction, blockParameter);
        }

        
        public Task<string> LibAddressManagerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LibAddressManagerFunction, string>(null, blockParameter);
        }

        public Task<string> OvmADDRESSQueryAsync(OvmADDRESSFunction ovmADDRESSFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmADDRESSFunction, string>(ovmADDRESSFunction, blockParameter);
        }

        
        public Task<string> OvmADDRESSQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmADDRESSFunction, string>(null, blockParameter);
        }

        public Task<string> OvmCALLRequestAsync(OvmCALLFunction ovmCALLFunction)
        {
             return ContractHandler.SendRequestAsync(ovmCALLFunction);
        }

        public Task<TransactionReceipt> OvmCALLRequestAndWaitForReceiptAsync(OvmCALLFunction ovmCALLFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmCALLFunction, cancellationToken);
        }

        public Task<string> OvmCALLRequestAsync(BigInteger gasLimit, string address, byte[] calldata)
        {
            var ovmCALLFunction = new OvmCALLFunction();
                ovmCALLFunction.GasLimit = gasLimit;
                ovmCALLFunction.Address = address;
                ovmCALLFunction.Calldata = calldata;
            
             return ContractHandler.SendRequestAsync(ovmCALLFunction);
        }

        public Task<TransactionReceipt> OvmCALLRequestAndWaitForReceiptAsync(BigInteger gasLimit, string address, byte[] calldata, CancellationTokenSource cancellationToken = null)
        {
            var ovmCALLFunction = new OvmCALLFunction();
                ovmCALLFunction.GasLimit = gasLimit;
                ovmCALLFunction.Address = address;
                ovmCALLFunction.Calldata = calldata;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmCALLFunction, cancellationToken);
        }

        public Task<string> OvmCALLERQueryAsync(OvmCALLERFunction ovmCALLERFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmCALLERFunction, string>(ovmCALLERFunction, blockParameter);
        }

        
        public Task<string> OvmCALLERQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmCALLERFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> OvmCHAINIDQueryAsync(OvmCHAINIDFunction ovmCHAINIDFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmCHAINIDFunction, BigInteger>(ovmCHAINIDFunction, blockParameter);
        }

        
        public Task<BigInteger> OvmCHAINIDQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmCHAINIDFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> OvmCREATERequestAsync(OvmCREATEFunction ovmCREATEFunction)
        {
             return ContractHandler.SendRequestAsync(ovmCREATEFunction);
        }

        public Task<TransactionReceipt> OvmCREATERequestAndWaitForReceiptAsync(OvmCREATEFunction ovmCREATEFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmCREATEFunction, cancellationToken);
        }

        public Task<string> OvmCREATERequestAsync(byte[] bytecode)
        {
            var ovmCREATEFunction = new OvmCREATEFunction();
                ovmCREATEFunction.Bytecode = bytecode;
            
             return ContractHandler.SendRequestAsync(ovmCREATEFunction);
        }

        public Task<TransactionReceipt> OvmCREATERequestAndWaitForReceiptAsync(byte[] bytecode, CancellationTokenSource cancellationToken = null)
        {
            var ovmCREATEFunction = new OvmCREATEFunction();
                ovmCREATEFunction.Bytecode = bytecode;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmCREATEFunction, cancellationToken);
        }

        public Task<string> OvmCREATE2RequestAsync(OvmCREATE2Function ovmCREATE2Function)
        {
             return ContractHandler.SendRequestAsync(ovmCREATE2Function);
        }

        public Task<TransactionReceipt> OvmCREATE2RequestAndWaitForReceiptAsync(OvmCREATE2Function ovmCREATE2Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmCREATE2Function, cancellationToken);
        }

        public Task<string> OvmCREATE2RequestAsync(byte[] bytecode, byte[] salt)
        {
            var ovmCREATE2Function = new OvmCREATE2Function();
                ovmCREATE2Function.Bytecode = bytecode;
                ovmCREATE2Function.Salt = salt;
            
             return ContractHandler.SendRequestAsync(ovmCREATE2Function);
        }

        public Task<TransactionReceipt> OvmCREATE2RequestAndWaitForReceiptAsync(byte[] bytecode, byte[] salt, CancellationTokenSource cancellationToken = null)
        {
            var ovmCREATE2Function = new OvmCREATE2Function();
                ovmCREATE2Function.Bytecode = bytecode;
                ovmCREATE2Function.Salt = salt;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmCREATE2Function, cancellationToken);
        }

        public Task<string> OvmCREATEEOARequestAsync(OvmCREATEEOAFunction ovmCREATEEOAFunction)
        {
             return ContractHandler.SendRequestAsync(ovmCREATEEOAFunction);
        }

        public Task<TransactionReceipt> OvmCREATEEOARequestAndWaitForReceiptAsync(OvmCREATEEOAFunction ovmCREATEEOAFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmCREATEEOAFunction, cancellationToken);
        }

        public Task<string> OvmCREATEEOARequestAsync(byte[] messageHash, byte v, byte[] r, byte[] s)
        {
            var ovmCREATEEOAFunction = new OvmCREATEEOAFunction();
                ovmCREATEEOAFunction.MessageHash = messageHash;
                ovmCREATEEOAFunction.V = v;
                ovmCREATEEOAFunction.R = r;
                ovmCREATEEOAFunction.S = s;
            
             return ContractHandler.SendRequestAsync(ovmCREATEEOAFunction);
        }

        public Task<TransactionReceipt> OvmCREATEEOARequestAndWaitForReceiptAsync(byte[] messageHash, byte v, byte[] r, byte[] s, CancellationTokenSource cancellationToken = null)
        {
            var ovmCREATEEOAFunction = new OvmCREATEEOAFunction();
                ovmCREATEEOAFunction.MessageHash = messageHash;
                ovmCREATEEOAFunction.V = v;
                ovmCREATEEOAFunction.R = r;
                ovmCREATEEOAFunction.S = s;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmCREATEEOAFunction, cancellationToken);
        }

        public Task<string> OvmDELEGATECALLRequestAsync(OvmDELEGATECALLFunction ovmDELEGATECALLFunction)
        {
             return ContractHandler.SendRequestAsync(ovmDELEGATECALLFunction);
        }

        public Task<TransactionReceipt> OvmDELEGATECALLRequestAndWaitForReceiptAsync(OvmDELEGATECALLFunction ovmDELEGATECALLFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmDELEGATECALLFunction, cancellationToken);
        }

        public Task<string> OvmDELEGATECALLRequestAsync(BigInteger gasLimit, string address, byte[] calldata)
        {
            var ovmDELEGATECALLFunction = new OvmDELEGATECALLFunction();
                ovmDELEGATECALLFunction.GasLimit = gasLimit;
                ovmDELEGATECALLFunction.Address = address;
                ovmDELEGATECALLFunction.Calldata = calldata;
            
             return ContractHandler.SendRequestAsync(ovmDELEGATECALLFunction);
        }

        public Task<TransactionReceipt> OvmDELEGATECALLRequestAndWaitForReceiptAsync(BigInteger gasLimit, string address, byte[] calldata, CancellationTokenSource cancellationToken = null)
        {
            var ovmDELEGATECALLFunction = new OvmDELEGATECALLFunction();
                ovmDELEGATECALLFunction.GasLimit = gasLimit;
                ovmDELEGATECALLFunction.Address = address;
                ovmDELEGATECALLFunction.Calldata = calldata;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmDELEGATECALLFunction, cancellationToken);
        }

        public Task<string> OvmEXTCODECOPYRequestAsync(OvmEXTCODECOPYFunction ovmEXTCODECOPYFunction)
        {
             return ContractHandler.SendRequestAsync(ovmEXTCODECOPYFunction);
        }

        public Task<TransactionReceipt> OvmEXTCODECOPYRequestAndWaitForReceiptAsync(OvmEXTCODECOPYFunction ovmEXTCODECOPYFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmEXTCODECOPYFunction, cancellationToken);
        }

        public Task<string> OvmEXTCODECOPYRequestAsync(string contract, BigInteger offset, BigInteger length)
        {
            var ovmEXTCODECOPYFunction = new OvmEXTCODECOPYFunction();
                ovmEXTCODECOPYFunction.Contract = contract;
                ovmEXTCODECOPYFunction.Offset = offset;
                ovmEXTCODECOPYFunction.Length = length;
            
             return ContractHandler.SendRequestAsync(ovmEXTCODECOPYFunction);
        }

        public Task<TransactionReceipt> OvmEXTCODECOPYRequestAndWaitForReceiptAsync(string contract, BigInteger offset, BigInteger length, CancellationTokenSource cancellationToken = null)
        {
            var ovmEXTCODECOPYFunction = new OvmEXTCODECOPYFunction();
                ovmEXTCODECOPYFunction.Contract = contract;
                ovmEXTCODECOPYFunction.Offset = offset;
                ovmEXTCODECOPYFunction.Length = length;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmEXTCODECOPYFunction, cancellationToken);
        }

        public Task<string> OvmEXTCODEHASHRequestAsync(OvmEXTCODEHASHFunction ovmEXTCODEHASHFunction)
        {
             return ContractHandler.SendRequestAsync(ovmEXTCODEHASHFunction);
        }

        public Task<TransactionReceipt> OvmEXTCODEHASHRequestAndWaitForReceiptAsync(OvmEXTCODEHASHFunction ovmEXTCODEHASHFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmEXTCODEHASHFunction, cancellationToken);
        }

        public Task<string> OvmEXTCODEHASHRequestAsync(string contract)
        {
            var ovmEXTCODEHASHFunction = new OvmEXTCODEHASHFunction();
                ovmEXTCODEHASHFunction.Contract = contract;
            
             return ContractHandler.SendRequestAsync(ovmEXTCODEHASHFunction);
        }

        public Task<TransactionReceipt> OvmEXTCODEHASHRequestAndWaitForReceiptAsync(string contract, CancellationTokenSource cancellationToken = null)
        {
            var ovmEXTCODEHASHFunction = new OvmEXTCODEHASHFunction();
                ovmEXTCODEHASHFunction.Contract = contract;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmEXTCODEHASHFunction, cancellationToken);
        }

        public Task<string> OvmEXTCODESIZERequestAsync(OvmEXTCODESIZEFunction ovmEXTCODESIZEFunction)
        {
             return ContractHandler.SendRequestAsync(ovmEXTCODESIZEFunction);
        }

        public Task<TransactionReceipt> OvmEXTCODESIZERequestAndWaitForReceiptAsync(OvmEXTCODESIZEFunction ovmEXTCODESIZEFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmEXTCODESIZEFunction, cancellationToken);
        }

        public Task<string> OvmEXTCODESIZERequestAsync(string contract)
        {
            var ovmEXTCODESIZEFunction = new OvmEXTCODESIZEFunction();
                ovmEXTCODESIZEFunction.Contract = contract;
            
             return ContractHandler.SendRequestAsync(ovmEXTCODESIZEFunction);
        }

        public Task<TransactionReceipt> OvmEXTCODESIZERequestAndWaitForReceiptAsync(string contract, CancellationTokenSource cancellationToken = null)
        {
            var ovmEXTCODESIZEFunction = new OvmEXTCODESIZEFunction();
                ovmEXTCODESIZEFunction.Contract = contract;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmEXTCODESIZEFunction, cancellationToken);
        }

        public Task<BigInteger> OvmGASLIMITQueryAsync(OvmGASLIMITFunction ovmGASLIMITFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmGASLIMITFunction, BigInteger>(ovmGASLIMITFunction, blockParameter);
        }

        
        public Task<BigInteger> OvmGASLIMITQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmGASLIMITFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> OvmGETNONCERequestAsync(OvmGETNONCEFunction ovmGETNONCEFunction)
        {
             return ContractHandler.SendRequestAsync(ovmGETNONCEFunction);
        }

        public Task<string> OvmGETNONCERequestAsync()
        {
             return ContractHandler.SendRequestAsync<OvmGETNONCEFunction>();
        }

        public Task<TransactionReceipt> OvmGETNONCERequestAndWaitForReceiptAsync(OvmGETNONCEFunction ovmGETNONCEFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmGETNONCEFunction, cancellationToken);
        }

        public Task<TransactionReceipt> OvmGETNONCERequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<OvmGETNONCEFunction>(null, cancellationToken);
        }

        public Task<string> OvmINCREMENTNONCERequestAsync(OvmINCREMENTNONCEFunction ovmINCREMENTNONCEFunction)
        {
             return ContractHandler.SendRequestAsync(ovmINCREMENTNONCEFunction);
        }

        public Task<string> OvmINCREMENTNONCERequestAsync()
        {
             return ContractHandler.SendRequestAsync<OvmINCREMENTNONCEFunction>();
        }

        public Task<TransactionReceipt> OvmINCREMENTNONCERequestAndWaitForReceiptAsync(OvmINCREMENTNONCEFunction ovmINCREMENTNONCEFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmINCREMENTNONCEFunction, cancellationToken);
        }

        public Task<TransactionReceipt> OvmINCREMENTNONCERequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<OvmINCREMENTNONCEFunction>(null, cancellationToken);
        }

        public Task<byte> OvmL1QUEUEORIGINQueryAsync(OvmL1QUEUEORIGINFunction ovmL1QUEUEORIGINFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmL1QUEUEORIGINFunction, byte>(ovmL1QUEUEORIGINFunction, blockParameter);
        }

        
        public Task<byte> OvmL1QUEUEORIGINQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmL1QUEUEORIGINFunction, byte>(null, blockParameter);
        }

        public Task<string> OvmL1TXORIGINQueryAsync(OvmL1TXORIGINFunction ovmL1TXORIGINFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmL1TXORIGINFunction, string>(ovmL1TXORIGINFunction, blockParameter);
        }

        
        public Task<string> OvmL1TXORIGINQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmL1TXORIGINFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> OvmNUMBERQueryAsync(OvmNUMBERFunction ovmNUMBERFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmNUMBERFunction, BigInteger>(ovmNUMBERFunction, blockParameter);
        }

        
        public Task<BigInteger> OvmNUMBERQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmNUMBERFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> OvmREVERTRequestAsync(OvmREVERTFunction ovmREVERTFunction)
        {
             return ContractHandler.SendRequestAsync(ovmREVERTFunction);
        }

        public Task<TransactionReceipt> OvmREVERTRequestAndWaitForReceiptAsync(OvmREVERTFunction ovmREVERTFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmREVERTFunction, cancellationToken);
        }

        public Task<string> OvmREVERTRequestAsync(byte[] data)
        {
            var ovmREVERTFunction = new OvmREVERTFunction();
                ovmREVERTFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(ovmREVERTFunction);
        }

        public Task<TransactionReceipt> OvmREVERTRequestAndWaitForReceiptAsync(byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var ovmREVERTFunction = new OvmREVERTFunction();
                ovmREVERTFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmREVERTFunction, cancellationToken);
        }

        public Task<string> OvmSLOADRequestAsync(OvmSLOADFunction ovmSLOADFunction)
        {
             return ContractHandler.SendRequestAsync(ovmSLOADFunction);
        }

        public Task<TransactionReceipt> OvmSLOADRequestAndWaitForReceiptAsync(OvmSLOADFunction ovmSLOADFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmSLOADFunction, cancellationToken);
        }

        public Task<string> OvmSLOADRequestAsync(byte[] key)
        {
            var ovmSLOADFunction = new OvmSLOADFunction();
                ovmSLOADFunction.Key = key;
            
             return ContractHandler.SendRequestAsync(ovmSLOADFunction);
        }

        public Task<TransactionReceipt> OvmSLOADRequestAndWaitForReceiptAsync(byte[] key, CancellationTokenSource cancellationToken = null)
        {
            var ovmSLOADFunction = new OvmSLOADFunction();
                ovmSLOADFunction.Key = key;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmSLOADFunction, cancellationToken);
        }

        public Task<string> OvmSSTORERequestAsync(OvmSSTOREFunction ovmSSTOREFunction)
        {
             return ContractHandler.SendRequestAsync(ovmSSTOREFunction);
        }

        public Task<TransactionReceipt> OvmSSTORERequestAndWaitForReceiptAsync(OvmSSTOREFunction ovmSSTOREFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmSSTOREFunction, cancellationToken);
        }

        public Task<string> OvmSSTORERequestAsync(byte[] key, byte[] value)
        {
            var ovmSSTOREFunction = new OvmSSTOREFunction();
                ovmSSTOREFunction.Key = key;
                ovmSSTOREFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(ovmSSTOREFunction);
        }

        public Task<TransactionReceipt> OvmSSTORERequestAndWaitForReceiptAsync(byte[] key, byte[] value, CancellationTokenSource cancellationToken = null)
        {
            var ovmSSTOREFunction = new OvmSSTOREFunction();
                ovmSSTOREFunction.Key = key;
                ovmSSTOREFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmSSTOREFunction, cancellationToken);
        }

        public Task<string> OvmSTATICCALLRequestAsync(OvmSTATICCALLFunction ovmSTATICCALLFunction)
        {
             return ContractHandler.SendRequestAsync(ovmSTATICCALLFunction);
        }

        public Task<TransactionReceipt> OvmSTATICCALLRequestAndWaitForReceiptAsync(OvmSTATICCALLFunction ovmSTATICCALLFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmSTATICCALLFunction, cancellationToken);
        }

        public Task<string> OvmSTATICCALLRequestAsync(BigInteger gasLimit, string address, byte[] calldata)
        {
            var ovmSTATICCALLFunction = new OvmSTATICCALLFunction();
                ovmSTATICCALLFunction.GasLimit = gasLimit;
                ovmSTATICCALLFunction.Address = address;
                ovmSTATICCALLFunction.Calldata = calldata;
            
             return ContractHandler.SendRequestAsync(ovmSTATICCALLFunction);
        }

        public Task<TransactionReceipt> OvmSTATICCALLRequestAndWaitForReceiptAsync(BigInteger gasLimit, string address, byte[] calldata, CancellationTokenSource cancellationToken = null)
        {
            var ovmSTATICCALLFunction = new OvmSTATICCALLFunction();
                ovmSTATICCALLFunction.GasLimit = gasLimit;
                ovmSTATICCALLFunction.Address = address;
                ovmSTATICCALLFunction.Calldata = calldata;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ovmSTATICCALLFunction, cancellationToken);
        }

        public Task<BigInteger> OvmTIMESTAMPQueryAsync(OvmTIMESTAMPFunction ovmTIMESTAMPFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmTIMESTAMPFunction, BigInteger>(ovmTIMESTAMPFunction, blockParameter);
        }

        
        public Task<BigInteger> OvmTIMESTAMPQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OvmTIMESTAMPFunction, BigInteger>(null, blockParameter);
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

        public Task<string> RunRequestAsync(RunFunction runFunction)
        {
             return ContractHandler.SendRequestAsync(runFunction);
        }

        public Task<TransactionReceipt> RunRequestAndWaitForReceiptAsync(RunFunction runFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(runFunction, cancellationToken);
        }

        public Task<string> RunRequestAsync(OvmTransaction transaction, string ovmStateManager)
        {
            var runFunction = new RunFunction();
                runFunction.Transaction = transaction;
                runFunction.OvmStateManager = ovmStateManager;
            
             return ContractHandler.SendRequestAsync(runFunction);
        }

        public Task<TransactionReceipt> RunRequestAndWaitForReceiptAsync(OvmTransaction transaction, string ovmStateManager, CancellationTokenSource cancellationToken = null)
        {
            var runFunction = new RunFunction();
                runFunction.Transaction = transaction;
                runFunction.OvmStateManager = ovmStateManager;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(runFunction, cancellationToken);
        }

        public Task<string> SimulateMessageRequestAsync(SimulateMessageFunction simulateMessageFunction)
        {
             return ContractHandler.SendRequestAsync(simulateMessageFunction);
        }

        public Task<TransactionReceipt> SimulateMessageRequestAndWaitForReceiptAsync(SimulateMessageFunction simulateMessageFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(simulateMessageFunction, cancellationToken);
        }

        public Task<string> SimulateMessageRequestAsync(OvmTransaction transaction, string from, string ovmStateManager)
        {
            var simulateMessageFunction = new SimulateMessageFunction();
                simulateMessageFunction.Transaction = transaction;
                simulateMessageFunction.From = from;
                simulateMessageFunction.OvmStateManager = ovmStateManager;
            
             return ContractHandler.SendRequestAsync(simulateMessageFunction);
        }

        public Task<TransactionReceipt> SimulateMessageRequestAndWaitForReceiptAsync(OvmTransaction transaction, string from, string ovmStateManager, CancellationTokenSource cancellationToken = null)
        {
            var simulateMessageFunction = new SimulateMessageFunction();
                simulateMessageFunction.Transaction = transaction;
                simulateMessageFunction.From = from;
                simulateMessageFunction.OvmStateManager = ovmStateManager;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(simulateMessageFunction, cancellationToken);
        }
    }
}
