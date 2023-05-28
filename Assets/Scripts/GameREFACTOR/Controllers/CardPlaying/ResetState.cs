using GameREFACTOR.StateManagement;
using GameREFACTOR.StateManagement.GameStates;
using GameREFACTOR.Systems;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Controllers.CardPlaying
{
    internal class ResetState : BaseState
    {
        public override void Enter()
        {
            base.Enter();
            Owner.ChangeState<WaitingForInputState>();
            IContainer game = Container.GetGame();

            if (!game.GetSystem<ActionSystem>().IsActive)
                game.ChangeState<PlayerIdleState>();
        }
    }
}