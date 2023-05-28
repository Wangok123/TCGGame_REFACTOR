using UnityEngine;
using UnityEngine.EventSystems;

namespace GameREFACTOR.Controllers.CardPlaying
{
    public class CardSelectController : MonoBehaviour,IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Woc");
            Global.Events.Publish(Notification.Perform<CardSelectController>());
        }
    }
}