using System.Collections;
using System.Collections.Generic;
using GameREFACTOR.Data;
using GameREFACTOR.GameActions.Actions;
using UnityEngine;

public class OverdrawAction : DrawCardsAction
{
    public OverdrawAction(Player player, int amount) : base(player, amount)
    {
    }
}
