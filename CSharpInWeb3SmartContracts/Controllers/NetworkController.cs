﻿using CSharpInWeb3SmartContracts.Models;
using Microsoft.AspNetCore.Mvc;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Signer;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace CSharpInWeb3SmartContracts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkController : ControllerBase
    {

        private readonly User _user = new User();

        public NetworkController(IConfiguration configuration)
        {
            _user.BlockchainProvider = configuration["BlockchainProvider"];
            _user.MetamaskAddress = configuration["MetamaskAddress"];
            _user.PrivateKey = configuration["PrivateKey"];
        }

        [HttpGet("GetLatestBlock")]
        public async Task<ActionResult> GetLatestBlock(Chain chain)
        {
            Account? account = new Account(_user.PrivateKey, chain);
            Web3? web3 = new Web3(account, _user.BlockchainProvider);

            HexBigInteger? latestBlockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
            BlockWithTransactionHashes? latestBlock = await web3.Eth.Blocks.GetBlockWithTransactionsHashesByNumber.SendRequestAsync(latestBlockNumber);

            return Ok($"Last block number {latestBlockNumber}, latest block gas limit {latestBlock.GasLimit}, latest block gas used {latestBlock.GasUsed}");
        }

    }
}