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

namespace OptimismTemplate.Contracts.ERC20.ContractDefinition
{


    public partial class ERC20Deployment : ERC20DeploymentBase
    {
        public ERC20Deployment() : base(BYTECODE) { }
        public ERC20Deployment(string byteCode) : base(byteCode) { }
    }

    public class ERC20DeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60a06040523480156200001157600080fd5b506040516200096a3803806200096a8339810160408190526200003491620001f9565b60ff841660805282516200005090600090602086019062000086565b5081516200006690600190602085019062000086565b5033600090815260036020526040902081905560025550620002c2915050565b828054620000949062000285565b90600052602060002090601f016020900481019282620000b8576000855562000103565b82601f10620000d357805160ff191683800117855562000103565b8280016001018555821562000103579182015b8281111562000103578251825591602001919060010190620000e6565b506200011192915062000115565b5090565b5b8082111562000111576000815560010162000116565b634e487b7160e01b600052604160045260246000fd5b600082601f8301126200015457600080fd5b81516001600160401b03808211156200017157620001716200012c565b604051601f8301601f19908116603f011681019082821181831017156200019c576200019c6200012c565b81604052838152602092508683858801011115620001b957600080fd5b600091505b83821015620001dd5785820183015181830184015290820190620001be565b83821115620001ef5760008385830101525b9695505050505050565b600080600080608085870312156200021057600080fd5b845160ff811681146200022257600080fd5b60208601519094506001600160401b03808211156200024057600080fd5b6200024e8883890162000142565b945060408701519150808211156200026557600080fd5b50620002748782880162000142565b606096909601519497939650505050565b600181811c908216806200029a57607f821691505b60208210811415620002bc57634e487b7160e01b600052602260045260246000fd5b50919050565b60805161068c620002de6000396000610108015261068c6000f3fe608060405234801561001057600080fd5b50600436106100935760003560e01c8063313ce56711610066578063313ce5671461010357806370a082311461013c57806395d89b411461015c578063a9059cbb14610164578063dd62ed3e1461017757600080fd5b806306fdde0314610098578063095ea7b3146100b657806318160ddd146100d957806323b872dd146100f0575b600080fd5b6100a06101a2565b6040516100ad91906104aa565b60405180910390f35b6100c96100c436600461051b565b610230565b60405190151581526020016100ad565b6100e260025481565b6040519081526020016100ad565b6100c96100fe366004610545565b610247565b61012a7f000000000000000000000000000000000000000000000000000000000000000081565b60405160ff90911681526020016100ad565b6100e261014a366004610581565b60036020526000908152604090205481565b6100a06102d8565b6100c961017236600461051b565b6102e5565b6100e26101853660046105a3565b600460209081526000928352604080842090915290825290205481565b600080546101af906105d6565b80601f01602080910402602001604051908101604052809291908181526020018280546101db906105d6565b80156102285780601f106101fd57610100808354040283529160200191610228565b820191906000526020600020905b81548152906001019060200180831161020b57829003601f168201915b505050505081565b600061023d3384846102f2565b5060015b92915050565b6001600160a01b0383166000908152600460209081526040808320338452909152812054156102c3576001600160a01b038416600090815260046020908152604080832033845290915290205461029e9083610354565b6001600160a01b03851660009081526004602090815260408083203384529091529020555b6102ce8484846103af565b5060019392505050565b600180546101af906105d6565b600061023d3384846103af565b6001600160a01b0383811660008181526004602090815260408083209487168084529482529182902085905590518481527f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b92591015b60405180910390a3505050565b6000826103618382610627565b91508111156102415760405162461bcd60e51b815260206004820152601560248201527464732d6d6174682d7375622d756e646572666c6f7760581b60448201526064015b60405180910390fd5b6001600160a01b0383166000908152600360205260409020546103d29082610354565b6001600160a01b0380851660009081526003602052604080822093909355908416815220546104019082610455565b6001600160a01b0380841660008181526003602052604090819020939093559151908516907fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef906103479085815260200190565b600082610462838261063e565b91508110156102415760405162461bcd60e51b815260206004820152601460248201527364732d6d6174682d6164642d6f766572666c6f7760601b60448201526064016103a6565b600060208083528351808285015260005b818110156104d7578581018301518582016040015282016104bb565b818111156104e9576000604083870101525b50601f01601f1916929092016040019392505050565b80356001600160a01b038116811461051657600080fd5b919050565b6000806040838503121561052e57600080fd5b610537836104ff565b946020939093013593505050565b60008060006060848603121561055a57600080fd5b610563846104ff565b9250610571602085016104ff565b9150604084013590509250925092565b60006020828403121561059357600080fd5b61059c826104ff565b9392505050565b600080604083850312156105b657600080fd5b6105bf836104ff565b91506105cd602084016104ff565b90509250929050565b600181811c908216806105ea57607f821691505b6020821081141561060b57634e487b7160e01b600052602260045260246000fd5b50919050565b634e487b7160e01b600052601160045260246000fd5b60008282101561063957610639610611565b500390565b6000821982111561065157610651610611565b50019056fea26469706673582212209f70bcd0d53c0f69b7cb4157be39fbd25be831183444db5068efe37c36cbd09d64736f6c634300080c0033";
        public ERC20DeploymentBase() : base(BYTECODE) { }
        public ERC20DeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("uint8", "_decimals", 1)]
        public virtual byte Decimals { get; set; }
        [Parameter("string", "_name", 2)]
        public virtual string Name { get; set; }
        [Parameter("string", "_symbol", 3)]
        public virtual string Symbol { get; set; }
        [Parameter("uint256", "_initialSupply", 4)]
        public virtual BigInteger InitialSupply { get; set; }
    }

    public partial class AllowanceFunction : AllowanceFunctionBase { }

    [Function("allowance", "uint256")]
    public class AllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("address", "", 2)]
        public virtual string ReturnValue2 { get; set; }
    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve", "bool")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "value", 2)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class DecimalsFunction : DecimalsFunctionBase { }

    [Function("decimals", "uint8")]
    public class DecimalsFunctionBase : FunctionMessage
    {

    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }

    public partial class TransferFunction : TransferFunctionBase { }

    [Function("transfer", "bool")]
    public class TransferFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 2)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom", "bool")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 3)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2, true )]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class AllowanceOutputDTO : AllowanceOutputDTOBase { }

    [FunctionOutput]
    public class AllowanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class DecimalsOutputDTO : DecimalsOutputDTOBase { }

    [FunctionOutput]
    public class DecimalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }




}
