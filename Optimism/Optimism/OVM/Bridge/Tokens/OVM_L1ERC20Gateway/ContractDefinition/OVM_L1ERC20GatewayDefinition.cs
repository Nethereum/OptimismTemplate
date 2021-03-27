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

namespace Optimism.Contracts.OVM.Bridge.Tokens.OVM_L1ERC20Gateway.ContractDefinition
{


    public partial class OVM_L1ERC20GatewayDeployment : OVM_L1ERC20GatewayDeploymentBase
    {
        public OVM_L1ERC20GatewayDeployment() : base(BYTECODE) { }
        public OVM_L1ERC20GatewayDeployment(string byteCode) : base(byteCode) { }
    }

    public class OVM_L1ERC20GatewayDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040526001805463ffffffff60a01b191661249f60a71b17905534801561002757600080fd5b5060405161083438038061083483398101604081905261004691610089565b600080546001600160a01b03199081166001600160a01b0393841617909155600180548216938316939093179092556002805490921692169190911790556100ed565b60008060006060848603121561009d578283fd5b83516100a8816100d5565b60208501519093506100b9816100d5565b60408501519092506100ca816100d5565b809150509250925092565b6001600160a01b03811681146100ea57600080fd5b50565b610738806100fc6000396000f3fe608060405234801561001057600080fd5b50600436106100885760003560e01c80639423169b1161005b5780639423169b146100d0578063b6b55f25146100d8578063f4f7b41a146100ed578063ffaad6a51461010057610088565b80630439f40b1461008d5780631273a090146100ab57806332b5e32e146100c05780633cb747bf146100c8575b600080fd5b610095610113565b6040516100a29190610639565b60405180910390f35b6100b3610122565b6040516100a29190610693565b610095610135565b610095610144565b6100b3610153565b6100eb6100e6366004610621565b610166565b005b6100eb6100fb3660046105c4565b610174565b6100eb61010e3660046105c4565b6102e2565b6001546001600160a01b031681565b600154600160a01b900463ffffffff1690565b6002546001600160a01b031681565b6000546001600160a01b031681565b600154600160a01b900463ffffffff1681565b6101713333836102f1565b50565b6001546001600160a01b03166101886103b5565b6001600160a01b0316336001600160a01b0316146101d75760405162461bcd60e51b815260040180806020018281038252602e8152602001806106a5602e913960400191505060405180910390fd5b806001600160a01b03166101e96103b5565b6001600160a01b0316636e296e456040518163ffffffff1660e01b815260040160206040518083038186803b15801561022157600080fd5b505afa158015610235573d6000803e3d6000fd5b505050506040513d602081101561024b57600080fd5b50516001600160a01b0316146102925760405162461bcd60e51b81526004018080602001828103825260308152602001806106d36030913960400191505060405180910390fd5b61029c83836103c4565b826001600160a01b03167f9e5c4f9f4e46b8629d3dda85f43a69194f50254404a72dc62b9e932d9c94eda8836040516102d5919061068a565b60405180910390a2505050565b6102ed3383836102f1565b5050565b6102fc83838361044d565b6000638d6e9a5b60e01b8383604051602401610319929190610671565b60408051601f198184030181529190526020810180516001600160e01b03166001600160e01b03199093169290921790915260015490915061036c906001600160a01b031682610367610122565b6104d9565b836001600160a01b03167ff531653a5819e21265de50358610d55dbe6594c61605b209dfa4280d277938c184846040516103a7929190610671565b60405180910390a250505050565b6000546001600160a01b031690565b60025460405163a9059cbb60e01b81526001600160a01b039091169063a9059cbb906103f69085908590600401610671565b602060405180830381600087803b15801561041057600080fd5b505af1158015610424573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061044891906105fa565b505050565b6002546040516323b872dd60e01b81526001600160a01b03909116906323b872dd906104819086903090869060040161064d565b602060405180830381600087803b15801561049b57600080fd5b505af11580156104af573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906104d391906105fa565b50505050565b6104e16103b5565b6001600160a01b0316633dbb202b8484846040518463ffffffff1660e01b815260040180846001600160a01b03168152602001806020018363ffffffff168152602001828103825284818151815260200191508051906020019080838360005b83811015610559578181015183820152602001610541565b50505050905090810190601f1680156105865780820380516001836020036101000a031916815260200191505b50945050505050600060405180830381600087803b1580156105a757600080fd5b505af11580156105bb573d6000803e3d6000fd5b50505050505050565b600080604083850312156105d6578182fd5b82356001600160a01b03811681146105ec578283fd5b946020939093013593505050565b60006020828403121561060b578081fd5b8151801515811461061a578182fd5b9392505050565b600060208284031215610632578081fd5b5035919050565b6001600160a01b0391909116815260200190565b6001600160a01b039384168152919092166020820152604081019190915260600190565b6001600160a01b03929092168252602082015260400190565b90815260200190565b63ffffffff9190911681526020019056fe4f564d5f58434841494e3a206d657373656e67657220636f6e747261637420756e61757468656e746963617465644f564d5f58434841494e3a2077726f6e672073656e646572206f662063726f73732d646f6d61696e206d657373616765a2646970667358221220301dab63e3c283ea06e11107c15a7bab572cb394759aa621bc80cd207da509f764736f6c63430007060033";
        public OVM_L1ERC20GatewayDeploymentBase() : base(BYTECODE) { }
        public OVM_L1ERC20GatewayDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_l1ERC20", 1)]
        public virtual string L1ERC20 { get; set; }
        [Parameter("address", "_l2DepositedERC20", 2)]
        public virtual string L2DepositedERC20 { get; set; }
        [Parameter("address", "_l1messenger", 3)]
        public virtual string L1messenger { get; set; }
    }

    public partial class DEFAULT_FINALIZE_DEPOSIT_L2_GASFunction : DEFAULT_FINALIZE_DEPOSIT_L2_GASFunctionBase { }

    [Function("DEFAULT_FINALIZE_DEPOSIT_L2_GAS", "uint32")]
    public class DEFAULT_FINALIZE_DEPOSIT_L2_GASFunctionBase : FunctionMessage
    {

    }

    public partial class DepositFunction : DepositFunctionBase { }

    [Function("deposit")]
    public class DepositFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class DepositToFunction : DepositToFunctionBase { }

    [Function("depositTo")]
    public class DepositToFunctionBase : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class FinalizeWithdrawalFunction : FinalizeWithdrawalFunctionBase { }

    [Function("finalizeWithdrawal")]
    public class FinalizeWithdrawalFunctionBase : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class GetFinalizeDepositL2GasFunction : GetFinalizeDepositL2GasFunctionBase { }

    [Function("getFinalizeDepositL2Gas", "uint32")]
    public class GetFinalizeDepositL2GasFunctionBase : FunctionMessage
    {

    }

    public partial class L1ERC20Function : L1ERC20FunctionBase { }

    [Function("l1ERC20", "address")]
    public class L1ERC20FunctionBase : FunctionMessage
    {

    }

    public partial class L2DepositedTokenFunction : L2DepositedTokenFunctionBase { }

    [Function("l2DepositedToken", "address")]
    public class L2DepositedTokenFunctionBase : FunctionMessage
    {

    }

    public partial class MessengerFunction : MessengerFunctionBase { }

    [Function("messenger", "address")]
    public class MessengerFunctionBase : FunctionMessage
    {

    }

    public partial class DepositInitiatedEventDTO : DepositInitiatedEventDTOBase { }

    [Event("DepositInitiated")]
    public class DepositInitiatedEventDTOBase : IEventDTO
    {
        [Parameter("address", "_from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "_to", 2, false )]
        public virtual string To { get; set; }
        [Parameter("uint256", "_amount", 3, false )]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class WithdrawalFinalizedEventDTO : WithdrawalFinalizedEventDTOBase { }

    [Event("WithdrawalFinalized")]
    public class WithdrawalFinalizedEventDTOBase : IEventDTO
    {
        [Parameter("address", "_to", 1, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "_amount", 2, false )]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class DEFAULT_FINALIZE_DEPOSIT_L2_GASOutputDTO : DEFAULT_FINALIZE_DEPOSIT_L2_GASOutputDTOBase { }

    [FunctionOutput]
    public class DEFAULT_FINALIZE_DEPOSIT_L2_GASOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint32", "", 1)]
        public virtual uint ReturnValue1 { get; set; }
    }







    public partial class GetFinalizeDepositL2GasOutputDTO : GetFinalizeDepositL2GasOutputDTOBase { }

    [FunctionOutput]
    public class GetFinalizeDepositL2GasOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint32", "", 1)]
        public virtual uint ReturnValue1 { get; set; }
    }

    public partial class L1ERC20OutputDTO : L1ERC20OutputDTOBase { }

    [FunctionOutput]
    public class L1ERC20OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class L2DepositedTokenOutputDTO : L2DepositedTokenOutputDTOBase { }

    [FunctionOutput]
    public class L2DepositedTokenOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class MessengerOutputDTO : MessengerOutputDTOBase { }

    [FunctionOutput]
    public class MessengerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
