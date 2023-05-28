using GameREFACTOR.Data;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Interfaces
{
    public interface IAbilityLoader
    {
        void Load (IContainer game, Ability ability);
    }
}