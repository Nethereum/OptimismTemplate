using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Optimism.Contracts.OVM.Verification.OVM_StateTransitioner.ContractDefinition
{
    public partial class OvmTransaction : TransactionBase { }

    public class TransactionBase 
    {
        [Parameter("uint256", "timestamp", 1)]
        public virtual BigInteger Timestamp { get; set; }
        [Parameter("uint256", "blockNumber", 2)]
        public virtual BigInteger BlockNumber { get; set; }
        [Parameter("uint8", "l1QueueOrigin", 3)]
        public virtual byte L1QueueOrigin { get; set; }
        [Parameter("address", "l1TxOrigin", 4)]
        public virtual string L1TxOrigin { get; set; }
        [Parameter("address", "entrypoint", 5)]
        public virtual string Entrypoint { get; set; }
        [Parameter("uint256", "gasLimit", 6)]
        public virtual BigInteger GasLimit { get; set; }
        [Parameter("bytes", "data", 7)]
        public virtual byte[] Data { get; set; }
    }
}
