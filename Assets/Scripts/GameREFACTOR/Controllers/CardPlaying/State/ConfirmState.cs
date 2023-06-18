using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.StateManagement;
using GameREFACTOR.Systems;

namespace GameREFACTOR.Controllers.CardPlaying.State
{
    internal class ConfirmState : BaseState
    {
        public override void Enter()
        {
            base.Enter();
            var context = Container.GetSystem<CardPlayingContext>();
            var action = new PlayCardAction(context.ActiveCardView.Card);
            context.Game.Perform(action);
            Owner.ChangeState<ResetState>();
        }
    }
}