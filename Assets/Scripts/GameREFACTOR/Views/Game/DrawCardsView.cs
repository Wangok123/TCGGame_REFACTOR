using System.Collections;
using System.Collections.Generic;
using GameREFACTOR;
using GameREFACTOR.Data;
using GameREFACTOR.Enums;
using GameREFACTOR.GameActions;
using GameREFACTOR.Systems.Core;
using GameREFACTOR.Views;
using UnityEngine;

public class DrawCardsView : MonoBehaviour
{
    void OnEnable () {
        Global.Events.Subscribe(Notification.Prepare<DrawCardsAction>(),OnPrepareDrawCards);
    }
    void OnDisable () {
        Global.Events.Unsubscribe(Notification.Prepare<DrawCardsAction>(),OnPrepareDrawCards);
    }
    void OnPrepareDrawCards (object sender, object args) {
        var action = args as DrawCardsAction;
        action.PerformPhase.Viewer = DrawCardsViewer;
    }
    IEnumerator DrawCardsViewer (IContainer game, GameAction action) {
        // yield return true; // perform the action logic so that we know what cards have been drawn
        // var drawAction = action as DrawCardsAction;
        // var boardView = GetComponent<BoardView> ();
        // var playerView = boardView.playerViews [drawAction.player.index];
        // for (int i = 0; i < drawAction.cards.Count; ++i) {
        //     int deckSize = action.player[Zones.Deck].Count + drawAction.cards.Count - (i + 1);
        //     playerView.deck.ShowDeckSize ((float)deckSize / (float)Player.maxDeck);
        //     var cardView = boardView.cardPooler.Dequeue ().GetComponent<CardView> ();
        //     cardView.card = drawAction.cards [i];
        //     cardView.transform.ResetParent (playerView.hand.transform);
        //     cardView.transform.position = playerView.deck.topCard.position;
        //     cardView.transform.rotation = playerView.deck.topCard.rotation;
        //     cardView.gameObject.SetActive (true);
        //     var showPreview = action.player.mode == ControlModes.Local;
        //     var addCard = playerView.hand.AddCard (cardView.transform, showPreview);
        //     while (addCard.MoveNext ())
        //         yield return null;
        // }
        yield break;
    }
}
