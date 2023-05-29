using GameREFACTOR.Events.ScriptableObjects;
using GameREFACTOR.SceneManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace GameREFACTOR
{
    public class Initializator : MonoBehaviour
    {
       [SerializeField] private AssetReference gameSceneReference; //Used at runtime to load the scene from the right AssetBundle
       [SerializeField] private AssetReference hudSceneReference; //Used at runtime to load the scene from the right AssetBundle


        private void Start()
        {
            gameSceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
            hudSceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);

        }
    }
}
