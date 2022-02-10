pragma solidity 0.8.11;

import "./MyEpicNFT.sol";
import "@openzeppelin/contracts/token/ERC20/ERC20.sol";

contract A {
    using Address for address;
    
    function transfer2(address name) public  {
        require(name.isContract(), "message");
        ERC20(name).transfer(msg.sender, 100000);
    }

}