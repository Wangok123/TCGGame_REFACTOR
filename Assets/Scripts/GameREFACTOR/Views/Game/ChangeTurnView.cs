using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using GameREFACTOR.Data;
using GameREFACTOR.Enums;
using GameREFACTOR.GameActions;
using GameREFACTOR.GameActions.GameFlow;
using GameREFACTOR.StateManagement;
using GameREFACTOR.StateManagement.GameStates;
using GameREFACTOR.Systems;
using GameREFACTOR.Systems.Core;
using UnityEngine;

namespace GameREFACTOR.Views.Game
{
    public class ChangeTurnView : MonoBehaviour
    {
        // [SerializeField] private Transform yourTurnBanner;
        [SerializeField] private ChangeTurnButtonView _buttonView;
        private IContainer _game;

        private void Awake()
        {
            _game = FindObjectOfType<GameViewSystem>().Container;
        }

        private void OnEnable()
        {
            Global.Events.Subscribe(Notification.Prepare<ChangeTurnAction>(), OnPrepareChangeTurn);
        }

        private void OnDisable()
        {
            Global.Events.Unsubscribe(Notification.Prepare<ChangeTurnAction>(), OnPrepareChangeTurn);
        }


        private void OnPrepareChangeTurn(object sender, object args)
        {
            var action = args as ChangeTurnAction;
            action.PerformPhase.Viewer = ChangeTurnViewer;
        }

        private IEnumerator ChangeTurnViewer(IContainer game, GameAction action)
        {
            var matchSystem = game.GetSystem<MatchSystem>();
            var changeTurnAction = action as ChangeTurnAction;
            Player targetPlayer = matchSystem.Match.Players[changeTurnAction.NextPlayerIndex];

            // var banner = ShowBanner(targetPlayer);
            IEnumerator button = FlipButton(targetPlayer);
            bool isAnimating = true;

            do
            {
                // var bannerOn = banner.MoveNext();
                bool buttonOn = button.MoveNext();
                isAnimating = buttonOn;
                yield return null;
            } while (isAnimating);
        }



        // IEnumerator ShowBanner(Player targetPlayer)
        // {
        //     if (targetPlayer.ControlMode != ControlMode.Local)
        //         yield break;
        //
        //     var tweener = yourTurnBanner.DOScale(Vector3.one, 0.25f);
        //     while (tweener.IsPlaying())
        //     {
        //         yield return null;
        //     }
        //
        //     yield return new WaitForSeconds(1);
        //
        //     tweener = yourTurnBanner.DOScale(Vector3.zero, 0.25f);
        //     while (tweener.IsPlaying())
        //     {
        //         yield return null;
        //     }
        // }

        private IEnumerator FlipButton(Player targetPlayer)
        {
            Quaternion up = Quaternion.identity;
            Quaternion down = Quaternion.Euler(new Vector3(180, 0, 0));
            Quaternion targetRotation = targetPlayer.ControlMode == ControlMode.Local ? up : down;
            TweenerCore<Quaternion, Vector3, QuaternionOptions> tweener =
                _buttonView.RotationHandle.DORotate(targetRotation.eulerAngles, 0.5f);
            while (tweener.IsPlaying()) yield return null;
        }
    }
}