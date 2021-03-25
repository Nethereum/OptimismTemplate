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

namespace OptimismTemplate.Contracts.SimpleStorage.ContractDefinition
{


    public partial class SimpleStorageDeployment : SimpleStorageDeploymentBase
    {
        public SimpleStorageDeployment() : base(BYTECODE) { }
        public SimpleStorageDeployment(string byteCode) : base(byteCode) { }
    }

    public class SimpleStorageDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b506101fd806100206000396000f3fe608060405234801561001057600080fd5b50600436106100625760003560e01c80631034f4bf1461006757806334eafb11146100865780633fa4f245146100a057806358825b10146100a8578063674df712146100c5578063d737d0c7146100e9575b600080fd5b6100846004803603602081101561007d57600080fd5b50356100f1565b005b61008e6100f6565b60408051918252519081900360200190f35b61008e6100fc565b610084600480360360208110156100be57600080fd5b5035610102565b6100cd6101a9565b604080516001600160a01b039092168252519081900360200190f35b6100cd6101b8565b600255565b60035481565b60025481565b600080546001600160a01b0319163390811790915560408051636e296e4560e01b81529051636e296e4591600480820192602092909190829003018186803b15801561014d57600080fd5b505afa158015610161573d6000803e3d6000fd5b505050506040513d602081101561017757600080fd5b5051600180546001600160a01b0319166001600160a01b03909216919091178155600291909155600380549091019055565b6001546001600160a01b031681565b6000546001600160a01b03168156fea26469706673582212202907b378be1dc66fa74d45e75a6a4c746f71c89e825213bcbfb13fa4a95409c664736f6c63430007060033";
        public SimpleStorageDeploymentBase() : base(BYTECODE) { }
        public SimpleStorageDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class DumbSetValueFunction : DumbSetValueFunctionBase { }

    [Function("dumbSetValue")]
    public class DumbSetValueFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "newValue", 1)]
        public virtual byte[] NewValue { get; set; }
    }

    public partial class MsgSenderFunction : MsgSenderFunctionBase { }

    [Function("msgSender", "address")]
    public class MsgSenderFunctionBase : FunctionMessage
    {

    }

    public partial class SetValueFunction : SetValueFunctionBase { }

    [Function("setValue")]
    public class SetValueFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "newValue", 1)]
        public virtual byte[] NewValue { get; set; }
    }

    public partial class TotalCountFunction : TotalCountFunctionBase { }

    [Function("totalCount", "uint256")]
    public class TotalCountFunctionBase : FunctionMessage
    {

    }

    public partial class ValueFunction : ValueFunctionBase { }

    [Function("value", "bytes32")]
    public class ValueFunctionBase : FunctionMessage
    {

    }

    public partial class XDomainSenderFunction : XDomainSenderFunctionBase { }

    [Function("xDomainSender", "address")]
    public class XDomainSenderFunctionBase : FunctionMessage
    {

    }



    public partial class MsgSenderOutputDTO : MsgSenderOutputDTOBase { }

    [FunctionOutput]
    public class MsgSenderOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class TotalCountOutputDTO : TotalCountOutputDTOBase { }

    [FunctionOutput]
    public class TotalCountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ValueOutputDTO : ValueOutputDTOBase { }

    [FunctionOutput]
    public class ValueOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class XDomainSenderOutputDTO : XDomainSenderOutputDTOBase { }

    [FunctionOutput]
    public class XDomainSenderOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
