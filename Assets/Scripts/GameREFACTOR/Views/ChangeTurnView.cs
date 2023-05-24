using System;
using System.Collections;
using GameREFACTOR.Enums;
using GameREFACTOR.GameActions;
using GameREFACTOR.GameActions.GameFlow;
using GameREFACTOR.StateManagement;
using GameREFACTOR.StateManagement.GameStates;
using GameREFACTOR.Systems;
using GameREFACTOR.Systems.Core;
using UnityEngine;

namespace GameREFACTOR.Views
{
    public class ChangeTurnView : MonoBehaviour
    {
        [SerializeField] private Transform yourTurnBanner;
        [SerializeField] private ChangeTurnButtonView _buttonView;
        private IContainer game;

        private void Awake()
        {
            game = GetComponentInParent<GameViewSystem>().Container;
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
            var targetPlayer = matchSystem.Match.Players[changeTurnAction.NextPlayerIndex];

            var banner = ShowBanner(targetPlayer);
            var button = FlipButton(targetPlayer);
            var isAnimating = true;

            do
            {
                var bannerOn = banner.MoveNext();
                var buttonOn = button.MoveNext();
                isAnimating = bannerOn || buttonOn;
                yield return null;
            } while (isAnimating);
        }

        
        
        public void ChangeTurnButtonPressed()
        {
            if (CanChangeTurn())
            {
                var system = game.GetSystem<TurnSystem>();
                system.ChangeTurn();
            }
            else
            {
                
            }
        }

        private bool CanChangeTurn()
        {
            var stateMachine = game.GetSystem<StateMachine>();
            if (!(stateMachine.CurrentState is PlayerIdleState))
            {
                return false;
            }

            var player = game.GetMatch().CurrentPlayer;
            if (player.ControlMode != ControlMode.Local)
                return false;

            return true;
        }
    }
}