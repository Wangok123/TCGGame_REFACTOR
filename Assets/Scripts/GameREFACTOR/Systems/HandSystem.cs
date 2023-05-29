using GameREFACTOR.Data;
using GameREFACTOR.Enums;
using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Systems
{
    public class HandSystem : GameSystem, IObserve
    {
        private PlayerSystem _playerSystem;
        
        public void Awake()
        {
            _playerSystem = Container.GetSystem<PlayerSystem>();
            Global.Events.Subscribe(Notification.Perform<DrawCardsAction>(), OnPerformDrawCards);
            Global.Events.Subscribe(Notification.Perform<ReturnToHandAction>(), OnPerformReturnToHand);
        }

        public void Destroy()
        {
            Global.Events.Unsubscribe(Notification.Perform<DrawCardsAction>(), OnPerformDrawCards);
            Global.Events.Unsubscribe(Notification.Perform<ReturnToHandAction>(), OnPerformReturnToHand);
        }

        private void OnPerformReturnToHand(object sender, object args)
        {
            var action = (ReturnToHandAction) args;

            foreach (var card in action.ReturnedCards)
            {
                _playerSystem.ChangeZone(card, Zones.Hand);
            }
        }
        
        private void OnPerformDrawCards(object sender, object args)
        {   
            var action = (DrawCardsAction) args;
 
            action.DrawnCards = action.Player[Zones.Deck].Draw(action.Amount);
            foreach (var card in action.DrawnCards)
            {
                _playerSystem.ChangeZone(card, Zones.Hand);
            }
        }
        
        public void DrawCards(Player player, int amount, bool usePlayerAction = false)
        {
            var action = new DrawCardsAction(player, amount);
            
            if (Container.GetSystem<ActionSystem>().IsActive)
            {
                Container.AddReaction(action);
            }
            else
            {
                Container.Perform(action);
            }
        }
    }
}