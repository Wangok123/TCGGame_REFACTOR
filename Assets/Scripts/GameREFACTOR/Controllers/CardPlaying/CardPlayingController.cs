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
            var gameViewSystem = GetComponentInParent<GameViewSystem>();
           var container = new Container();
           
            container.AddSystem(gameViewSystem);
            container.AddSystem<CardPlayingContext>();
            
            _stateMachine = container.AddSystem<StateMachine>();
            _stateMachine.AddState(new WaitingForInputState());
            _stateMachine.AddState(new ConfirmState());
            _stateMachine.AddState(new ResetState());
            _stateMachine.ChangeState<WaitingForInputState>();
        }

        private void OnEnable()
        {
            Global.Events.Subscribe(Perform<CardPlayingController>(), OnClickNotification);
        }

        private void OnDisable()
        {
            Global.Events.Unsubscribe(Perform<CardPlayingController>(), OnClickNotification);
        }

        private void OnClickNotification(object sender, object args)
        {
            if (_stateMachine.CurrentState is IClickableHandler handler)
                handler.OnClickNotification(sender, args);
        }
    }
}