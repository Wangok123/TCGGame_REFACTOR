using System.Collections;
using System.Collections.Generic;
using GameREFACTOR.Data;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.GameActions;
using UnityEngine;

public class DrawCardsAction : GameAction
{
    public int Amount;
    public List<Card> Cards;

    public DrawCardsAction(Player player, int amount)
    {
        this.Player = player;
        Amount = amount;
    }
}
