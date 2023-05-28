using GameREFACTOR.Data;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.Enums;
using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.GameActions.GameFlow;
using GameREFACTOR.Systems.Core;
using UnityEngine;

namespace GameREFACTOR.Systems
{
    public class PlayerSystem : GameSystem, IObserve
    {

        public void Awake()
        {
            Global.Events.Subscribe(Notification.Perform<ChangeTurnAction>(), OnPerformChangeTurn);
            Global.Events.Subscribe(Notification.Perform<DrawCardsAction>(), OnDrawCardsAction);
            Global.Events.Subscribe(Notification.Perform<FatigueAction>(), OnPerformFatigue);
            Global.Events.Subscribe(Notification.Perform<OverdrawAction>(), OnPerformOverDraw);
            Global.Events.Subscribe(Notification.Perform<PlayCardAction>(), OnPerformPlayCard);
        }

        public void Destroy()
        {
            Global.Events.Unsubscribe(Notification.Perform<ChangeTurnAction>(), OnPerformChangeTurn);
            Global.Events.Unsubscribe(Notification.Perform<DrawCardsAction>(), OnDrawCardsAction);
            Global.Events.Unsubscribe(Notification.Perform<FatigueAction>(), OnPerformFatigue);
            Global.Events.Unsubscribe(Notification.Perform<OverdrawAction>(), OnPerformOverDraw);
            Global.Events.Unsubscribe(Notification.Perform<PlayCardAction>(), OnPerformPlayCard);

        }

        private void OnDrawCardsAction(object sender, object args)
        {
            var action = args as DrawCardsAction;
            int deckCount = action.Player [Zones.Deck].Count;
            int fatigueCount = Mathf.Max(action.Amount - deckCount, 0);
            for (int i = 0; i < fatigueCount; ++i) {
                var fatigueAction = new FatigueAction (action.Player);
                Container.AddReaction (fatigueAction);
            }
            int roomInHand = Player.maxHand - action.Player [Zones.Hand].Count;
            int overDraw = Mathf.Max ((action.Amount - fatigueCount) - roomInHand, 0);
            if (overDraw > 0) {
                var overDrawAction = new OverdrawAction (action.Player, overDraw);
                Container.AddReaction (overDrawAction);
            }
            int drawCount = action.Amount - fatigueCount - overDraw;
            action.Cards = action.Player [Zones.Deck].Draw (drawCount);
            foreach (Card card in action.Cards)
                ChangeZone (card, Zones.Hand);
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
        
        private void OnPerformFatigue (object sender, object args) {
            var action = args as FatigueAction;
        }
        
        private void OnPerformOverDraw (object sender, object args) {
            var action = args as OverdrawAction;
            action.Cards = action.Player [Zones.Deck].Draw (action.Amount);
            foreach (Card card in action.Cards)
                ChangeZone (card, Zones.Graveyard);
        }
        
        private void ChangeZone (Card card, Zones zone, Player toPlayer = null) {
            var cardSystem = Container.GetSystem<CardSystem>();
            cardSystem.ChangeZone (card, zone, toPlayer);
        }
        
        private void OnPerformPlayCard (object sender, object args) {
            var action = args as PlayCardAction;
            if (action.Card.zone == Zones.Hand)
                ChangeZone (action.Card, Zones.Graveyard);
        }
    }
}