using GameREFACTOR.Data;

namespace GameREFACTOR.GameActions.Actions
{
    public class AbilityAction : GameAction
    {
        public Ability ability;

        public AbilityAction (Ability ability) {
            this.ability = ability;
        }
    }
}