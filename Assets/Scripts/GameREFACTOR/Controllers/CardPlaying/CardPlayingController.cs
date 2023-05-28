using GameREFACTOR.Enums;
using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.StateManagement;
using GameREFACTOR.StateManagement.GameStates;
using GameREFACTOR.Systems;
using GameREFACTOR.Systems.Core;
using GameREFACTOR.Views;
using UnityEngine;
using static GameREFACTOR.Notification;

namespace GameREFACTOR.Controllers.CardPlaying
{
    public class CardPlayingController : MonoBehaviour
    {
        IContainer game;
        Container container;
        StateMachine stateMachine;
        CardView activeCardView;

        void Awake()
        {
            game = GetComponentInParent<GameViewSystem>().Container;
            container = new Container();
            stateMachine = container.AddSystem<StateMachine>();

            container.AddSystem(new WaitingForInputState()).owner = this;
            container.AddSystem(new ConfirmState()).owner = this;
            container.AddSystem(new ResetState()).owner = this;
            stateMachine.ChangeState<WaitingForInputState>();
        }

        void OnEnable()
        {
            Global.Events.Subscribe(Perform<CardPlayingController>(), OnClickNotification);
        }

        void OnDisable()
        {
            Global.Events.Unsubscribe(Perform<CardPlayingController>(),OnClickNotification);
        }

        void OnClickNotification(object sender, object args)
        {
            var handler = stateMachine.CurrentState as IClickableHandler;
            if (handler != null)
                handler.OnClickNotification(sender, args);
        }

        #region Controller States

        private interface IClickableHandler
        {
            void OnClickNotification(object sender, object args);
        }

        private abstract class BaseControllerState : BaseState
        {
            public CardPlayingController owner;
        }

        private class WaitingForInputState : BaseControllerState, IClickableHandler
        {
            public void OnClickNotification(object sender, object args)
            {
                var gameStateMachine = owner.game.GetSystem<StateMachine>();
                if (!(gameStateMachine.CurrentState is PlayerIdleState))
                    return;

                var clickable = sender as Component;
                var cardView = clickable.GetComponent<CardView>();
                if (cardView == null ||
                    cardView.card.zone != Zones.Hand ||
                    cardView.card.ownerIndex != owner.game.GetMatch().CurrentPlayerIndex)
                    return;

                gameStateMachine.ChangeState<PlayerInputState>();
                owner.activeCardView = cardView;
                // owner.stateMachine.ChangeState<ShowPreviewState>();
            }
        }

        private class ConfirmState : BaseControllerState
        {
            public override void Enter()
            {
                base.Enter();
                var action = new PlayCardAction(owner.activeCardView.card);
                owner.game.Perform(action);
                owner.stateMachine.ChangeState<ResetState>();
            }
        }

        private class ResetState : BaseControllerState
        {
            public override void Enter()
            {
                base.Enter();
                owner.stateMachine.ChangeState<WaitingForInputState>();
                if (!owner.game.GetSystem<ActionSystem>().IsActive)
                    owner.game.ChangeState<PlayerIdleState>();
            }
        }

        #endregion
    }

}