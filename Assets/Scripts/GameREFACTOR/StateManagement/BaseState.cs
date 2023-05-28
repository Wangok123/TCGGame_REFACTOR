using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.StateManagement
{
    public interface IState : IGameSystem
    {
        IContainer Game { get; set; }
        StateMachine Owner { get; set; }

        void Enter();
        bool CanTransition(IState other);
        void Exit();
    }
    
    public abstract class BaseState : GameSystem, IState
    {
        public IContainer Game { get; set; }
        public StateMachine Owner { get; set; }
        public virtual void Enter() { }
        public virtual bool CanTransition(IState other) => true;
        public virtual void Exit() { }
    }
}