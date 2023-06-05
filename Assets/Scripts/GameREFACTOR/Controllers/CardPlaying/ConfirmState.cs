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
            var context = Container.GetSystem<CardPlayingContext>();
            var action = new PlayCardAction(context.ActiveCardView.Card);
            context.Game.Perform(action);
            Owner.ChangeState<ResetState>();
        }
    }
}