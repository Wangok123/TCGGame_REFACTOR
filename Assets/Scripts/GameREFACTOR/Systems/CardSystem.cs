using System.Collections.Generic;
using GameREFACTOR.Data;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.Enums;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Systems
{
    public class CardSystem: GameSystem , IAwake
    {
        private MatchData _match;
        
        public List<Card> PlayableCards { get; set; } = new List<Card>();
        public List<Card> ActivatableCards { get; set; } = new List<Card>();
        public List<Card> SolvableAdventureCards { get; set; } = new List<Card>();
        
        public void Awake()
        {
            
        }

        public void Refresh(ControlMode mode)
        {
            PlayableCards.Clear();
            ActivatableCards.Clear();
            SolvableAdventureCards.Clear();
            
            

            
        }
        
        public bool IsPlayable(Card card) => PlayableCards.Contains(card);
        public bool IsActivatable(Card card) => ActivatableCards.Contains(card);
        public bool IsSolvable(Card card) => SolvableAdventureCards.Contains(card);
        public bool IsActionable(Card card) => IsPlayable(card) || IsActivatable(card) || IsSolvable(card);
    }
}