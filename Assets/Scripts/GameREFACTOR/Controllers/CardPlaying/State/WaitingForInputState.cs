using GameREFACTOR.Enums;
using GameREFACTOR.StateManagement;
using GameREFACTOR.StateManagement.GameStates;
using GameREFACTOR.Systems;
using GameREFACTOR.Views.Game;
using UnityEngine;

namespace GameREFACTOR.Controllers.CardPlaying.State
{
    internal class WaitingForInputState : BaseState, IClickableHandler
    {
        public void OnClickNotification(object sender, object args)
        {
            var context = Container.GetSystem<CardPlayingContext>();
            var gameStateMachine = context.Game.GetSystem<StateMachine>();

            if (gameStateMachine.CurrentState is not PlayerIdleState)
                return;

            if (sender is not Component component)
                return;

            var cardView = component.GetComponent<CardView>();
            if (cardView == null ||
                cardView.Card.Zone != Zones.Hand ||
                cardView.Card.Owner != context.Game.GetMatch().LocalPlayer)
                return;

            gameStateMachine.ChangeState<PlayerInputState>();
            context.ActiveCardView = cardView;
            // owner.stateMachine.ChangeState<ShowPreviewState>();
        }
    }
}