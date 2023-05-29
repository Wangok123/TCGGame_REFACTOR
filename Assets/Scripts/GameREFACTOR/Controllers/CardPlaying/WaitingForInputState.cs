using GameREFACTOR.Enums;
using GameREFACTOR.StateManagement;
using GameREFACTOR.StateManagement.GameStates;
using GameREFACTOR.Systems;
using GameREFACTOR.Systems.Core;
using GameREFACTOR.Views.Game;
using UnityEngine;

namespace GameREFACTOR.Controllers.CardPlaying
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
                cardView.Card.zone != Zones.Hand ||
                cardView.Card.ownerIndex != context.Game.GetMatch().CurrentPlayerIndex)
                return;

            gameStateMachine.ChangeState<PlayerInputState>();
            context.ActiveCardView = cardView;
            // owner.stateMachine.ChangeState<ShowPreviewState>();
        }
    }
}