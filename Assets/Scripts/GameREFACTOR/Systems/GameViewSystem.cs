using System;
using GameREFACTOR.Enums;
using GameREFACTOR.StateManagement;
using GameREFACTOR.StateManagement.GameStates;
using GameREFACTOR.Systems.Core;
using UnityEngine;

namespace GameREFACTOR.Systems
{
    [RequireComponent(typeof(InputSystem))]
    public class GameViewSystem : MonoBehaviour, IGameSystem
    {
        private IContainer _container;
        public IContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = GameFactory.Create();
                    _container.AddSystem(this);
                }

                return _container;
            }
            
            set => _container = value;
        }

        private ActionSystem _actionSystem;

        private void Awake()
        {
            Container.Awake();
            _actionSystem = Container.GetSystem<ActionSystem>();
        }

        private void Start()
        {
            Temp_SetupSinglePlayer();
            Container.ChangeState<PlayerIdleState>();
        }

        private void Update()
        {
            _actionSystem.Update();
        }

        private void Temp_SetupSinglePlayer()
        {
            var match = Container.GetMatch();
            match.Players[0].ControlMode = ControlMode.Local;
        }
    }
}
