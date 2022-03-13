pragma solidity >=0.8.0;
import "@eth-optimism/contracts/libraries/bridge/CrossDomainEnabled.sol";


contract SimpleStorage is CrossDomainEnabled {
    address public msgSender;
    address public xDomainSender;
    bytes32 public value;
    uint256 public totalCount;

    constructor(address _crossDomainMessenger)
        CrossDomainEnabled(_crossDomainMessenger)
    {
      
    }
    function setValue(bytes32 newValue) public {
        value = newValue;
        totalCount++;
    }

    function sendValue( address _crossDomainTarget,
        uint32 _gasLimit,
        bytes memory _message) public {
        sendCrossDomainMessage(_crossDomainTarget, _gasLimit, _message);
    }

    function dumbSetValue(bytes32 newValue) public {
        value = newValue;
    }
}