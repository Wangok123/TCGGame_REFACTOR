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
            var context = Container.GetSystem<CardPlayingContext>();
            IContainer game = context.Game;

            if (!game.GetSystem<ActionSystem>().IsActive)
                game.ChangeState<PlayerIdleState>();
        }
    }
}