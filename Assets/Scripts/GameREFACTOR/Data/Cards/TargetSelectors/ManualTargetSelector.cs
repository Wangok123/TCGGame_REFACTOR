using System.Collections.Generic;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Data.Cards.TargetSelectors
{
    public class ManualTargetSelector : BaseTargetSelector
    {
        public override List<Card> SelectTargets(IContainer game, Card owner)
        {
            throw new System.NotImplementedException();
        }

        public override bool HasEnoughTargets(IContainer game, Card owner)
        {
            throw new System.NotImplementedException();
        }

        public override BaseTargetSelector Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}