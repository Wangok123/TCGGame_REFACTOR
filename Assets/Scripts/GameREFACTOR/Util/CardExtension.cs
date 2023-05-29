using System.Linq;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.Data.Cards.CardAttributes;

namespace GameREFACTOR.Util
{
    public static class CardExtension
    {
        public static TAttribute GetAttribute<TAttribute>(this Card card)
            where TAttribute : CardAttribute
        {
            var attribute = card.Attributes.OfType<TAttribute>().SingleOrDefault();
            return attribute;
        }
    }
}