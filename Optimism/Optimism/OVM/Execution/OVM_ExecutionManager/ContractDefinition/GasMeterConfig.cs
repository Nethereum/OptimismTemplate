using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Optimism.Contracts.OVM.Execution.OVM_ExecutionManager.ContractDefinition
{
    public partial class GasMeterConfig : GasMeterConfigBase { }

    public class GasMeterConfigBase 
    {
        [Parameter("uint256", "minTransactionGasLimit", 1)]
        public virtual BigInteger MinTransactionGasLimit { get; set; }
        [Parameter("uint256", "maxTransactionGasLimit", 2)]
        public virtual BigInteger MaxTransactionGasLimit { get; set; }
        [Parameter("uint256", "maxGasPerQueuePerEpoch", 3)]
        public virtual BigInteger MaxGasPerQueuePerEpoch { get; set; }
        [Parameter("uint256", "secondsPerEpoch", 4)]
        public virtual BigInteger SecondsPerEpoch { get; set; }
    }
}
