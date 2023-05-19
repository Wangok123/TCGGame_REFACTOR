using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace GameREFACTOR.Events.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GameCore/Events/VoidEventChannel")]
    public class VoidEventChannelSO
    {
        public UnityAction OnEventRaised;
        public Func<Task> OnAsyncEventRaised;

        public void RaiseEvent()
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke();

            if (OnAsyncEventRaised != null)
                OnAsyncEventRaised.Invoke();
        }
    }
}