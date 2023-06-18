using GameREFACTOR.Controllers.CardPlaying.State;
using GameREFACTOR.StateManagement;
using GameREFACTOR.Systems;
using GameREFACTOR.Systems.Core;
using UnityEngine;
using static GameREFACTOR.Notification;

namespace GameREFACTOR.Controllers.CardPlaying
{
    public class CardPlayingController : MonoBehaviour
    {
        StateMachine _stateMachine;

        private void Awake()
        {
            IContainer game = FindObjectOfType<GameViewSystem>().Container;
            var container = new Container();

            var context = container.AddSystem<CardPlayingContext>();
            context.Game = game;

            _stateMachine = container.AddSystem<StateMachine>();
            _stateMachine.AddState(new WaitingForInputState());
            _stateMachine.AddState(new ConfirmState());
            _stateMachine.AddState(new ResetState());
            _stateMachine.ChangeState<WaitingForInputState>();
        }

        private void OnEnable()
        {
            Global.Events.Subscribe(Perform<CardSelectController>(), OnClickNotification);
        }

        private void OnDisable()
        {
            Global.Events.Unsubscribe(Perform<CardSelectController>(), OnClickNotification);
        }

        private void OnClickNotification(object sender, object args)
        {
            if (_stateMachine.CurrentState is IClickableHandler handler)
                handler.OnClickNotification(sender, args);
        }
    }
}