using GameREFACTOR.Data.Cards;
using GameREFACTOR.Views.UI.ToolTips;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameREFACTOR.Views
{
    public class CardView : MonoBehaviour
    {
        public Image cardBack;
        public Image cardFront;
        public TextMeshProUGUI healthText;
        public TextMeshProUGUI attackText;
        public TextMeshProUGUI manaText;
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI cardText;
        
        public bool isFaceUp { get; private set; }
        public Card card;
        private GameObject[] faceUpElements;
        private GameObject[] faceDownElements;
        
        void Awake () {
            faceUpElements = new GameObject[] {
                cardFront.gameObject, 
                healthText.gameObject, 
                attackText.gameObject, 
                manaText.gameObject, 
                titleText.gameObject,
                cardText.gameObject
            };
            faceDownElements = new GameObject[] {
                cardBack.gameObject
            };
            Flip (isFaceUp);
        }
        
        public void Flip (bool shouldShow) {
            isFaceUp = shouldShow;
            var show = shouldShow ? faceUpElements : faceDownElements;
            var hide = shouldShow ? faceDownElements : faceUpElements;
            Toggle (show, true);
            Toggle (hide, false);
            Refresh ();
        }
        
        void Toggle (GameObject[] elements, bool isActive) {
            for (int i = 0; i < elements.Length; ++i) {
                elements [i].SetActive (isActive);
            }
        }
        
        void Refresh () {
            if (isFaceUp == false)
                return;
            manaText.text = card.cost.ToString ();
            titleText.text = card.name;
            cardText.text = card.text;
            
        }
    }
}