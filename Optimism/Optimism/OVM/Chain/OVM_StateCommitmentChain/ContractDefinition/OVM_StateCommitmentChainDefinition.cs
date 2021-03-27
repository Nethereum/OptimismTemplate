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

namespace Optimism.Contracts.OVM.Chain.OVM_StateCommitmentChain.ContractDefinition
{


    public partial class OVM_StateCommitmentChainDeployment : OVM_StateCommitmentChainDeploymentBase
    {
        public OVM_StateCommitmentChainDeployment() : base(BYTECODE) { }
        public OVM_StateCommitmentChainDeployment(string byteCode) : base(byteCode) { }
    }

    public class OVM_StateCommitmentChainDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50604051611bfe380380611bfe83398101604081905261002f9161005b565b600080546001600160a01b0319166001600160a01b03949094169390931790925560015560025561009c565b60008060006060848603121561006f578283fd5b83516001600160a01b0381168114610085578384fd5b602085015160409095015190969495509392505050565b611b53806100ab6000396000f3fe608060405234801561001057600080fd5b50600436106100b45760003560e01c80638ca5cbb9116100715780638ca5cbb91461012f5780639418bddd14610144578063b8e189ac14610157578063c17b291b1461016a578063cfdf677e14610172578063e561dddc1461017a576100b4565b8063299ca478146100b9578063461a4478146100d75780634d69ee57146100ea5780637aa63a861461010a5780637ad168a01461011f57806381eb62ef14610127575b600080fd5b6100c1610182565b6040516100ce91906115af565b60405180910390f35b6100c16100e53660046114f3565b610191565b6100fd6100f8366004611441565b61026f565b6040516100ce91906115c3565b6101126102e2565b6040516100ce91906115ce565b6101126102fb565b610112610314565b61014261013d3660046113a0565b61031a565b005b6100fd610152366004611541565b61052e565b610142610165366004611541565b61057e565b610112610636565b6100c161063c565b610112610664565b6000546001600160a01b031681565b6000805460405163bf40fac160e01b81526020600482018181528551602484015285516001600160a01b039094169363bf40fac19387938392604490920191908501908083838b5b838110156101f15781810151838201526020016101d9565b50505050905090810190601f16801561021e5780820380516001836020036101000a031916815260200191505b509250505060206040518083038186803b15801561023b57600080fd5b505afa15801561024f573d6000803e3d6000fd5b505050506040513d602081101561026557600080fd5b505190505b919050565b600061027a836106de565b61029f5760405162461bcd60e51b815260040161029690611759565b60405180910390fd5b6102bc836020015185846000015185602001518760400151610776565b6102d85760405162461bcd60e51b8152600401610296906116c5565b5060019392505050565b6000806102ed6108fb565b5064ffffffffff1691505090565b6000806103066108fb565b64ffffffffff169250505090565b60025481565b6103226102e2565b81146103405760405162461bcd60e51b8152600401610296906116fc565b6103706040518060400160405280600f81526020016e27ab26afa137b73226b0b730b3b2b960891b815250610191565b6001600160a01b03166302ad4d2a336040518263ffffffff1660e01b815260040161039b91906115af565b60206040518083038186803b1580156103b357600080fd5b505afa1580156103c7573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906103eb91906113e3565b6104075760405162461bcd60e51b8152600401610296906118cb565b60008251116104285760405162461bcd60e51b815260040161029690611888565b6104666040518060400160405280601d81526020017f4f564d5f43616e6f6e6963616c5472616e73616374696f6e436861696e000000815250610191565b6001600160a01b0316637aa63a866040518163ffffffff1660e01b815260040160206040518083038186803b15801561049e57600080fd5b505afa1580156104b2573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906104d69190611429565b82516104e06102e2565b0111156104ff5760405162461bcd60e51b815260040161029690611656565b61052a8242336040516020016105169291906119b1565b604051602081830303815290604052610990565b5050565b60008082608001518060200190518101906105499190611574565b509050806105695760405162461bcd60e51b815260040161029690611843565b4261057682600154610b31565b119392505050565b6105b06040518060400160405280601181526020017027ab26afa33930bab22b32b934b334b2b960791b815250610191565b6001600160a01b0316336001600160a01b0316146105e05760405162461bcd60e51b8152600401610296906117e6565b6105e9816106de565b6106055760405162461bcd60e51b815260040161029690611759565b61060e8161052e565b61062a5760405162461bcd60e51b815260040161029690611788565b61063381610b92565b50565b60015481565b600061065f604051806060016040528060258152602001611ac560259139610191565b905090565b600061066e61063c565b6001600160a01b0316631f7b6d326040518163ffffffff1660e01b815260040160206040518083038186803b1580156106a657600080fd5b505afa1580156106ba573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061065f9190611429565b60006106e861063c565b8251604051634a83e9cd60e11b81526001600160a01b039290921691639507d39a91610716916004016115ce565b60206040518083038186803b15801561072e57600080fd5b505afa158015610742573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906107669190611429565b61076f83610d0a565b1492915050565b60008082116107b65760405162461bcd60e51b8152600401808060200182810382526037815260200180611a416037913960400191505060405180910390fd5b8184106107f45760405162461bcd60e51b81526004018080602001828103825260248152602001806119ed6024913960400191505060405180910390fd5b6107fd82610d50565b83511461083b5760405162461bcd60e51b815260040180806020018281038252604d815260200180611a78604d913960600191505060405180910390fd5b8460005b84518110156108ee57856001166001141561089d5784818151811061086057fe5b60200260200101518260405160200180838152602001828152602001925050506040516020818303038152906040528051906020012091506108e2565b818582815181106108aa57fe5b602002602001015160405160200180838152602001828152602001925050506040516020818303038152906040528051906020012091505b600195861c950161083f565b5090951495945050505050565b600080600061090861063c565b6001600160a01b031663ccf8f9696040518163ffffffff1660e01b815260040160206040518083038186803b15801561094057600080fd5b505afa158015610954573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906109789190611403565b64ffffffffff602882901c16935060501c9150509091565b60006109bf6040518060400160405280600c81526020016b27ab26afa83937b837b9b2b960a11b815250610191565b90506000806109cc6108fb565b9092509050336001600160a01b03841614156109e9575042610a13565b426002548264ffffffffff160110610a135760405162461bcd60e51b81526004016102969061191a565b60006040518060a00160405280610a28610664565b8152602001610a3688610dfa565b8152602001875181526020018464ffffffffff16815260200186815250905080600001517f16be4c5129a4e03cf3350262e181dc02ddfb4a6008d925368c0899fcd97ca9c58260200151836040015184606001518560800151604051610a9f94939291906115ed565b60405180910390a2610aaf61063c565b6001600160a01b0316632015276c610ac683610d0a565b610ada84604001518560600151018661122a565b6040518363ffffffff1660e01b8152600401610af79291906115d7565b600060405180830381600087803b158015610b1157600080fd5b505af1158015610b25573d6000803e3d6000fd5b50505050505050505050565b600082820183811015610b8b576040805162461bcd60e51b815260206004820152601b60248201527f536166654d6174683a206164646974696f6e206f766572666c6f770000000000604482015290519081900360640190fd5b9392505050565b610b9a61063c565b6001600160a01b0316631f7b6d326040518163ffffffff1660e01b815260040160206040518083038186803b158015610bd257600080fd5b505afa158015610be6573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190610c0a9190611429565b815110610c295760405162461bcd60e51b815260040161029690611983565b610c32816106de565b610c4e5760405162461bcd60e51b815260040161029690611759565b610c5661063c565b6001600160a01b031663167fd6818260000151610c788460600151600061122a565b6040518363ffffffff1660e01b8152600401610c959291906115d7565b600060405180830381600087803b158015610caf57600080fd5b505af1158015610cc3573d6000803e3d6000fd5b5050505080600001517f8747b69ce8fdb31c3b9b0a67bd8049ad8c1a69ea417b69b12174068abd9cbd648260200151604051610cff91906115ce565b60405180910390a250565b60008160200151826040015183606001518460800151604051602001610d3394939291906115ed565b604051602081830303815290604052805190602001209050919050565b6000808211610d905760405162461bcd60e51b8152600401808060200182810382526030815260200180611a116030913960400191505060405180910390fd5b8160011415610da15750600061026a565b81600060805b60018160ff1610610de5578060ff1660018260ff166001901b03901b8316600014610dda5760ff811692831c9291909101905b60011c607f16610da7565b506001811b8414610b8b576001019392505050565b600080825111610e3b5760405162461bcd60e51b8152600401808060200182810382526034815260200180611aea6034913960400191505060405180910390fd5b8151610e5d5781600081518110610e4e57fe5b6020026020010151905061026a565b60408051610200810182527f290decd9548b62a8d60345a988386fc84ba6bc95484008f6362f93160ef3e56381527f633dc4d7da7256660a892f8f1604a44b5432649cc8ec5cb3ced4c4e6ac94dd1d60208201527f890740a8eb06ce9be422cb8da5cdafc2b58c0a5e24036c578de2a433c828ff7d818301527f3b8ec09e026fdc305365dfc94e189a81b38c7597b3d941c279f042e8206e0bd86060808301919091527fecd50eee38e386bd62be9bedb990706951b65fe053bd9d8a521af753d139e2da60808301527fdefff6d330bb5403f63b14f33b578274160de3a50df4efecf0e0db73bcdd3da560a08301527f617bdd11f7c0a11f49db22f629387a12da7596f9d1704d7465177c63d88ec7d760c08301527f292c23a9aa1d8bea7e2435e555a4a60e379a5a35f3f452bae60121073fb6eead60e08301527fe1cea92ed99acdcb045a6726b2f87107e8a61620a232cf4d7d5b5766b3952e106101008301527f7ad66c0a68c72cb89e4fb4303841966e4062a76ab97451e3b9fb526a5ceb7f826101208301527fe026cc5a4aed3c22a58cbd3d2ac754c9352c5436f638042dca99034e836365166101408301527f3d04cffd8b46a874edf5cfae63077de85f849a660426697b06a829c70dd1409c6101608301527fad676aa337a485e4728a0b240d92b3ef7b3c372d06d189322bfd5f61f1e7203e6101808301527fa2fca4a49658f9fab7aa63289c91b7c7b6c832a6d0e69334ff5b0a3483d09dab6101a08301527f4ebfd9cd7bca2505f7bef59cc1c12ecc708fff26ae4af19abe852afe9e20c8626101c08301527f2def10d13dd169f550f578bda343d9717a138562e0093b380a1120789d53cf106101e083015282518381529081018352909160009190602082018180368337505085519192506000918291508180805b60018411156112065750506002820460018084161460005b82811015611182578a816002028151811061112957fe5b602002602001015196508a816002026001018151811061114557fe5b6020026020010151955086602089015285604089015287805190602001208b828151811061116f57fe5b6020908102919091010152600101611112565b5080156111e55789600185038151811061119857fe5b602002602001015195508783601081106111ae57fe5b602002015160001b945085602088015284604088015286805190602001208a83815181106111d857fe5b6020026020010181815250505b806111f15760006111f4565b60015b60ff16820193506001909201916110fa565b8960008151811061121357fe5b602002602001015198505050505050505050919050565b602890811b91909117901b90565b600067ffffffffffffffff83111561124c57fe5b61125f601f8401601f19166020016119c8565b905082815283838301111561127357600080fd5b828260208301376000602084830101529392505050565b600082601f83011261129a578081fd5b8135602067ffffffffffffffff8211156112b057fe5b8082026112be8282016119c8565b8381528281019086840183880185018910156112d8578687fd5b8693505b858410156112fa5780358352600193909301929184019184016112dc565b50979650505050505050565b600060a08284031215611317578081fd5b60405160a0810167ffffffffffffffff828210818311171561133557fe5b8160405282935084358352602085013560208401526040850135604084015260608501356060840152608085013591508082111561137257600080fd5b508301601f8101851361138457600080fd5b61139385823560208401611238565b6080830152505092915050565b600080604083850312156113b2578182fd5b823567ffffffffffffffff8111156113c8578283fd5b6113d48582860161128a565b95602094909401359450505050565b6000602082840312156113f4578081fd5b81518015158114610b8b578182fd5b600060208284031215611414578081fd5b815164ffffffffff1981168114610b8b578182fd5b60006020828403121561143a578081fd5b5051919050565b600080600060608486031215611455578081fd5b83359250602084013567ffffffffffffffff80821115611473578283fd5b61147f87838801611306565b93506040860135915080821115611494578283fd5b90850190604082880312156114a7578283fd5b6040516040810181811083821117156114bc57fe5b604052823581526020830135828111156114d4578485fd5b6114e08982860161128a565b6020830152508093505050509250925092565b600060208284031215611504578081fd5b813567ffffffffffffffff81111561151a578182fd5b8201601f8101841361152a578182fd5b61153984823560208401611238565b949350505050565b600060208284031215611552578081fd5b813567ffffffffffffffff811115611568578182fd5b61153984828501611306565b60008060408385031215611586578182fd5b825160208401519092506001600160a01b03811681146115a4578182fd5b809150509250929050565b6001600160a01b0391909116815260200190565b901515815260200190565b90815260200190565b91825264ffffffffff1916602082015260400190565b600085825260208581840152846040840152608060608401528351806080850152825b8181101561162c5785810183015185820160a001528201611610565b8181111561163d578360a083870101525b50601f01601f19169290920160a0019695505050505050565b60208082526049908201527f4e756d626572206f6620737461746520726f6f74732063616e6e6f742065786360408201527f65656420746865206e756d626572206f662063616e6f6e6963616c207472616e60608201526839b0b1ba34b7b7399760b91b608082015260a00190565b60208082526018908201527f496e76616c696420696e636c7573696f6e2070726f6f662e0000000000000000604082015260600190565b6020808252603d908201527f41637475616c20626174636820737461727420696e64657820646f6573206e6f60408201527f74206d6174636820657870656374656420737461727420696e6465782e000000606082015260800190565b60208082526015908201527424b73b30b634b2103130ba31b4103432b0b232b91760591b604082015260600190565b602080825260409082018190527f537461746520626174636865732063616e206f6e6c792062652064656c657465908201527f642077697468696e207468652066726175642070726f6f662077696e646f772e606082015260800190565b6020808252603b908201527f537461746520626174636865732063616e206f6e6c792062652064656c65746560408201527f6420627920746865204f564d5f467261756456657269666965722e0000000000606082015260800190565b60208082526025908201527f4261746368206865616465722074696d657374616d702063616e6e6f74206265604082015264207a65726f60d81b606082015260800190565b60208082526023908201527f43616e6e6f74207375626d697420616e20656d7074792073746174652062617460408201526231b41760e91b606082015260800190565b6020808252602f908201527f50726f706f73657220646f6573206e6f74206861766520656e6f75676820636f60408201526e1b1b185d195c985b081c1bdcdd1959608a1b606082015260800190565b60208082526043908201527f43616e6e6f74207075626c69736820737461746520726f6f747320776974686960408201527f6e207468652073657175656e636572207075626c69636174696f6e2077696e6460608201526237bb9760e91b608082015260a00190565b60208082526014908201527324b73b30b634b2103130ba31b41034b73232bc1760611b604082015260600190565b9182526001600160a01b0316602082015260400190565b60405181810167ffffffffffffffff811182821017156119e457fe5b60405291905056fe4c69625f4d65726b6c65547265653a20496e646578206f7574206f6620626f756e64732e4c69625f4d65726b6c65547265653a2043616e6e6f7420636f6d70757465206365696c286c6f675f3229206f6620302e4c69625f4d65726b6c65547265653a20546f74616c206c6561766573206d7573742062652067726561746572207468616e207a65726f2e4c69625f4d65726b6c65547265653a20546f74616c207369626c696e677320646f6573206e6f7420636f72726563746c7920636f72726573706f6e6420746f20746f74616c206c65617665732e4f564d5f436861696e53746f72616765436f6e7461696e65723a5343433a626174636865734c69625f4d65726b6c65547265653a204d7573742070726f76696465206174206c65617374206f6e65206c65616620686173682ea26469706673582212203c2982ff2187ff5cad1a1a7a9803a59ad996712770f6010aa5b8bf309019162764736f6c63430007060033";
        public OVM_StateCommitmentChainDeploymentBase() : base(BYTECODE) { }
        public OVM_StateCommitmentChainDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_libAddressManager", 1)]
        public virtual string LibAddressManager { get; set; }
        [Parameter("uint256", "_fraudProofWindow", 2)]
        public virtual BigInteger FraudProofWindow { get; set; }
        [Parameter("uint256", "_sequencerPublishWindow", 3)]
        public virtual BigInteger SequencerPublishWindow { get; set; }
    }

    public partial class FRAUD_PROOF_WINDOWFunction : FRAUD_PROOF_WINDOWFunctionBase { }

    [Function("FRAUD_PROOF_WINDOW", "uint256")]
    public class FRAUD_PROOF_WINDOWFunctionBase : FunctionMessage
    {

    }

    public partial class SEQUENCER_PUBLISH_WINDOWFunction : SEQUENCER_PUBLISH_WINDOWFunctionBase { }

    [Function("SEQUENCER_PUBLISH_WINDOW", "uint256")]
    public class SEQUENCER_PUBLISH_WINDOWFunctionBase : FunctionMessage
    {

    }

    public partial class AppendStateBatchFunction : AppendStateBatchFunctionBase { }

    [Function("appendStateBatch")]
    public class AppendStateBatchFunctionBase : FunctionMessage
    {
        [Parameter("bytes32[]", "_batch", 1)]
        public virtual List<byte[]> Batch { get; set; }
        [Parameter("uint256", "_shouldStartAtElement", 2)]
        public virtual BigInteger ShouldStartAtElement { get; set; }
    }

    public partial class BatchesFunction : BatchesFunctionBase { }

    [Function("batches", "address")]
    public class BatchesFunctionBase : FunctionMessage
    {

    }

    public partial class DeleteStateBatchFunction : DeleteStateBatchFunctionBase { }

    [Function("deleteStateBatch")]
    public class DeleteStateBatchFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "_batchHeader", 1)]
        public virtual ChainBatchHeader BatchHeader { get; set; }
    }

    public partial class GetLastSequencerTimestampFunction : GetLastSequencerTimestampFunctionBase { }

    [Function("getLastSequencerTimestamp", "uint256")]
    public class GetLastSequencerTimestampFunctionBase : FunctionMessage
    {

    }

    public partial class GetTotalBatchesFunction : GetTotalBatchesFunctionBase { }

    [Function("getTotalBatches", "uint256")]
    public class GetTotalBatchesFunctionBase : FunctionMessage
    {

    }

    public partial class GetTotalElementsFunction : GetTotalElementsFunctionBase { }

    [Function("getTotalElements", "uint256")]
    public class GetTotalElementsFunctionBase : FunctionMessage
    {

    }

    public partial class InsideFraudProofWindowFunction : InsideFraudProofWindowFunctionBase { }

    [Function("insideFraudProofWindow", "bool")]
    public class InsideFraudProofWindowFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "_batchHeader", 1)]
        public virtual ChainBatchHeader BatchHeader { get; set; }
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

    public partial class VerifyStateCommitmentFunction : VerifyStateCommitmentFunctionBase { }

    [Function("verifyStateCommitment", "bool")]
    public class VerifyStateCommitmentFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "_element", 1)]
        public virtual byte[] Element { get; set; }
        [Parameter("tuple", "_batchHeader", 2)]
        public virtual ChainBatchHeader BatchHeader { get; set; }
        [Parameter("tuple", "_proof", 3)]
        public virtual ChainInclusionProof Proof { get; set; }
    }

    public partial class StateBatchAppendedEventDTO : StateBatchAppendedEventDTOBase { }

    [Event("StateBatchAppended")]
    public class StateBatchAppendedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "_batchIndex", 1, true )]
        public virtual BigInteger BatchIndex { get; set; }
        [Parameter("bytes32", "_batchRoot", 2, false )]
        public virtual byte[] BatchRoot { get; set; }
        [Parameter("uint256", "_batchSize", 3, false )]
        public virtual BigInteger BatchSize { get; set; }
        [Parameter("uint256", "_prevTotalElements", 4, false )]
        public virtual BigInteger PrevTotalElements { get; set; }
        [Parameter("bytes", "_extraData", 5, false )]
        public virtual byte[] ExtraData { get; set; }
    }

    public partial class StateBatchDeletedEventDTO : StateBatchDeletedEventDTOBase { }

    [Event("StateBatchDeleted")]
    public class StateBatchDeletedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "_batchIndex", 1, true )]
        public virtual BigInteger BatchIndex { get; set; }
        [Parameter("bytes32", "_batchRoot", 2, false )]
        public virtual byte[] BatchRoot { get; set; }
    }

    public partial class FRAUD_PROOF_WINDOWOutputDTO : FRAUD_PROOF_WINDOWOutputDTOBase { }

    [FunctionOutput]
    public class FRAUD_PROOF_WINDOWOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class SEQUENCER_PUBLISH_WINDOWOutputDTO : SEQUENCER_PUBLISH_WINDOWOutputDTOBase { }

    [FunctionOutput]
    public class SEQUENCER_PUBLISH_WINDOWOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class BatchesOutputDTO : BatchesOutputDTOBase { }

    [FunctionOutput]
    public class BatchesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class GetLastSequencerTimestampOutputDTO : GetLastSequencerTimestampOutputDTOBase { }

    [FunctionOutput]
    public class GetLastSequencerTimestampOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_lastSequencerTimestamp", 1)]
        public virtual BigInteger LastSequencerTimestamp { get; set; }
    }

    public partial class GetTotalBatchesOutputDTO : GetTotalBatchesOutputDTOBase { }

    [FunctionOutput]
    public class GetTotalBatchesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_totalBatches", 1)]
        public virtual BigInteger TotalBatches { get; set; }
    }

    public partial class GetTotalElementsOutputDTO : GetTotalElementsOutputDTOBase { }

    [FunctionOutput]
    public class GetTotalElementsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_totalElements", 1)]
        public virtual BigInteger TotalElements { get; set; }
    }

    public partial class InsideFraudProofWindowOutputDTO : InsideFraudProofWindowOutputDTOBase { }

    [FunctionOutput]
    public class InsideFraudProofWindowOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "_inside", 1)]
        public virtual bool Inside { get; set; }
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

    public partial class VerifyStateCommitmentOutputDTO : VerifyStateCommitmentOutputDTOBase { }

    [FunctionOutput]
    public class VerifyStateCommitmentOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }
}
