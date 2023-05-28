using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.StateManagement;
using GameREFACTOR.Systems;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Controllers.CardPlaying
{
    internal class ConfirmState : BaseState
    {
        public override void Enter()
        {
            base.Enter();
            var context = Container.GetSystem<CardPlayingContext>();
            var action = new PlayCardAction(context.ActiveCardView.card);
            Container.GetGame().Perform(action);
            Owner.ChangeState<ResetState>();
        }
    }
}