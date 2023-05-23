using System.Collections.Generic;
using GameREFACTOR.Systems.Core;
using UnityEngine;

namespace GameREFACTOR.Data.Cards.TargetSelectors
{
    public abstract class BaseTargetSelector : ScriptableObject
    {
        public abstract List<Card> SelectTargets(IContainer game, Card owner);

        public abstract bool HasEnoughTargets(IContainer game, Card owner);
        
        public abstract BaseTargetSelector Clone();

        public virtual void ResetSelector()
        {
            
        }

        public virtual void InitSelector()
        {
            
        }
    }
}