using System.Collections.Generic;
using GameREFACTOR.Data;
using GameREFACTOR.Data.Cards;

namespace GameREFACTOR.GameActions.Actions
{
    public class DrawCardsAction : GameAction
    {
        public int Amount { get; }
        public List<Card> Cards { get; set; }

        public DrawCardsAction(Player player, int amount)
        {
            this.Player = player;
            Amount = amount;
        }
    }
}
