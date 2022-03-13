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
        public static string BYTECODE = "608060405234801561001057600080fd5b5060405161045538038061045583398101604081905261002f91610054565b600080546001600160a01b0319166001600160a01b0392909216919091179055610084565b60006020828403121561006657600080fd5b81516001600160a01b038116811461007d57600080fd5b9392505050565b6103c2806100936000396000f3fe608060405234801561001057600080fd5b50600436106100885760003560e01c806358825b101161005b57806358825b10146100f2578063674df712146101055780636ec970b114610118578063d737d0c71461012b57600080fd5b80631034f4bf1461008d57806334eafb11146100a25780633cb747bf146100be5780633fa4f245146100e9575b600080fd5b6100a061009b3660046101d6565b600355565b005b6100ab60045481565b6040519081526020015b60405180910390f35b6000546100d1906001600160a01b031681565b6040516001600160a01b0390911681526020016100b5565b6100ab60035481565b6100a06101003660046101d6565b61013e565b6002546100d1906001600160a01b031681565b6100a0610126366004610205565b61015b565b6001546100d1906001600160a01b031681565b600381905560048054906000610153836102f0565b919050555050565b61016683838361016b565b505050565b600054604051633dbb202b60e01b81526001600160a01b0390911690633dbb202b9061019f90869085908790600401610319565b600060405180830381600087803b1580156101b957600080fd5b505af11580156101cd573d6000803e3d6000fd5b50505050505050565b6000602082840312156101e857600080fd5b5035919050565b634e487b7160e01b600052604160045260246000fd5b60008060006060848603121561021a57600080fd5b83356001600160a01b038116811461023157600080fd5b9250602084013563ffffffff8116811461024a57600080fd5b9150604084013567ffffffffffffffff8082111561026757600080fd5b818601915086601f83011261027b57600080fd5b81358181111561028d5761028d6101ef565b604051601f8201601f19908116603f011681019083821181831017156102b5576102b56101ef565b816040528281528960208487010111156102ce57600080fd5b8260208601602083013760006020848301015280955050505050509250925092565b600060001982141561031257634e487b7160e01b600052601160045260246000fd5b5060010190565b60018060a01b038416815260006020606081840152845180606085015260005b8181101561035557868101830151858201608001528201610339565b81811115610367576000608083870101525b5063ffffffff9490941660408401525050601f91909101601f1916016080019291505056fea2646970667358221220c4b4bbfc213c3660e6a210eb62fa67eb4c8360ce5a95f7272881ece6f828627064736f6c634300080c0033";
        public SimpleStorageDeploymentBase() : base(BYTECODE) { }
        public SimpleStorageDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_crossDomainMessenger", 1)]
        public virtual string CrossDomainMessenger { get; set; }
    }

    public partial class DumbSetValueFunction : DumbSetValueFunctionBase { }

    [Function("dumbSetValue")]
    public class DumbSetValueFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "newValue", 1)]
        public virtual byte[] NewValue { get; set; }
    }

    public partial class MessengerFunction : MessengerFunctionBase { }

    [Function("messenger", "address")]
    public class MessengerFunctionBase : FunctionMessage
    {

    }

    public partial class MsgSenderFunction : MsgSenderFunctionBase { }

    [Function("msgSender", "address")]
    public class MsgSenderFunctionBase : FunctionMessage
    {

    }

    public partial class SendValueFunction : SendValueFunctionBase { }

    [Function("sendValue")]
    public class SendValueFunctionBase : FunctionMessage
    {
        [Parameter("address", "_crossDomainTarget", 1)]
        public virtual string CrossDomainTarget { get; set; }
        [Parameter("uint32", "_gasLimit", 2)]
        public virtual uint GasLimit { get; set; }
        [Parameter("bytes", "_message", 3)]
        public virtual byte[] Message { get; set; }
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



    public partial class MessengerOutputDTO : MessengerOutputDTOBase { }

    [FunctionOutput]
    public class MessengerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
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
