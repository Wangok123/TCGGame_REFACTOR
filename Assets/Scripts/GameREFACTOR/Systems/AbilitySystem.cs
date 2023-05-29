using System;
using GameREFACTOR.GameActions;
using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.Interfaces;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Systems
{
    public class AbilitySystem : GameSystem, IObserve
    {
        public void Awake()
        {
            Global.Events.Subscribe(Notification.Perform<AbilityAction>(), OnPerformAbilityAction);
        }

        public void Destroy()
        {
            Global.Events.Unsubscribe(Notification.Perform<AbilityAction>(), OnPerformAbilityAction);
        }
        
        void OnPerformAbilityAction (object sender, object args) {
            var action = args as AbilityAction;
            var type = Type.GetType (action.ability.actionName);
            var instance = Activator.CreateInstance (type) as GameAction;
            if (instance is IAbilityLoader loader)
                loader.Load (Container, action.ability);
            Container.AddReaction (instance);
        }
    }
}