using UnityEngine;
using UnityEngine.EventSystems;

namespace GameREFACTOR.Input
{
    [RequireComponent(typeof(BoxCollider))]
    public class Clickable: MonoBehaviour, IPointerClickHandler
    {
        private const string CLICKED_NOTIFICATION = "Clickable.ClickedNotification";
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Global.Events.Publish(CLICKED_NOTIFICATION, eventData, this);
        }
    }
}