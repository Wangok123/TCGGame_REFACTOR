using System.Collections;
using System.Collections.Generic;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.Systems;
using UnityEngine;

public class BoardView : MonoBehaviour
{
    public GameObject damageMarkPrefab;
    // public List<PlayerView> playerViews;
    // public SetPooler cardPooler;
    // public SetPooler minionPooler;
    //
    // void Start () {
    //     var match = GetComponentInParent<GameViewSystem> ().container.GetMatch ();
    //     for (int i = 0; i < match.players.Count; ++i) {
    //         playerViews [i].SetPlayer (match.players[i]);
    //     }
    // }

    // public GameObject GetMatch (Card card) {
    //     var playerView = playerViews [card.ownerIndex];
    //     return playerView.GetMatch (card);
    // }
}
