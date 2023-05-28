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
            IContainer game = Container.GetGame();
            var gameStateMachine = game.GetSystem<StateMachine>();

            if (gameStateMachine.CurrentState is not PlayerIdleState)
                return;

            if (sender is not Component component)
                return;
            
            var cardView = component.GetComponent<CardView>();
            if (cardView == null ||
                cardView.card.zone != Zones.Hand ||
                cardView.card.ownerIndex != game.GetMatch().CurrentPlayerIndex)
                return;

            gameStateMachine.ChangeState<PlayerInputState>();
            var context = Container.GetSystem<CardPlayingContext>();
            context.ActiveCardView = cardView;
            // owner.stateMachine.ChangeState<ShowPreviewState>();
        }
    }
}