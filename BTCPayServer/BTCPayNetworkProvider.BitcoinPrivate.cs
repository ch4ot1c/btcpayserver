using NBitcoin;

namespace BTCPayServer
{
    public partial class BTCPayNetworkProvider
    {
        public void InitBitcoinPrivate()
        {
            var nbxplorerNetwork = NBXplorerNetworkProvider.GetFromCryptoCode("BTCP");
            Add(new BTCPayNetwork()
            {
                CryptoCode = nbxplorerNetwork.CryptoCode,
                DisplayName = "BPrivate",
                BlockExplorerLink = NetworkType == NetworkType.Mainnet ? "https://explorer.btcprivate.org/tx/{0}/" : "https://testnet.btcprivate.org/tx/{0}",
                NBitcoinNetwork = nbxplorerNetwork.NBitcoinNetwork,
                NBXplorerNetwork = nbxplorerNetwork,
                UriScheme = "bitcoinprivate",
                DefaultRateRules = new[]
                {
                    "BTCP_X = BTCP_BTC * BTC_X",
                    "BTCP_BTC = bitfinex(BTCP_BTC)",
                },
                CryptoImagePath = "imlegacy/btcp.svg",
                LightningImagePath = "imlegacy/btcp-lightning.svg",
                DefaultSettings = BTCPayDefaultSettings.GetDefaultSettings(NetworkType),
                CoinType = NetworkType == NetworkType.Mainnet ? new KeyPath("183'") : new KeyPath("1'")
            });
        }
    }
}
