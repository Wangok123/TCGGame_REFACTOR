using GameREFACTOR.Enums;
using GameREFACTOR.Systems;

namespace GameREFACTOR.StateManagement.GameStates
{
    public class PlayerIdleState : BaseState
    {
        public override void Enter()
        {
            var cardSystem = Game.GetSystem<CardSystem>();
            cardSystem.Refresh(ControlMode.Local);
        }
    }
}