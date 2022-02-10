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

namespace EpicNfts.Contracts.A.ContractDefinition
{


    public partial class ADeployment : ADeploymentBase
    {
        public ADeployment() : base(BYTECODE) { }
        public ADeployment(string byteCode) : base(byteCode) { }
    }

    public class ADeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50610189806100206000396000f3fe608060405234801561001057600080fd5b506004361061002b5760003560e01c806352d6ec7614610030575b600080fd5b61004361003e366004610101565b610045565b005b6001600160a01b0381163b61008a5760405162461bcd60e51b81526020600482015260076024820152666d65737361676560c81b604482015260640160405180910390fd5b60405163a9059cbb60e01b8152336004820152620186a060248201526001600160a01b0382169063a9059cbb906044016020604051808303816000875af11580156100d9573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906100fd9190610131565b5050565b60006020828403121561011357600080fd5b81356001600160a01b038116811461012a57600080fd5b9392505050565b60006020828403121561014357600080fd5b8151801515811461012a57600080fdfea26469706673582212207eea08d5f0c679f89b54968275e61724b8cf1c2f28a003bfa07040fb63eae60564736f6c634300080b0033";
        public ADeploymentBase() : base(BYTECODE) { }
        public ADeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class Transfer2Function : Transfer2FunctionBase { }

    [Function("transfer2")]
    public class Transfer2FunctionBase : FunctionMessage
    {
        [Parameter("address", "name", 1)]
        public virtual string Name { get; set; }
    }


}
