using GameREFACTOR.Enums;
using GameREFACTOR.Systems;

namespace GameREFACTOR.StateManagement.GameStates
{
    public class PlayerIdleState : BaseState
    {
        public override void Enter()
        {
            // var cardSystem = Game.GetSystem<CardSystem>();
            // cardSystem.Refresh(ControlMode.Local);
            Temp_AutoChangeTurnForAI();
        }

        private void Temp_AutoChangeTurnForAI()
        {
            if (Container.GetMatch().CurrentPlayer.ControlMode != ControlMode.Local)
            {
                Container.GetSystem<TurnSystem>().ChangeTurn();
            }
        }
    }
}