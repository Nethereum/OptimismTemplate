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

namespace Optimism.Contracts.OVM.Bridge.Messaging.OVM_L1MultiMessageRelayer.ContractDefinition
{


    public partial class OVM_L1MultiMessageRelayerDeployment : OVM_L1MultiMessageRelayerDeploymentBase
    {
        public OVM_L1MultiMessageRelayerDeployment() : base(BYTECODE) { }
        public OVM_L1MultiMessageRelayerDeployment(string byteCode) : base(byteCode) { }
    }

    public class OVM_L1MultiMessageRelayerDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50604051610a22380380610a2283398101604081905261002f91610054565b600080546001600160a01b0319166001600160a01b0392909216919091179055610082565b600060208284031215610065578081fd5b81516001600160a01b038116811461007b578182fd5b9392505050565b610991806100916000396000f3fe608060405234801561001057600080fd5b50600436106100415760003560e01c806316e9cd9b14610046578063299ca4781461005b578063461a447814610079575b600080fd5b61005961005436600461057d565b61008c565b005b6100636101ea565b60405161007091906106db565b60405180910390f35b6100636100873660046105ec565b6101f9565b6100ca6040518060400160405280601981526020017f4f564d5f4c3242617463684d65737361676552656c61796572000000000000008152506101f9565b6001600160a01b0316336001600160a01b0316146101035760405162461bcd60e51b81526004016100fa906107d7565b60405180910390fd5b600061012660405180606001604052806021815260200161093b602191396101f9565b905060005b828110156101e457600084848381811061014157fe5b9050602002810190610153919061085a565b61015c9061089d565b8051602082015160408084015160608501516080860151925163d7fd19dd60e01b81529596506001600160a01b0389169563d7fd19dd956101a5959094909392916004016106ef565b600060405180830381600087803b1580156101bf57600080fd5b505af11580156101d3573d6000803e3d6000fd5b50506001909301925061012b915050565b50505050565b6000546001600160a01b031681565b6000805460405163bf40fac160e01b81526020600482018181528551602484015285516001600160a01b039094169363bf40fac19387938392604490920191908501908083838b5b83811015610259578181015183820152602001610241565b50505050905090810190601f1680156102865780820380516001836020036101000a031916815260200191505b509250505060206040518083038186803b1580156102a357600080fd5b505afa1580156102b7573d6000803e3d6000fd5b505050506040513d60208110156102cd57600080fd5b505190505b919050565b600067ffffffffffffffff8311156102eb57fe5b6102fe601f8401601f1916602001610879565b905082815283838301111561031257600080fd5b828260208301376000602084830101529392505050565b80356001600160a01b03811681146102d257600080fd5b600082601f830112610350578081fd5b61035f838335602085016102d7565b9392505050565b600060a08284031215610377578081fd5b60405160a0810167ffffffffffffffff828210818311171561039557fe5b816040528293508435835260208501356020840152604085013560408401526060850135606084015260808501359150808211156103d257600080fd5b506103df85828601610340565b6080830152505092915050565b6000604082840312156103fd578081fd5b6040516040810167ffffffffffffffff828210818311171561041b57fe5b816040528293508435835260209150818501358181111561043b57600080fd5b8501601f8101871361044c57600080fd5b80358281111561045857fe5b8381029250610468848401610879565b8181528481019083860185850187018b101561048357600080fd5b600095505b838610156104a6578035835260019590950194918601918601610488565b5080868801525050505050505092915050565b600060a082840312156104ca578081fd5b6104d460a0610879565b905081358152602082013567ffffffffffffffff808211156104f557600080fd5b61050185838601610366565b6020840152604084013591508082111561051a57600080fd5b610526858386016103ec565b6040840152606084013591508082111561053f57600080fd5b61054b85838601610340565b6060840152608084013591508082111561056457600080fd5b5061057184828501610340565b60808301525092915050565b6000806020838503121561058f578182fd5b823567ffffffffffffffff808211156105a6578384fd5b818501915085601f8301126105b9578384fd5b8135818111156105c7578485fd5b86602080830285010111156105da578485fd5b60209290920196919550909350505050565b6000602082840312156105fd578081fd5b813567ffffffffffffffff811115610613578182fd5b8201601f81018413610623578182fd5b610632848235602084016102d7565b949350505050565b60008151808452815b8181101561065f57602081850181015186830182015201610643565b818111156106705782602083870101525b50601f01601f19169290920160200192915050565b6000604083018251845260208084015160408287015282815180855260608801915083830194508592505b808310156106d057845182529383019360019290920191908301906106b0565b509695505050505050565b6001600160a01b0391909116815260200190565b6001600160a01b0386811682528516602082015260a06040820181905260009061071b9083018661063a565b846060840152828103608084015283518152602084015160a06020830152805160a0830152602081015160c0830152604081015160e083015260608101516101008301526080810151905060a061012083015261077c61014083018261063a565b9050604085015182820360408401526107958282610685565b915050606085015182820360608401526107af828261063a565b915050608085015182820360808401526107c9828261063a565b9a9950505050505050505050565b60208082526057908201527f4f564d5f4c314d756c74694d65737361676552656c617965723a2046756e637460408201527f696f6e2063616e206f6e6c792062652063616c6c656420627920746865204f5660608201527f4d5f4c3242617463684d65737361676552656c61796572000000000000000000608082015260a00190565b60008235609e1983360301811261086f578182fd5b9190910192915050565b60405181810167ffffffffffffffff8111828210171561089557fe5b604052919050565b600060a082360312156108ae578081fd5b60405160a0810167ffffffffffffffff82821081831117156108cc57fe5b816040526108d985610329565b83526108e760208601610329565b602084015260408501359150808211156108ff578384fd5b61090b36838701610340565b604084015260608501356060840152608085013591508082111561092d578384fd5b50610571368286016104b956fe50726f78795f5f4f564d5f4c3143726f7373446f6d61696e4d657373656e676572a264697066735822122044edf453e7d6f4b993bcc8242bf90d66595fdf3972bd95612c5090d42ed24a6f64736f6c63430007060033";
        public OVM_L1MultiMessageRelayerDeploymentBase() : base(BYTECODE) { }
        public OVM_L1MultiMessageRelayerDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_libAddressManager", 1)]
        public virtual string LibAddressManager { get; set; }
    }

    public partial class BatchRelayMessagesFunction : BatchRelayMessagesFunctionBase { }

    [Function("batchRelayMessages")]
    public class BatchRelayMessagesFunctionBase : FunctionMessage
    {
        [Parameter("tuple[]", "_messages", 1)]
        public virtual List<L2ToL1Message> Messages { get; set; }
    }

    public partial class LibAddressManagerFunction : LibAddressManagerFunctionBase { }

    [Function("libAddressManager", "address")]
    public class LibAddressManagerFunctionBase : FunctionMessage
    {

    }

    public partial class ResolveFunction : ResolveFunctionBase { }

    [Function("resolve", "address")]
    public class ResolveFunctionBase : FunctionMessage
    {
        [Parameter("string", "_name", 1)]
        public virtual string Name { get; set; }
    }



    public partial class LibAddressManagerOutputDTO : LibAddressManagerOutputDTOBase { }

    [FunctionOutput]
    public class LibAddressManagerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ResolveOutputDTO : ResolveOutputDTOBase { }

    [FunctionOutput]
    public class ResolveOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "_contract", 1)]
        public virtual string Contract { get; set; }
    }
}