
using System.Collections.Generic;
using GameREFACTOR.Data.Cards.CardAttributes;
using GameREFACTOR.Enums;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Data.Cards
{
    public class Card
    {
        public CardData Data { get; }
        public Zones Zone { get; set; }
        public int OrderOfPlay { get; } = int.MaxValue;
        public Player Owner { get; set; }

        public List<CardAttribute> Attributes { get; }
        

        public Card(CardData data, Player owner, Zones zone = Zones.Deck)
        {
            Data = data;
            Owner = owner;
            Zone = zone;

            Attributes = new List<CardAttribute>();
            
            foreach (var attribute in data.Attributes)
            {
                var cloned = attribute.Clone();

                cloned.Owner = this;
                
                Attributes.Add(cloned);
            }
        }
        
        public void Load(CardData cardData)
        {
            id = cardData.Id;
            name = cardData.CardName;
            text = cardData.CardDescription;
            description = cardData.ExtraDescription;
        }

        public virtual void Load (Dictionary<string, object> data) {
            id = (string)data ["id"];
            name = (string)data ["name"];
            text = (string)data ["text"];
            cost = System.Convert.ToInt32(data["cost"]);
        }
    }
}