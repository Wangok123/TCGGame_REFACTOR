using System.Collections.Generic;
using GameREFACTOR.Common.Pooling.Poolers;
using GameREFACTOR.Systems;
using UnityEngine;

namespace GameREFACTOR.Views.Game
{
    public class BoardView : MonoBehaviour
    {
        public GameObject damageMarkPrefab;
        public PlayerView playerView;
        public SetPooler cardPooler;
        public SetPooler minionPooler;
    
        void Start () {
            var match = GetComponentInParent<GameViewSystem> ().Container.GetMatch ();
            
            playerView.SetPlayer(match.Players[0]);
            
        }
    }
}
