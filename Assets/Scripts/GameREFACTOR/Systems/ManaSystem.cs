using GameREFACTOR.Data;
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
            var player = Container.GetMatch().Players[playCardAction.card.ownerIndex];
            if (player.mana.Available < playCardAction.card.cost)
                validator.Invalidate("费不够");
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
            mana.spent += action.card.cost;
            Global.Events.Publish(ValueChangedNotification,mana);
        }
    }
}