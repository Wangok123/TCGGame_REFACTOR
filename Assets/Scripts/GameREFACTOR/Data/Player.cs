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
        public Deck SelectedDeck { get; set; }
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

        public void Initialize(GameSettings settings)
        {
            ResetState();
            var (deck, startingCharacter) = LoadPlayerData(settings);
            
        }

        private (List<CardData> deck, CardData startingCharacter) LoadPlayerData(GameSettings settings)
        {
            if (!settings.DebugMode)
            {
                return (SelectedDeck.Cards, SelectedDeck.StartingCharacter);
            }
            
            List<CardData> deck;
            CardData startingChar;
            
            if (settings.OverridePlayerDeck && ControlMode == ControlMode.Local)
            {
                deck = settings.LocalDeck;
                startingChar = settings.LocalStarting;

            }
            else
            {
                return (SelectedDeck.Cards, SelectedDeck.StartingCharacter);
            }

            return (deck, startingChar);
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