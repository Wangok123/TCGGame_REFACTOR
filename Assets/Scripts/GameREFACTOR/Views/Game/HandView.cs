using System.Collections;
using System.Collections.Generic;
using GameREFACTOR.Common.Animation;
using GameREFACTOR.Common.Pooling;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.GameActions;
using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.Systems.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameREFACTOR.Views.Game
{
    public class HandView : MonoBehaviour
    {
        public List<Transform> cards = new List<Transform>();
        public Transform handArea;
        public Transform activeHandle;
        public Transform inactiveHandle;
        
        [SerializeField] private float addCardDuration = 0.1f;


        private void OnEnable()
        {
            Global.Events.Subscribe(Notification.Validate<PlayCardAction>(), OnValidatePlayCard);
        }

        private void OnDisable()
        {
            Global.Events.Unsubscribe(Notification.Validate<PlayCardAction>(), OnValidatePlayCard);
        }

        public IEnumerator AddCard(Transform card, bool showPreview, bool overDraw)
        {
            if (showPreview)
            {
                IEnumerator preview = ShowPreview(card);
                while (preview.MoveNext())
                    yield return null;

                var tweener = card.Wait(addCardDuration);
                while (tweener != null)
                    yield return null;
            }

            if (overDraw)
            {
                var discard = OverdrawCard(card);
                while (discard.MoveNext())
                    yield return null;
            }
            else
            {
                cards.Add(card);
                var layout = LayoutCards();
                while (layout.MoveNext())
                    yield return null;
            }
        }

        public IEnumerator ShowPreview(Transform card)
        {
            Tweener tweener = null;
            card.RotateTo(activeHandle.rotation);
            tweener = card.MoveTo(activeHandle.position, Tweener.DefaultDuration, EasingEquations.EaseOutBack);
            
            while (tweener != null)
            {
                yield return null;
            }
        }

        public IEnumerator LayoutCards(bool animated = true)
        {
            var overlap = 0.4f;
            var width = cards.Count * overlap;
            var xPos = -(width / 2f);
            var duration = animated ? 0.25f : 0;

            Tweener tweener = null;
            for (int i = 0; i < cards.Count; ++i)
            {
                var canvas = cards[i].GetComponentInChildren<Canvas>();
                canvas.sortingOrder = i;

                var position = inactiveHandle.position + new Vector3(xPos, 0, 0);
                cards[i].RotateTo(inactiveHandle.rotation, duration);
                tweener = cards[i].MoveTo(position, duration);
                xPos += overlap;
            }

            while (tweener != null)
                yield return null;
        }

        public CardView GetView(Card card)
        {
            foreach (Transform t in cards)
            {
                var cardView = t.GetComponent<CardView>();
                if (cardView.Card == card)
                {
                    return cardView;
                }
            }

            return null;
        }

        public void Dismiss(CardView card)
        {
            cards.Remove(card.transform);

            card.gameObject.SetActive(false);
            card.transform.localScale = Vector3.one;

            var poolable = card.GetComponent<Poolable>();
            var pooler = GetComponentInParent<BoardView>().cardPooler;
            pooler.Enqueue(poolable);
        }

        IEnumerator OverdrawCard(Transform card)
        {
            yield break;
            // Tweener tweener = card.ScaleTo(Vector3.zero, 0.5f, EasingEquations.EaseInBack);
            // while (tweener != null)
            //     yield return null;
            // Dismiss(card.GetComponent<CardView>());
        }

        void OnValidatePlayCard(object sender, object args)
        {
            var action = sender as PlayCardAction;
            if (GetComponentInParent<PlayerView>().Player.Index == action.Card.ownerIndex)
            {
                action.PerformPhase.Viewer = PlayCardViewer;
                action.CancelPhase.Viewer = CancelPlayCardViewer;
            }
        }

        IEnumerator PlayCardViewer(IContainer game, GameAction action)
        {
            var playAction = action as PlayCardAction;
            CardView cardView = GetView(playAction.Card);
            if (cardView == null)
                yield break;

            cards.Remove(cardView.transform);
            StartCoroutine(LayoutCards(true));
            var discard = OverdrawCard(cardView.transform);
            while (discard.MoveNext())
                yield return null;
        }

        IEnumerator CancelPlayCardViewer(IContainer game, GameAction action)
        {
            var layout = LayoutCards(true);
            while (layout.MoveNext())
                yield return null;
        }
    }
}