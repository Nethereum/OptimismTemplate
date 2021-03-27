using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Optimism.Contracts.OVM.Verification.OVM_FraudVerifier.ContractDefinition
{
    public partial class TransactionChainElement : TransactionChainElementBase { }

    public class TransactionChainElementBase 
    {
        [Parameter("bool", "isSequenced", 1)]
        public virtual bool IsSequenced { get; set; }
        [Parameter("uint256", "queueIndex", 2)]
        public virtual BigInteger QueueIndex { get; set; }
        [Parameter("uint256", "timestamp", 3)]
        public virtual BigInteger Timestamp { get; set; }
        [Parameter("uint256", "blockNumber", 4)]
        public virtual BigInteger BlockNumber { get; set; }
        [Parameter("bytes", "txData", 5)]
        public virtual byte[] TxData { get; set; }
    }
}
