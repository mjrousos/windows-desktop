using BeanTrader.Models;
using System;
using CoreWCF;

namespace BeanTrader
{
    public interface IBeanTraderCallback
    {
        [OperationContract(IsOneWay = true)]
        void AddNewTradeOffer(TradeOffer offer);

        [OperationContract(IsOneWay = true)]
        void RemoveTradeOffer(Guid offerId);

        [OperationContract(IsOneWay = true)]
        void TradeAccepted(TradeOffer offer, Guid buyerId);
    }
}