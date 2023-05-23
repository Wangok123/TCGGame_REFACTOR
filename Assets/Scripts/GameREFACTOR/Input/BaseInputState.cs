using GameREFACTOR.StateManagement;

namespace GameREFACTOR.Input
{
    public class BaseInputState : BaseState
    {
        public InputSystem InputController { get; set; }
    }
}