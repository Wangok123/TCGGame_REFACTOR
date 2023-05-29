using System.Collections.Generic;
using GameREFACTOR.Data;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.Enums;
using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Systems
{
    public class CardSystem: GameSystem , IAwake
    {
        private MatchData _match;
        
        public List<Card> PlayableCards { get; set; } = new List<Card>();  //手牌中可用卡

        public void Awake()
        {
            
        }

        /// <summary>
        /// 每次操作结束，进入PlayerIdle阶段时，在这里刷新牌的状态
        /// </summary>
        /// <param name="mode"></param>
        public void Refresh(ControlMode mode)
        {
            PlayableCards.Clear();

            foreach (var card in _match.CurrentPlayer[Zones.Hand])
            {
                var playAction = new PlayCardAction(card);
                if (playAction.Validate().Validate())
                {
                    PlayableCards.Add(card);
                }
            }
        }
        
        public bool IsPlayable(Card card) => PlayableCards.Contains(card);
        public bool IsActionable(Card card) => IsPlayable(card);

        public void ChangeZone(Card card, Zones zone, Player toPlayer = null)
        {
            var fromPlayer = card.Owner;
            toPlayer = toPlayer ?? fromPlayer;
            fromPlayer [card.Zone].Remove (card);
            toPlayer [zone].Add (card);
            card.Zone = zone;
            card.Owner = toPlayer;
        }
    }
}