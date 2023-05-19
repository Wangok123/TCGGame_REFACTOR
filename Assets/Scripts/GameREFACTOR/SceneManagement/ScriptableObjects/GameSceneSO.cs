using UnityEngine.AddressableAssets;

namespace GameREFACTOR.SceneManagement
{
    public class GameSceneSO
    {
        public GameSceneType sceneType;
        public AssetReference sceneReference; //Used at runtime to load the scene from the right AssetBundle
        
        public enum GameSceneType
        {
            //Playable scenes
            Location, //SceneSelector tool will also load PersistentManagers and Gameplay
            Menu, //SceneSelector tool will also load Gameplay

            //Special scenes
            Initialisation,
            PersistentManagers,
            Gameplay,

            //Work in progress scenes that don't need to be played
            Art,
        }
    }
}