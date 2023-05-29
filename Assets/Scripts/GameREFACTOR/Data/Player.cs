using System.Collections.Generic;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.Enums;
using UnityEngine;

namespace GameREFACTOR.Data
{
    [CreateAssetMenu(menuName = "REFACTOR/Player")]
    public class Player : ScriptableObject
    {
        
        public const int maxDeck = 30;
        public const int maxHand = 10;
        public const int maxBattlefield = 7;
        public const int maxSecrets = 5;
        
        public ControlMode ControlMode { get; set; }
        public int Index { get; set; }
        public string PlayerName { get; set; }
        public Mana mana  = new Mana ();
        
        public List<Card> AllCards  { get; }
        public List<Card> Deck       { get; }
        public List<Card> Discard    { get; }
        public List<Card> Hand       { get; }
        public List<Card> Bugs       { get; }

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

    public class Deck
    {
        public List<CardData> Cards { get; set; }
        public CardData StartingCharacter { get; set; }
    }
}