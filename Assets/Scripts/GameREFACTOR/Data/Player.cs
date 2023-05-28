using System.Collections.Generic;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.Enums;
using UnityEngine;

namespace GameREFACTOR.Data
{
    [CreateAssetMenu(menuName = "REFACTOR/Player")]
    public class Player : ScriptableObject
    {
        public ControlMode ControlMode { get; set; }
        public int Index { get; set; }
        public int ActionsAvailable { get; set; }
        public string PlayerName { get; set; }
        
        public List<Card> AllCards  { get; }
        public List<Card> Deck       { get; }
        public List<Card> Discard    { get; }
        public List<Card> Hand       { get; }
        
        public List<Card> this[Zones z] {
            get {
                switch (z) {
                    case Zones.Deck:       return Deck;
                    case Zones.Discard:    return Discard;
                    case Zones.Hand:       return Hand;
                    default:
                        return null;
                }
            }
        }

        public Player()
        {
            AllCards = new List<Card>();
            Deck = new List<Card>();
            Discard = new List<Card>();
            Hand = new List<Card>();
        }

        public Player(int index) : this()
        {
            Index = index;
        }

        public void Initialize(GameSettings settings)
        {
            ResetState();
        }

        private void ResetState()
        {
            ActionsAvailable = 0;

            AllCards.Clear();
            Deck.Clear();
            Discard.Clear();
            Hand.Clear();
        }
    }
}