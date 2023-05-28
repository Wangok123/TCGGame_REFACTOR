using GameREFACTOR.Data;
using GameREFACTOR.Enums;
using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.GameActions.GameFlow;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Systems
{
    public class PlayerSystem : GameSystem, IObserve
    {

        public void Awake()
        {
            Global.Events.Subscribe(Notification.Perform<ChangeTurnAction>(), OnPerformChangeTurn);
            Global.Events.Subscribe(Notification.Perform<DrawCardsAction>(), OnDrawCardsAction);
        }

        public void Destroy()
        {
            Global.Events.Unsubscribe(Notification.Perform<ChangeTurnAction>(), OnPerformChangeTurn);
            Global.Events.Unsubscribe(Notification.Perform<DrawCardsAction>(), OnDrawCardsAction);
        }

        private void OnDrawCardsAction(object sender, object args)
        {
            var action = args as DrawCardsAction;
            action.Cards = action.Player [Zones.Deck].Draw (action.Amount);
            action.Player [Zones.Hand].AddRange (action.Cards);
        }

        private void OnPerformChangeTurn(object sender, object args)
        {
            var action = args as ChangeTurnAction;
            var match = Container.GetSystem<MatchSystem>().Match;
            var player = match.Players [action.NextPlayerIndex];
            DrawCards (player, 1);
        }
        
        private void DrawCards(Player player, int amount)
        {
            var action = new DrawCardsAction (player, amount);
            Container.AddReaction (action);
        }
    }
}