using System.Collections;
using GameREFACTOR.Common.Extensions;
using GameREFACTOR.Enums;
using GameREFACTOR.GameActions;
using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.Systems.Core;
using UnityEngine;

namespace GameREFACTOR.Views.Game
{
    public class DrawCardsView : MonoBehaviour
    {
        private void OnEnable()
        {
            Global.Events.Subscribe(Notification.Prepare<DrawCardsAction>(), OnPrepareDrawCards);
        }

        private void OnDisable()
        {
            Global.Events.Unsubscribe(Notification.Prepare<DrawCardsAction>(), OnPrepareDrawCards);
        }

        private void OnPrepareDrawCards(object sender, object args)
        {
            if (args is not DrawCardsAction action)
                return;

            action.PerformPhase.Viewer = DrawCardsViewer;
        }

        private IEnumerator DrawCardsViewer(IContainer game, GameAction action)
        {
            yield return true; // perform the action logic so that we know what cards have been drawn
            if (action is not DrawCardsAction drawAction)
                yield break;

            var boardView = GetComponent<BoardView>();
            PlayerView playerView = boardView.playerView;

            for (int i = 0; i < drawAction.Cards.Count; ++i)
            {
                int deckSize = action.Player[Zones.Deck].Count + drawAction.Cards.Count - (i + 1);

                playerView.deck.ShowDeckSize((float)deckSize / (float)30);
                var cardView = boardView.cardPooler.Dequeue().GetComponent<CardView>();
                cardView.card = drawAction.Cards[i];
                cardView.transform.ResetParent(playerView.hand.transform);
                cardView.transform.position = playerView.deck.topCard.position;
                cardView.transform.rotation = playerView.deck.topCard.rotation;
                cardView.gameObject.SetActive(true);
                var showPreview = action.Player.ControlMode == ControlMode.Local;
                var addCard = playerView.hand.AddCard(cardView.transform, showPreview, false);
                while (addCard.MoveNext())
                    yield return null;
            }
        }
    }
}