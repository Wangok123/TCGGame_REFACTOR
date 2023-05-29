using GameREFACTOR.Data;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.Enums;
using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.GameActions.GameFlow;
using GameREFACTOR.Systems.Core;
using UnityEngine;

namespace GameREFACTOR.Systems
{
    public class PlayerActionSystem : GameSystem, IObserve
    {
        public IContainer Container { get; set; }

        public void Awake()
        {
            Global.Events.Subscribe(Notification.Perform<ChangeTurnAction>(), OnPerformChangeTurn);
            
            Global.Events.Subscribe(Notification.Validate<DrawCardsAction>(), OnValidateDrawCards);
            Global.Events.Subscribe(Notification.Perform<DrawCardsAction>(), OnPerformDrawCards);
            
            Global.Events.Subscribe(Notification.Validate<PlayCardAction>(), OnValidatePlayCard);
            Global.Events.Subscribe(Notification.Perform<PlayCardAction>(), OnPerformPlayCard);
        }

        public void Destroy()
        {
            Global.Events.Unsubscribe(Notification.Perform<ChangeTurnAction>(), OnPerformChangeTurn);
            
            Global.Events.Unsubscribe(Notification.Validate<PlayCardAction>(), OnValidatePlayCard);
            Global.Events.Unsubscribe(Notification.Perform<PlayCardAction>(), OnPerformPlayCard);
           
            Global.Events.Unsubscribe(Notification.Validate<DrawCardsAction>(), OnValidateDrawCards);
            Global.Events.Unsubscribe(Notification.Perform<DrawCardsAction>(), OnPerformDrawCards);
        }
        
        private void OnValidateDrawCards(object sender, object args)
        {
            var action = (DrawCardsAction) sender;
            var validator = (Validator) args;

            if (action.Amount > action.Player.AllCards.Count)
            {
                validator.Invalidate("没足够的牌接着抽了");
            }
        }
        
        private void OnPerformDrawCards(object sender, object args)
        {
            var action = (DrawCardsAction) args;
            //先检查一下牌堆够不够抽
            int deckCount = action.Player [Zones.Deck].Count;
            int overDrawCount = Mathf.Max(action.Amount - deckCount, 0);  //洗牌补抽的数量
            

            int roomInHand = Player.maxHand - action.player [Zones.Hand].Count;
            int overDraw = Mathf.Max ((action.amount - fatigueCount) - roomInHand, 0);
            if (overDraw > 0) {
                var overDrawAction = new OverdrawAction (action.player, overDraw);
                container.AddReaction (overDrawAction);
            }

            int drawCount = action.Amount - overDrawCount;
            action.DrawnCards = action.Player [Zones.Deck].Draw (drawCount);
            foreach (Card card in action.DrawnCards)
                container.ChangeZone (card, Zones.Hand);
        }
        
        
        private void OnValidatePlayCard(object sender, object args)
        {
            var action = (PlayCardAction) sender;
            var validator = (Validator) args;
            
            var actionCost = action.SourceCard.GetAttribute<ActionCost>();
            
            if (action.SourceCard.Owner.ActionsAvailable < actionCost.PlayCost)
            {
                validator.Invalidate("Not enough actions to play card.");
            }
        }
        
        private void OnPerformChangeTurn(object sender, object args)
        {
            var action = (ChangeTurnAction) args;
            var player = Container.GetMatch().Players[action.NextPlayerIndex];

            player.ActionsAvailable = 2;
        }
    }
}