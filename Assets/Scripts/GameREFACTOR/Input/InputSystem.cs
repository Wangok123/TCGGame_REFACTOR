using System.Collections;
using System.Collections.Generic;
using GameREFACTOR.StateManagement;
using GameREFACTOR.Systems;
using GameREFACTOR.Systems.Core;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private IContainer _game;
    public GameView GameView { get; private set; }
    public StateMachine StateMachine { get; private set; }
}
