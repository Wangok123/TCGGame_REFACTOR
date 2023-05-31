using System.Collections.Generic;
using GameREFACTOR.Data;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.Interfaces;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.GameActions.Actions
{
    public class DiscardAction : GameAction
    {
        public List<Card> DiscardedCards { get; set; }

        public GameAction SourceAction { get; set; }
        
    }
}