﻿using Neo.JsonRpc.Client;
using System;
using System.Threading.Tasks;
using Neo.RPC.DTOs;

namespace Neo.RPC.Services.Account
{
    /// <summary>
    ///     getbalance 
    ///     Returns the balance of the corresponding asset in the wallet, based on the specified asset number.
    /// 
    ///     Parameters
    ///     Asset_id: Asset ID (asset identifier), which is the transaction ID of the RegistTransaction when the asset is registered.
    ///     For NEO: c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b
    ///     For GAS: 602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7
    ///     The remaining asset IDs can be queried through the list asset command in CLI Command or in the Block Chain Browser.
    ///
    /// 
    ///     Returns
    ///     Balance: The actual balance of the asset in the wallet.
    ///     Confirmed: The exact amount of the asset in the wallet, where only confirmed amounts can be used for transfer.
    ///     Balance and Confirmed values may not be equal.This happens when there is an output transaction from the wallet, and the change has not been confirmed yet, so the confirmed value will be less than the balance. Once the deal is confirmed, the two will become equal.
    /// 
    ///     Example
    ///     Request
    ///     curl -X POST --data '{"jsonrpc":"2.0","method":"getbalance","params":["025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4"],"id":1}'
    /// 
    ///     Result
    ///     {
    ///     "jsonrpc": "2.0",
    ///     "id": 1,
    ///     "result": {
    ///     "Balance": "1.01",
    ///     "Confirmed": "1.01"
    ///     }
    /// }
    /// </summary>
    /// 
    public class NeoGetBalance : RpcRequestResponseHandler<WalletBalance>
    {
        public NeoGetBalance(IClient client) : base(client, ApiMethods.getbalance.ToString())
        {
        }

        public Task<WalletBalance> SendRequestAsync(string assetId, object id = null)
        {
            if (assetId == null) throw new ArgumentNullException(nameof(assetId));
            return base.SendRequestAsync(id, assetId);
        }

        public RpcRequest BuildRequest(string assetId, object id = null)
        {
            if (assetId == null) throw new ArgumentNullException(nameof(assetId));
            return base.BuildRequest(id, assetId);
        }
    }
}