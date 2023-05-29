using GameREFACTOR.Systems;
using UnityEngine;

namespace GameREFACTOR.StateManagement.GameStates
{
    public class GameOverState : BaseState
    {
        public override void Enter()
        {
            Debug.Log("*** GAME OVER! ***");
            Global.Events.Publish(VictorySystem.GAME_OVER_NOTIFICATION);
        }

        public override bool CanTransition(IState other)
        {
            return false;
        }
    }
}