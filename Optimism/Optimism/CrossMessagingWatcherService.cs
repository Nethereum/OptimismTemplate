using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.Contracts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Nethereum.Web3;
using Optimism.Contracts.OVM.Bridge.Messaging.OVM_L1CrossDomainMessenger.ContractDefinition;

namespace Optimism
{
    public class CrossMessagingWatcherService
    {
        public async Task<List<byte[]>> GetMessageHashes(Web3 web3, string txnHash)
        {
            var txnReceipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(txnHash);
            return GetMessageHashes(txnReceipt);
        }

        public List<byte[]> GetMessageHashes(TransactionReceipt receipt)
        {

            var sentMessagesEvents = receipt.DecodeAllEvents<SentMessageEventDTO>();
            var sentMessages = new List<byte[]>();
            foreach (var sentMessageEvent in sentMessagesEvents)
            {
                sentMessages.Add(Sha3Keccack.Current.CalculateHash(sentMessageEvent.Event.Message));
            }

            return sentMessages;
        }


        public async Task<TransactionReceipt> GetCrossMessageMessageTransactionReceipt(Web3 web3layerToReceiveMessage, string messengerAddress, byte[] msgHash, CancellationToken token = default(CancellationToken), int numberOfPastBlocks = 1000 )
        {
            //this needs a time out cancellation process.
            var blockNumber = await web3layerToReceiveMessage.Eth.Blocks.GetBlockNumber.SendRequestAsync();
            var startingBlock = BigInteger.Max(blockNumber.Value - numberOfPastBlocks, 0);

            var eventRelayedMessage = web3layerToReceiveMessage.Eth.GetEvent<RelayedMessageEventDTO>(messengerAddress);
            var filterInput = eventRelayedMessage.CreateFilterInput(new BlockParameter((ulong)startingBlock), BlockParameter.CreateLatest());

            var logs = await eventRelayedMessage.GetAllChanges(filterInput);
            var logsFiltered = logs.Where(x => x.Event.MsgHash.ToHex() == msgHash.ToHex());
            
            while (!logsFiltered.Any())
            {
                Thread.Sleep(1000);
                if (token != CancellationToken.None)
                {
                    token.ThrowIfCancellationRequested();
                }

                logs = await eventRelayedMessage.GetAllChanges(filterInput);
                logsFiltered = logs.Where(x => x.Event.MsgHash.ToHex() == msgHash.ToHex());
            }

            return await web3layerToReceiveMessage.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(logsFiltered.First().Log.TransactionHash);
        }
    }
}
