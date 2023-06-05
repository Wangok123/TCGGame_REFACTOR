using System.Collections;
using GameREFACTOR.StateManagement;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Controllers.Shared
{
    public abstract class ControllerState
    {
        private IStateMachineController StateMachine { get; set; }

        public abstract IEnumerator OnStateEnter();

        public abstract bool CanTransition(IState other);

        public abstract IEnumerator OnStateExit();
    }
}