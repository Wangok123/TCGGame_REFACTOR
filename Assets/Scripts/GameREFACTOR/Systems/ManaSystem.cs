﻿using GameREFACTOR.Data;
using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.GameActions.GameFlow;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Systems
{
    public class ManaSystem : GameSystem , IObserve
    {
        public const string ValueChangedNotification = "ManaSystem.ValueChangedNotification";
        
        public void Awake()
        {
            Global.Events.Subscribe(Notification.Perform<ChangeTurnAction>(), OnPerformChangeTurn);
            Global.Events.Subscribe(Notification.Perform<PlayCardAction>(), OnPerformPlayCard);
            Global.Events.Subscribe(Notification.Validate<PlayCardAction>(), OnValidatePlayCard);
        }


        public void Destroy()
        {
            Global.Events.Unsubscribe(Notification.Perform<ChangeTurnAction>(), OnPerformChangeTurn);
            Global.Events.Unsubscribe(Notification.Perform<PlayCardAction>(), OnPerformPlayCard);
            Global.Events.Unsubscribe(Notification.Validate<PlayCardAction>(), OnValidatePlayCard);
        }

        private void OnValidatePlayCard(object sender, object args)
        {
            var playCardAction = sender as PlayCardAction;
            var validator = args as Validator;
            var player = playCardAction.Card.Owner;
            if (player.mana.Available < playCardAction.Card.Data.Cost)
                validator.Invalidate("Not Enough Mana");
        }

        private void OnPerformChangeTurn(object sender, object args)
        {
            var mana = Container.GetMatch ().CurrentPlayer.mana;
            if (mana.permanent < Mana.MaxSlots)
                mana.permanent++;
            mana.spent = 0;
            mana.overloaded = mana.pendingOverloaded;
            mana.pendingOverloaded = 0;
            mana.temporary = 0;
            Global.Events.Publish(ValueChangedNotification,mana);
        }
        
        private void OnPerformPlayCard(object sender, object args)
        {
            var action = args as PlayCardAction;
            var mana = Container.GetMatch ().CurrentPlayer.mana;
            mana.spent += action.Card.Data.Cost;
            Global.Events.Publish(ValueChangedNotification,mana);
        }
    }
}