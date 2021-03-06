using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NeoModules.JsonRpc.Client;

namespace NeoModules.RPC.Services.Nep5
{
    public class TokenBalanceOf : RpcRequestResponseHandler<DTOs.Invoke>
    {
        private string _tokenScriptHash;

        public TokenBalanceOf(IClient client, string tokenScriptHash) : base(client, ApiMethods.invokefunction.ToString())
        {
            _tokenScriptHash = tokenScriptHash;
        }

        public void ChangeScriptHash(string tokenScripHash)
        {
            _tokenScriptHash = tokenScripHash;
        }

        public Task<DTOs.Invoke> SendRequestAsync(string address, object id = null)
        {
            if (string.IsNullOrEmpty(address)) throw new ArgumentNullException(nameof(address));
            var param = new List<DTOs.Stack>
            {
                new DTOs.Stack
                {
                    Type = "Hash160",
                    Value = address
                }
            };
            return base.SendRequestAsync(id, _tokenScriptHash, Nep5Methods.balanceOf.ToString(), param);
        }

        public Task<DTOs.Invoke> SendRequestAsync(byte[] address, object id = null)
        {
            if (address.Length != 20) throw new ArgumentNullException(nameof(address));
            var param = new List<DTOs.Stack>
            {
                new DTOs.Stack
                {
                    Type = "Hash160",
                    Value = address
                }
            };
            return base.SendRequestAsync(id, _tokenScriptHash, Nep5Methods.balanceOf.ToString(), param);
        }

        public RpcRequest BuildRequest(string address, object id = null)
        {
            if (string.IsNullOrEmpty(address)) throw new ArgumentNullException(nameof(address));
            var param = new List<DTOs.Stack>
            {
                new DTOs.Stack
                {
                    Type = "Hash160",
                    Value = address
                }
            };
            return base.BuildRequest(id, _tokenScriptHash, Nep5Methods.balanceOf.ToString(), param);
        }
    }
}
