using System;
using System.Collections;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.GameActions
{/// <summary>
 /// 游戏阶段
 /// </summary>
    public class Phase
    {
        public GameAction Owner { get; }
        public Action<IContainer> Handler { get; }
        
        public Func<IContainer, GameAction, IEnumerator> Viewer { get; set; }

        public Phase(GameAction owner, Action<IContainer> handler)
        {
            Owner = owner;
            Handler = handler;
        }

        public IEnumerator Flow(IContainer gameState)
        {
            bool hitKeyFrame = false;

            if (Viewer != null)
            {
                var sequence = Viewer(gameState, Owner);
                while (sequence.MoveNext())
                {
                    var isKeyFrame = (sequence.Current is bool current) && current;

                    if (isKeyFrame)
                    {
                        hitKeyFrame = true;
                        Handler(gameState);
                    }

                    yield return null;
                }
            }

            if (!hitKeyFrame)
            {
                Handler(gameState);
            }
        }
    }
}