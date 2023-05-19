using UnityEngine;
using UnityEngine.Events;

namespace GameREFACTOR.Events.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GameCore/Events/IntEventChannel")]
    public class IntEventChannelSO : ScriptableObject
    {
        public UnityAction<int> OnEventRaised;

        public void RaiseEvent(int result)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(result);
        }
    }
}