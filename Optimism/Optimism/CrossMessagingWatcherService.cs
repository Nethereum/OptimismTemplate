﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Nethereum.Web3;
using Optimism.Contracts.L1CrossDomainMessenger.ContractDefinition;

namespace Optimism
{
    public class CrossMessagingWatcherService
    {
        [Function("relayMessage")]
        public class RelayMessageXDomainFunction : FunctionMessage
        {
            [Parameter("address", "_target", 1)]
            public virtual string Target { get; set; }
            [Parameter("address", "_sender", 2)]
            public virtual string Sender { get; set; }
            [Parameter("bytes", "_message", 3)]
            public virtual byte[] Message { get; set; }
            [Parameter("uint256", "_messageNonce", 4)]
            public virtual BigInteger MessageNonce { get; set; }
        }

        public async Task<List<byte[]>> GetMessageHashes(Web3 web3, string txnHash)
        {
            var txnReceipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(txnHash);
            return GetMessageHashes(txnReceipt);
        }

        public List<byte[]> GetMessageHashes(TransactionReceipt receipt)
        {

            var sentMessagesEvents = receipt.DecodeAllEvents<SentMessageEventDTO>();
            Debug.WriteLine(Event< SentMessageEventDTO>.GetEventABI().Sha3Signature);
            var sentMessages = new List<byte[]>();
            foreach (var sentMessageEvent in sentMessagesEvents)
            {
                var relayMessage = new RelayMessageXDomainFunction();
                relayMessage.Message = sentMessageEvent.Event.Message;
                relayMessage.MessageNonce = sentMessageEvent.Event.MessageNonce;
                relayMessage.Target = sentMessageEvent.Event.Target;
                relayMessage.Sender = sentMessageEvent.Event.Sender;
                sentMessages.Add(Sha3Keccack.Current.CalculateHash(relayMessage.GetCallData()));
            }

            return sentMessages;
        }


        public async Task<TransactionReceipt> GetCrossMessageMessageTransactionReceipt(Web3 web3layerToReceiveMessage, string messengerAddress, byte[] msgHash, CancellationToken token = default(CancellationToken), int numberOfPastBlocks = 1000 )
        {
            //this needs a time out cancellation process.
            var blockNumber = await web3layerToReceiveMessage.Eth.Blocks.GetBlockNumber.SendRequestAsync();
            var startingBlock = BigInteger.Max(blockNumber.Value - numberOfPastBlocks, 0);

            var eventRelayedMessage = web3layerToReceiveMessage.Eth.GetEvent<RelayedMessageEventDTO>(messengerAddress);
            Debug.WriteLine(eventRelayedMessage.EventABI.Sha3Signature);
            var filterInput = eventRelayedMessage.CreateFilterInput(new BlockParameter((ulong)startingBlock), BlockParameter.CreateLatest());

            var logs = await eventRelayedMessage.GetAllChangesAsync(filterInput);
            var logsFiltered = logs.Where(x => x.Event.MsgHash.ToHex() == msgHash.ToHex());
            
            while (!logsFiltered.Any())
            {
                Thread.Sleep(1000);
                if (token != CancellationToken.None)
                {
                    token.ThrowIfCancellationRequested();
                }

                logs = await eventRelayedMessage.GetAllChangesAsync(filterInput);
                logsFiltered = logs.Where(x => x.Event.MsgHash.ToHex() == msgHash.ToHex());
            }

            return await web3layerToReceiveMessage.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(logsFiltered.First().Log.TransactionHash);
        }
    }
}
