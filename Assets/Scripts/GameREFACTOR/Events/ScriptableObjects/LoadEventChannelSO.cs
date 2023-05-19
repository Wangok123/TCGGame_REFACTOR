using GameREFACTOR.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

namespace GameREFACTOR.Events.ScriptableObjects
{
    public class LoadEventChannelSO : ScriptableObject
    {
        public UnityAction<GameSceneSO, bool, bool> OnLoadingRequested;

        public void RaiseEvent(GameSceneSO locationToLoad, bool showLoadingScreen = false, bool fadeScreen = false)
        {
            if (OnLoadingRequested != null)
            {
                OnLoadingRequested.Invoke(locationToLoad, showLoadingScreen, fadeScreen);
            }
            else
            {
                Debug.LogWarning("A Scene loading was requested, but nobody picked it up. " +
                                 "Check why there is no SceneLoader already present, " +
                                 "and make sure it's listening on this Load Event channel.");
            }
        }
    }
}
