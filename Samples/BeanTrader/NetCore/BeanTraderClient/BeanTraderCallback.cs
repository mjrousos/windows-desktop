using BeanTrader;
using BeanTrader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BeanTraderClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class BeanTraderCallback : BeanTraderServiceCallback
    {
        public event Action<TradeOffer> AddNewTradeOfferHandler;
        public event Action<Guid> RemoveTradeOfferHandler;
        public event Action<TradeOffer, Guid> TradeAcceptedHandler;

        public void AddNewTradeOffer(TradeOffer offer) => AddNewTradeOfferHandler?.Invoke(offer);
        public void RemoveTradeOffer(Guid offerId) => RemoveTradeOfferHandler?.Invoke(offerId);
        public void TradeAccepted(TradeOffer offer, Guid buyerId) => TradeAcceptedHandler?.Invoke(offer, buyerId);
    }
}
