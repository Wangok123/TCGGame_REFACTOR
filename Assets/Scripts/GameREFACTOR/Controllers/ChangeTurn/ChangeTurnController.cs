using System;
using GameREFACTOR.Data;
using GameREFACTOR.Enums;
using GameREFACTOR.StateManagement;
using GameREFACTOR.StateManagement.GameStates;
using GameREFACTOR.Systems;
using GameREFACTOR.Systems.Core;
using UnityEngine;
using UnityEngine.UI;

namespace GameREFACTOR.Controllers.ChangeTurn
{
    public class ChangeTurnController : MonoBehaviour
    {
        [SerializeField] private Button changeTurnButton;

        private IContainer _game;

        private void Awake()
        {
            _game = FindObjectOfType<GameViewSystem>().Container;
        }

        private void OnEnable()
        {
            changeTurnButton.onClick.AddListener(ChangeTurnButtonPressed);
        }

        private void OnDisable()
        {
            changeTurnButton.onClick.RemoveListener(ChangeTurnButtonPressed);
        }


        public void ChangeTurnButtonPressed()
        {
            if (!CanChangeTurn())
                return;

            var system = _game.GetSystem<TurnSystem>();
            system.ChangeTurn();
        }

        private bool CanChangeTurn()
        {
            var stateMachine = _game.GetSystem<StateMachine>();

            if (stateMachine.CurrentState is not PlayerIdleState)
                return false;

            Player player = _game.GetMatch().CurrentPlayer;

            return player.ControlMode == ControlMode.Local;
        }
    }
}