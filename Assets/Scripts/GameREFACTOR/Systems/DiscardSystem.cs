using System.Collections.Generic;
using GameREFACTOR.Data;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.Enums;
using GameREFACTOR.GameActions;
using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.Interfaces;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Systems
{
    public class DiscardSystem : GameSystem ,IObserve
    {
        private PlayerSystem _playerSystem;

        public void Awake()
        {
            Global.Events.Subscribe(Notification.Perform<DiscardAction>(), OnPerformDiscard);
            _playerSystem = Container.GetSystem<PlayerSystem>();
        }
        
        public void Destroy()
        {
            Global.Events.Unsubscribe(Notification.Perform<DiscardAction>(), OnPerformDiscard);            
        }

        public void DiscardCard(Card source, Card target, GameAction sourceAction = null)
        {
            var action = new DiscardAction
            {
                SourceCard = source,
                Player = source.Owner,
                SourceAction = sourceAction,
                DiscardedCards = new List<Card> {target}
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
        
        private void OnPerformDiscard(object sender, object args)
        {
            var action = (DiscardAction) args;
            
            for (var i = action.DiscardedCards.Count - 1; i >= 0; i--)
            {
                var card = action.DiscardedCards[i];
                _playerSystem.ChangeZone(card, Zones.Discard);
            }
        }
    }
}