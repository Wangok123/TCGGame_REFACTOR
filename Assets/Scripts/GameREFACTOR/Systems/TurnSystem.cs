using GameREFACTOR.Data;
using GameREFACTOR.GameActions.GameFlow;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Systems
{
    public class TurnSystem : GameSystem, IObserve
    {
        private MatchData _match;
        
        /// <summary>
        /// 单人游戏所以只有一个人的回合
        /// </summary>
        public void ChangeTurn()
        {
            var action = new ChangeTurnAction(0);

            if (Container.GetSystem<ActionSystem>().IsActive)
            {
                Container.AddReaction(action);
            }
            else
            {
                Container.Perform(action);
            }
        }

        public void Awake()
        {
            _match = Container.GetMatch();
            Global.Events.Subscribe(Notification.Perform<ChangeTurnAction>(), OnPerformChangeTurn);
        }
        
        private void OnPerformChangeTurn(object sender, object args)
        {
            var action = (ChangeTurnAction) args;

            _match.CurrentPlayerIndex = action.NextPlayerIndex;
        }

        public void Destroy()
        {
            Global.Events.Unsubscribe(Notification.Perform<ChangeTurnAction>(), OnPerformChangeTurn);
        }
    }
    
    public static class TurnSystemExtensions
    {
        public static void ChangeTurn(this IContainer game)
        {
            var turnSystem = game.GetSystem<TurnSystem>();
            turnSystem.ChangeTurn();
        }
    }
}