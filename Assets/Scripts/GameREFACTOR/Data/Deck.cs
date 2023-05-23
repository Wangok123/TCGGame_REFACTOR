using System.Collections.Generic;
using GameREFACTOR.Data.Cards;

namespace GameREFACTOR.Data
{
    public class Deck
    {
        public string DeckId { get; private set; }
        public string DeckName { get; private set; }
        
        public CardData StartingCharacter { get; set; }
        public List<CardData> Cards { get; } = new List<CardData>();
        
        private Deck() { }
        
        public static Deck Load(SerializedDeck serializedDeck, CardLibrary library)
        {
            // TODO: Error handling when GetById fails ... Do we need to denote the game version in each save file to ensure these are valid?
            var loadedDeck = new Deck
            {
                DeckId = serializedDeck.Id,
                DeckName = serializedDeck.Name,
                StartingCharacter = library.GetById(serializedDeck.StartingCharacterId)
            };

            foreach (var cardId in serializedDeck.Cards)
            {
                var cardData = library.GetById(cardId);
                loadedDeck.Cards.Add(cardData);
            }

            return loadedDeck;
        }
    }
}