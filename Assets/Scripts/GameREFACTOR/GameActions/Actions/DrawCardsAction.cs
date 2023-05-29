using System;
using System.Collections.Generic;
using GameREFACTOR.Data;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.Interfaces;
using GameREFACTOR.Systems;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.GameActions.Actions
{
    public class DrawCardsAction : GameAction, IAbilityLoader
    {
        public int Amount { get; set; }
        public List<Card> DrawnCards { get; set; }
        
        public DrawCardsAction(Player player, int amount)
        {
            this.Player = player;
            Amount = amount;
        }

        public void Load(IContainer game, Ability ability)
        {
            Player = game.GetMatch ().Players [0];
            Amount = Convert.ToInt32 (ability.userInfo);
        }
    }
}
