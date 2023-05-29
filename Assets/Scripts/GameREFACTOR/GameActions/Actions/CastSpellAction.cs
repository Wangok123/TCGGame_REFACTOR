using GameREFACTOR.Data.Cards;

namespace GameREFACTOR.GameActions.Actions
{
    public class CastSpellAction : GameAction
    {
        public Spell spell;

        public CastSpellAction (Spell spell) {
            this.spell = spell;
        }
    }
}