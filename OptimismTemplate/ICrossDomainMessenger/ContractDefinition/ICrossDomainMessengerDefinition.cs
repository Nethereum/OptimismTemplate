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

namespace OptimismTemplate.Contracts.ICrossDomainMessenger.ContractDefinition
{


    public partial class ICrossDomainMessengerDeployment : ICrossDomainMessengerDeploymentBase
    {
        public ICrossDomainMessengerDeployment() : base(BYTECODE) { }
        public ICrossDomainMessengerDeployment(string byteCode) : base(byteCode) { }
    }

    public class ICrossDomainMessengerDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6080604052348015600f57600080fd5b5060948061001e6000396000f3fe6080604052348015600f57600080fd5b506004361060285760003560e01c80636e296e4514602d575b600080fd5b6033604f565b604080516001600160a01b039092168252519081900360200190f35b6000546001600160a01b03168156fea264697066735822122077dc96bbe1c0ec67aabe46f9a2d2d49452d17ff440c4cc76bca859a469946eda64736f6c63430007060033";
        public ICrossDomainMessengerDeploymentBase() : base(BYTECODE) { }
        public ICrossDomainMessengerDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class XDomainMessageSenderFunction : XDomainMessageSenderFunctionBase { }

    [Function("xDomainMessageSender", "address")]
    public class XDomainMessageSenderFunctionBase : FunctionMessage
    {

    }

    public partial class XDomainMessageSenderOutputDTO : XDomainMessageSenderOutputDTOBase { }

    [FunctionOutput]
    public class XDomainMessageSenderOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
