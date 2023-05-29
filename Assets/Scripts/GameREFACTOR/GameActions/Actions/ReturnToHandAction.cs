using System.Collections.Generic;
using GameREFACTOR.Data;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.Interfaces;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.GameActions.Actions
{
    public class ReturnToHandAction : GameAction
    {
        public List<Card> ReturnedCards { get; set; }
    }
}