using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using EpicNfts.Contracts.A.ContractDefinition;

namespace EpicNfts.Contracts.A
{
    public partial class AService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ADeployment aDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ADeployment>().SendRequestAndWaitForReceiptAsync(aDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ADeployment aDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ADeployment>().SendRequestAsync(aDeployment);
        }

        public static async Task<AService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ADeployment aDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, aDeployment, cancellationTokenSource);
            return new AService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> Transfer2RequestAsync(Transfer2Function transfer2Function)
        {
             return ContractHandler.SendRequestAsync(transfer2Function);
        }

        public Task<TransactionReceipt> Transfer2RequestAndWaitForReceiptAsync(Transfer2Function transfer2Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transfer2Function, cancellationToken);
        }

        public Task<string> Transfer2RequestAsync(string name)
        {
            var transfer2Function = new Transfer2Function();
                transfer2Function.Name = name;
            
             return ContractHandler.SendRequestAsync(transfer2Function);
        }

        public Task<TransactionReceipt> Transfer2RequestAndWaitForReceiptAsync(string name, CancellationTokenSource cancellationToken = null)
        {
            var transfer2Function = new Transfer2Function();
                transfer2Function.Name = name;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transfer2Function, cancellationToken);
        }
    }
}
