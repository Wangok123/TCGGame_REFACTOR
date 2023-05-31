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
            costText.text = Card.Data.Cost.ToString();
            titleText.text = Card.Data.name;
            effectText.text = Card.Data.effectText;
            cardText.text = Card.Data.CardDescription;
        }
    }
}