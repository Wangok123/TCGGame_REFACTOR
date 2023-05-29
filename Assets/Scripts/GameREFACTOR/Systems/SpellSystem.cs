using GameREFACTOR.Data;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.Systems.Core;

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
            var action = args as PlayCardAction;
            var spell = action.Card as Spell;
            if (spell != null) {
                var reaction = new CastSpellAction (spell);
                Container.AddReaction (reaction);
            }
        }

        void OnPrepareCastSpell (object sender, object args) {
            var action = args as CastSpellAction;
            var ability = action.spell.GetSystem<Ability> ();
            var reaction = new AbilityAction (ability);
            Container.AddReaction (reaction);
        }
    }
}