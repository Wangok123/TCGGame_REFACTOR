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

        public Card card;

        void Refresh()
        {
            costText.text = card.cost.ToString();
            titleText.text = card.name;
            effectText.text = card.text;
            cardText.text = card.description;
        }
    }
}