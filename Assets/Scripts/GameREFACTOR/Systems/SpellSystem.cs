using GameREFACTOR.Data;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.Systems.Core;
using GameREFACTOR.Util;

namespace GameREFACTOR.Systems
{
    public class SpellSystem : GameSystem, IObserve
    {
        public void Awake()
        {
            Global.Events.Subscribe(Notification.Perform<PlayCardAction>(), OnPeformPlayCard);
            Global.Events.Subscribe(Notification.Perform<CastSpellAction>(), OnPrepareCastSpell);
        }

        public void Destroy()
        {
            Global.Events.Unsubscribe(Notification.Perform<PlayCardAction>(), OnPeformPlayCard);
            Global.Events.Unsubscribe(Notification.Perform<CastSpellAction>(), OnPrepareCastSpell);
        }
        
        void OnPeformPlayCard (object sender, object args) {
            
        }

        void OnPrepareCastSpell (object sender, object args) {
            
        }
    }
}