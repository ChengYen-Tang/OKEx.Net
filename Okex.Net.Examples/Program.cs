﻿using CryptoExchange.Net.Sockets;
using Newtonsoft.Json;
using Okex.Net.Enums;
using Okex.Net.RestObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Okex.Net.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            OkexClient apiClient = new OkexClient(new OkexClientOptions { LogVerbosity = CryptoExchange.Net.Logging.LogVerbosity.Debug });
            apiClient.SetApiCredentials("XXXXXXXX-API-KEY-XXXXXXXX", "XXXXXXXX-API-SECRET-XXXXXXXX", "XXXXXXXX-API-PASSPHRASE-XXXXXXXX");

            /* Public Api Endpoints */
            var ok00 = apiClient.General_ServerTime();
            var ok01 = apiClient.Spot_GetTradingPairs();
            var ok02 = apiClient.Spot_GetOrderBook("BTC-USDT");
            var ok03 = apiClient.Spot_GetAllTickers();
            var ok04 = apiClient.Spot_GetSymbolTicker("BTC-USDT");
            var ok05 = apiClient.Spot_GetTrades("BTC-USDT");
            var ok06 = apiClient.Spot_GetCandles("BTC-USDT", OkexSpotPeriod.OneHour);
            var ok07 = apiClient.Spot_GetHistoricalCandles("BTC-USDT", OkexSpotPeriod.OneHour);

            /* Private Spot Api Endpoints */
            var ok11 = apiClient.Spot_GetAllBalances();
            var ok12 = apiClient.Spot_GetSymbolBalance("BTC");
            var ok13 = apiClient.Spot_GetSymbolBalance("ETH");
            var ok14 = apiClient.Spot_GetSymbolBalance("eth");
            var ok15 = apiClient.Spot_GetSymbolBills("ETH");
            var ok16 = apiClient.Spot_PlaceOrder("ETH-BTC", OkexSpotOrderSide.Sell, OkexSpotOrderType.Limit, OkexSpotTimeInForce.NormalOrder, price: 0.1m, size: 0.11m);
            var ok17 = apiClient.Spot_PlaceOrder("ETH-BTC", OkexSpotOrderSide.Sell, OkexSpotOrderType.Limit, OkexSpotTimeInForce.NormalOrder, price: 0.1m, size: 0.11m, clientOrderId: "ClientOrderId");
            var ok18 = apiClient.Spot_CancelOrder("ETH-BTC", 4275473321519104);
            var ok19 = apiClient.Spot_CancelOrder("ETH-BTC", clientOrderId: "clientorderid"); // It works: Case Insensitive
            var ok20 = apiClient.Spot_CancelOrder("ETH-BTC", clientOrderId: "CLIENTORDERID"); // It works: Case Insensitive 
            var ok21 = apiClient.Spot_GetAllOrders("ETH-BTC", OkexSpotOrderState.Canceled);
            var ok22 = apiClient.Spot_GetAllOrders("ETH-BTC", OkexSpotOrderState.Complete, 2, after: 1);
            var ok23 = apiClient.Spot_GetOpenOrders("ETH-BTC");
            var ok24 = apiClient.Spot_GetOrderDetails("ETH-BTC", clientOrderId: "clientorderid");
            var ok25 = apiClient.Spot_TradeFeeRates();

            var orders = new List<OkexSpotPlaceOrder>();
            orders.Add(new OkexSpotPlaceOrder
            {
                Symbol = "ETH-BTC",
                ClientOrderId = "ClientOrderId",
                Type = OkexSpotOrderType.Limit,
                Side = OkexSpotOrderSide.Sell,
                TimeInForce = OkexSpotTimeInForce.NormalOrder,
                Price = 0.1m,
                Size = 0.1m,
            });
            orders.Add(new OkexSpotPlaceOrder
            {
                Symbol = "ETH-BTC",
                ClientOrderId = "ClientOrderIx",
                Type = OkexSpotOrderType.Limit,
                Side = OkexSpotOrderSide.Sell,
                TimeInForce = OkexSpotTimeInForce.NormalOrder,
                Price = 0.2m,
                Size = 0.2m,
            });
            var ok26 = apiClient.Spot_PlaceOrder(orders.First());
            var ok27 = apiClient.Spot_BatchPlaceOrders(orders);

            /* Private Funding Api Endpoints */
            var ok31 = apiClient.Funding_GetAllBalances();
            var ok32 = apiClient.Funding_GetCurrencyBalance("BTC");
            var ok33 = apiClient.Funding_GetAssetValuation(OkexFundingAccountType.TotalAccountAssets, "USD");
            var ok34 = apiClient.Funding_GetSubAccount("subaccountname");
            var ok35 = apiClient.Funding_Transfer("ETH", 0.1m, OkexFundingTransferAccountType.FundingAccount, OkexFundingTransferAccountType.Spot);
            var ok36 = apiClient.Funding_Transfer("ETH", 0.3m, OkexFundingTransferAccountType.Spot, OkexFundingTransferAccountType.FundingAccount);
            var ok37 = apiClient.Funding_GetAllCurrencies();
            var ok38 = apiClient.Funding_GetBills();
            var ok41 = apiClient.Funding_GetDepositAddress("ETH");
            var ok42 = apiClient.Funding_GetDepositHistory();
            var ok43 = apiClient.Funding_GetDepositHistoryByCurrency("BTC");
            var ok44 = apiClient.Funding_GetDepositHistoryByCurrency("ETH");
            var ok45 = apiClient.Funding_GetWithdrawalFees();
            var ok46 = apiClient.Funding_GetWithdrawalFees("ETH");
            var ok47 = apiClient.Funding_Withdrawal("ETH", 1.1m, OkexFundinWithdrawalDestination.Others, "0x65b02db9b67b73f5f1e983ae10796f91ded57b64", "--fundpassword--", 0.01m);
            var ok48 = apiClient.Funding_GetWithdrawalHistory();
            var ok49 = apiClient.Funding_GetWithdrawalHistoryByCurrency("BTC");
            var ok50 = apiClient.Funding_GetWithdrawalHistoryByCurrency("ETH");

            /* Private Margin Api Endpoints */
            var ok61 = apiClient.Margin_GetAllBalances();

            //Console.ReadLine();
            //return;

            var pairs = new List<string>();
            pairs.Add("BTC-USDT");
            pairs.Add("LTC-USDT");
            pairs.Add("ETH-USDT");
            pairs.Add("XRP-USDT");
            pairs.Add("BCH-USDT");
            pairs.Add("EOS-USDT");
            pairs.Add("OKB-USDT");
            pairs.Add("ETC-USDT");
            pairs.Add("TRX-USDT");
            pairs.Add("BSV-USDT");
            pairs.Add("DASH-USDT");
            pairs.Add("NEO-USDT");
            pairs.Add("QTUM-USDT");
            pairs.Add("XLM-USDT");
            pairs.Add("ADA-USDT");
            pairs.Add("AE-USDT");
            pairs.Add("BLOC-USDT");
            pairs.Add("EGT-USDT");
            pairs.Add("IOTA-USDT");
            pairs.Add("SC-USDT");
            pairs.Add("WXT-USDT");
            pairs.Add("ZEC-USDT");

            /* OkexSocketClient Object */
            var wsClient = new OkexSocketClient(new OkexSocketClientOptions { LogVerbosity = CryptoExchange.Net.Logging.LogVerbosity.Debug });

            /* Pinging */
            // There is no open websocket connection now. So a connection will be established between server and client now, then client sends ping command. This causes latency around 500ms.
            // If you send ping command though an open socket connection, pong time is much more low.
            var ping01 = wsClient.Ping(); 
            var ping02 = wsClient.Ping();

            /* Public Socket Endpoints: */
            var subs = new List<UpdateSubscription>();
            foreach (var pair in pairs)
            {
                var candleSubscription = wsClient.Spot_SubscribeToCandlesticks(pair, OkexSpotPeriod.FiveMinutes, (data) =>
                {
                    if (data != null)
                    {
                        Console.WriteLine($"Candle >> {data.Symbol} >> ST:{data.StartTime} O:{data.Open} H:{data.High} L:{data.Low} C:{data.Close} V:{data.Volume}");
                    }
                });
                subs.Add(candleSubscription.Data);
            }
            foreach (var pair in pairs)
            {
                var tickerSubscription = wsClient.Spot_SubscribeToTicker(pair, (data) =>
                {
                    if (data != null)
                    {
                        Console.WriteLine($"Ticker >> {data.Symbol} >> LP:{data.LastPrice} LQ:{data.LastQuantity} Bid:{data.BestBidPrice} BS:{data.BestBidSize} Ask:{data.BestAskPrice} AS:{data.BestAskSize} 24O:{data.Open24H} 24H:{data.High24H} 24L:{data.Low24H} 24BV:{data.BaseVolume24H} 24QV:{data.QuoteVolume24H} ");
                    }
                });
                subs.Add(tickerSubscription.Data);
            }
            foreach (var pair in pairs)
            {
                var tradeSubscription = wsClient.Spot_SubscribeToTrades(pair, (data) =>
                {
                    if (data != null)
                    {
                        Console.WriteLine($"Trades >> {data.Symbol} >> ID:{data.TradeId} P:{data.Price} A:{data.Size} S:{data.Side} T:{data.Timestamp}");
                    }
                });
                // subs.Add(tradeSubscription.Data);
            }
            foreach (var pair in pairs)
            {
                var depthSubscription = wsClient.Spot_SubscribeToOrderBook(pair, OkexSpotOrderBookDepth.Depth400, (data) =>
                {
                    if (data != null && data.Asks != null && data.Asks.Count() > 0 && data.Bids != null && data.Bids.Count() > 0)
                    {
                        Console.WriteLine($"Depth >> {data.Symbol} >> Ask P:{data.Asks.First().Price} Q:{data.Asks.First().Quantity} C:{data.Asks.First().OrdersCount} Bid P:{data.Bids.First().Price} Q:{data.Bids.First().Quantity} C:{data.Bids.First().OrdersCount} ");
                    }
                });
                subs.Add(depthSubscription.Data);
            }


            /* Private Socket Endpoints: */
            var sockLogin = wsClient.User_Login("XXXXXXXX-API-KEY-XXXXXXXX", "XXXXXXXX-API-SECRET-XXXXXXXX", "XXXXXXXX-API-PASSPHRASE-XXXXXXXX");
            wsClient.User_Spot_SubscribeToBalance("ETH", (data) =>
            {
                if (data != null)
                {
                    Console.WriteLine($"Balance Update >> {data.Currency} >> Balance:{data.Balance} Available:{data.Available} Frozen:{data.Frozen}");
                }
            });
            wsClient.User_Spot_SubscribeToOrders("ETH-USDT", (data) =>
            {
                if (data != null)
                {
                    Console.WriteLine($"Order Update >> {data.Symbol} >> Id:{data.OrderId} State:{data.State}");
                }
            });


            /* UnSubscribe */
            // Only Trade Subscriptions remained
            foreach (var sub in subs)
            {
                wsClient.Unsubscribe(sub);
            }

            Console.ReadLine();
            return;
        }
    }
}
