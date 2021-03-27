using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Optimism.Contracts.OVM.Predeploys.OVM_L2ToL1MessagePasser.ContractDefinition
{


    public partial class OVM_L2ToL1MessagePasserDeployment : OVM_L2ToL1MessagePasserDeploymentBase
    {
        public OVM_L2ToL1MessagePasserDeployment() : base(BYTECODE) { }
        public OVM_L2ToL1MessagePasserDeployment(string byteCode) : base(byteCode) { }
    }

    public class OVM_L2ToL1MessagePasserDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b5061020e806100206000396000f3fe608060405234801561001057600080fd5b50600436106100365760003560e01c806382e3702d1461003b578063cafa81dc1461006c575b600080fd5b6100586004803603602081101561005157600080fd5b5035610114565b604080519115158252519081900360200190f35b6101126004803603602081101561008257600080fd5b81019060208101813564010000000081111561009d57600080fd5b8201836020820111156100af57600080fd5b803590602001918460018302840111640100000000831117156100d157600080fd5b91908080601f016020809104026020016040519081016040528093929190818152602001838380828437600092019190915250929550610129945050505050565b005b60006020819052908152604090205460ff1681565b600160008083336040516020018083805190602001908083835b602083106101625780518252601f199092019160209182019101610143565b6001836020036101000a038019825116818451168082178552505050505050905001826001600160a01b031660601b81526014019250505060405160208183030381529060405280519060200120815260200190815260200160002060006101000a81548160ff0219169083151502179055505056fea264697066735822122031902db86eb16dfa4712b0d2e2a2cbc44b2a7dd34e0b2789501de4e24324dee664736f6c63430007060033";
        public OVM_L2ToL1MessagePasserDeploymentBase() : base(BYTECODE) { }
        public OVM_L2ToL1MessagePasserDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class PassMessageToL1Function : PassMessageToL1FunctionBase { }

    [Function("passMessageToL1")]
    public class PassMessageToL1FunctionBase : FunctionMessage
    {
        [Parameter("bytes", "_message", 1)]
        public virtual byte[] Message { get; set; }
    }

    public partial class SentMessagesFunction : SentMessagesFunctionBase { }

    [Function("sentMessages", "bool")]
    public class SentMessagesFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class L2ToL1MessageEventDTO : L2ToL1MessageEventDTOBase { }

    [Event("L2ToL1Message")]
    public class L2ToL1MessageEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "_nonce", 1, false )]
        public virtual BigInteger Nonce { get; set; }
        [Parameter("address", "_sender", 2, false )]
        public virtual string Sender { get; set; }
        [Parameter("bytes", "_data", 3, false )]
        public virtual byte[] Data { get; set; }
    }



    public partial class SentMessagesOutputDTO : SentMessagesOutputDTOBase { }

    [FunctionOutput]
    public class SentMessagesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }
}
