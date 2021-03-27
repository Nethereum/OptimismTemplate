using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Optimism.Contracts.OVM.Execution.OVM_ExecutionManager.ContractDefinition
{
    public partial class GlobalContext : GlobalContextBase { }

    public class GlobalContextBase 
    {
        [Parameter("uint256", "ovmCHAINID", 1)]
        public virtual BigInteger OvmCHAINID { get; set; }
    }
}
