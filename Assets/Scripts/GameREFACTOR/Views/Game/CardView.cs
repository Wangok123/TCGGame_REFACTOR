using GameREFACTOR.Data.Cards;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameREFACTOR.Views.Game
{
    public class CardView : MonoBehaviour
    {
        public TextMeshProUGUI costText;
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI effectText;
        public TextMeshProUGUI cardText;

        public Card Card;

        void Refresh()
        {
            costText.text = Card.cost.ToString();
            titleText.text = Card.name;
            effectText.text = Card.text;
            cardText.text = Card.description;
        }
    }
}