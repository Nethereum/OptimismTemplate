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

namespace OptimismTemplate.Contracts.SimpleStorageL2.ContractDefinition
{


    public partial class SimpleStorageL2Deployment : SimpleStorageL2DeploymentBase
    {
        public SimpleStorageL2Deployment() : base(BYTECODE) { }
        public SimpleStorageL2Deployment(string byteCode) : base(byteCode) { }
    }

    public class SimpleStorageL2DeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040523480156100195760008061001661001f565b50505b5061008a565b632a2a7adb598160e01b8152600481016020815285602082015260005b8681101561005757808601518282016040015260200161003c565b506020828760640184336000905af158600e01573d6000803e3d6000fd5b3d6001141558600a015760016000f35b505050565b61053d806100996000396000f3fe6080604052348015610019576000806100166102a5565b50505b506004361061006b5760003560e01c80631034f4bf1461007957806334eafb11146100a15780633fa4f245146100bb57806358825b10146100c3578063674df712146100e9578063d737d0c71461010d575b6000806100766102a5565b50505b61009f60048036036020811015610098576000806100956102a5565b50505b5035610115565b005b6100a9610127565b60405190815260200160405180910390f35b6100a9610134565b61009f600480360360208110156100e2576000806100df6102a5565b50505b503561013e565b6100f161027b565b6040516001600160a01b03909116815260200160405180910390f35b6100f161029a565b80806002610121610310565b50505050565b6003610131610372565b81565b6002610131610372565b5a6101476103be565b6000600181610154610372565b816001600160a01b0302191690836001600160a01b0316021790610176610310565b5050505a6101826103be565b6001600160a01b0316636e296e456040518163ffffffff1660e01b815260040160206040518083038186806101b5610404565b1580156101ca576000806101c76102a5565b50505b505a6101d4610450565b50505050501580156101f3573d6000803e3d60006101f06102a5565b50505b505050506040513d60208110156102125760008061020f6102a5565b50505b8101908080519250600191508190508061022a610372565b816001600160a01b0302191690836001600160a01b031602179061024c610310565b505050806002819061025c610310565b505050600360008161026c610372565b91600183019150610121610310565b60006001610287610372565b906101000a90046001600160a01b031681565b600080610287610372565b632a2a7adb598160e01b8152600481016020815285602082015260005b868110156102dd5780860151828201604001526020016102c2565b506020828760640184336000905af158600e01573d6000803e3d6000fd5b3d6001141558600a015760016000f35b505050565b6322bd64c0598160e01b8152836004820152846024820152600081604483336000905af158600e01573d6000803e3d6000fd5b3d6001141558600a015760016000f35b60005b604081101561036d57600082820152602001610356565b505050565b6303daa959598160e01b8152836004820152602081602483336000905af158600e01573d6000803e3d6000fd5b3d6001141558600a015760016000f35b80516000825293506020610356565b6373509064598160e01b8152602081600483336000905af158600e01573d6000803e3d6000fd5b3d6001141558600a015760016000f35b80516000825293506020610356565b638435035b598160e01b8152836004820152602081602483336000905af158600e01573d6000803e3d6000fd5b3d6001141558600a015760016000f35b80516000825293506020610356565b638540661f598160e01b8152610483565b808083111561046d5750815b92915050565b808083101561046d575090919050565b836004820152846024820152606060448201528660648201526084810160005b888110156104bb5780880151828201526020016104a3565b506060828960a40184336000905af158600e01573d6000803e3d6000fd5b3d6001141558600a015760016000f35b815160408301513d6000853e8b8b82606087013350600060045af150596105108d3d610473565b8c0161051c8187610461565b5b82811015610531576000815260200161051d565b50929c5050505050505056";
        public SimpleStorageL2DeploymentBase() : base(BYTECODE) { }
        public SimpleStorageL2DeploymentBase(string byteCode) : base(byteCode) { }

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
