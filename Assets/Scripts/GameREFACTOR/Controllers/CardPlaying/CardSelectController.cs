using GameREFACTOR.Views.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameREFACTOR.Notification;

namespace GameREFACTOR.Controllers.CardPlaying
{
    public class CardSelectController : MonoBehaviour,IPointerClickHandler
    {
        [SerializeField] private CardView cardView;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Global.Events.Publish(Perform<CardSelectController>(),cardView,this);
        }
    }
}