using GameREFACTOR.Data.Cards;

namespace GameREFACTOR.GameActions.Actions
{
    public class PlayCardAction : GameAction
    {
        public Card Card { get; }

        public PlayCardAction(Card card)
        {
            this.Card = card;
        }
    }
}