using System.Collections;
using System.Collections.Generic;
using GameREFACTOR.Data;
using GameREFACTOR.GameActions;
using UnityEngine;

public class FatigueAction : GameAction
{
    public FatigueAction(Player player) {
        this.Player = player;
    }
}
