using GameREFACTOR.Data;
using GameREFACTOR.Enums;
using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Systems
{
    /// <summary>
    /// 把牌从墓地洗回牌堆
    /// </summary>
    public class ReviveCardSystem : GameSystem, IObserve
    {
        private PlayerSystem _playerSystem;
        
        public void Awake()
        {
            _playerSystem = Container.GetSystem<PlayerSystem>();
            Global.Events.Subscribe(Notification.Perform<ReviveCardAction>(), OnReviveCard);
        }

        public void Destroy()
        {
            Global.Events.Unsubscribe(Notification.Perform<ReviveCardAction>(), OnReviveCard);
        }

        public void ReviveCard(Player player)
        {
            var action = new ReviveCardAction
            {
                Player = player,
                ReviveCards = player[Zones.Discard]
            };
            
            if (Container.GetSystem<ActionSystem>().IsActive)
            {
                Container.AddReaction(action);
            }
            else
            {
                Container.Perform(action);
            }
        }
        
        private void OnReviveCard(object sender, object args)
        {
            var action = (ReviveCardAction)args;
            
            foreach (var card in action.ReviveCards)
            {
                _playerSystem.ChangeZone(card, Zones.Deck);
            }
        }
    }
}