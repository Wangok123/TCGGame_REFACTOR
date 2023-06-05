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
            Debug.Log($"Click {sender} {args}");
            var context = Container.GetSystem<CardPlayingContext>();
            var gameStateMachine = context.Game.GetSystem<StateMachine>();

            if (gameStateMachine.CurrentState is not PlayerIdleState)
                return;

            if (args is not CardView cardView)
                return;

            if (!Validate(cardView, context)) 
                return;

            Debug.Log("ChangeState PlayerInputState");
            gameStateMachine.ChangeState<PlayerInputState>();
            context.ActiveCardView = cardView;
            
            Owner.ChangeState<ShowPreviewState>();
        }

        private static bool Validate(CardView cardView, CardPlayingContext context)
        {
            if (cardView == null)
                return false;
            
            if (cardView.Card.Zone != Zones.Hand)
                return false;
            
            if (cardView.Card.Owner != context.Game.GetMatch().LocalPlayer)
                return false;
            
            return true;
        }
    }
}