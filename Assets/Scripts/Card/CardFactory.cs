using VContainer;
using VContainer.Unity;

namespace Card
{
    public class CardFactory
    {
        private readonly IObjectResolver _resolver;

        public CardFactory(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        
        public Card CreateCard(Card cardPrefab)
        {
            var card = _resolver.Instantiate(cardPrefab);
            return card;
        }
    }
}