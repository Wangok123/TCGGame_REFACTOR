using GameREFACTOR.StateManagement;
using GameREFACTOR.StateManagement.GameStates;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Systems
{
    public class GlobalGameStateSystem : GameSystem, IObserve
    {
        public void Awake()
        {
            Global.Events.Subscribe(ActionSystem.BEGIN_SEQUENCE_NOTIFICATION, OnBeginSequence);
            Global.Events.Subscribe(ActionSystem.COMPLETE_NOTIFICATION, OnCompleteAllActions);
        }


        private void OnBeginSequence(object sender, object args)
        {
            Container.ChangeState<SequenceState>();
        }
        
        
        private void OnCompleteAllActions(object sender, object args)
        {
            if(Container.CheckGameOver())
            {
                Container.ChangeState<GameOverState>();
            }
            
            Container.ChangeState<PlayerIdleState>();
        }
        
        public void Destroy()
        {
            Global.Events.Unsubscribe(ActionSystem.BEGIN_SEQUENCE_NOTIFICATION, OnBeginSequence);
            Global.Events.Unsubscribe(ActionSystem.COMPLETE_NOTIFICATION, OnCompleteAllActions);
        }
    }
}