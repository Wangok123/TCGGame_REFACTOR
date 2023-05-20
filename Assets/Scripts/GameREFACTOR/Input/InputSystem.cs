using GameREFACTOR.Data;
using GameREFACTOR.StateManagement;
using GameREFACTOR.Systems;
using GameREFACTOR.Systems.Core;
using GameREFACTOR.Views;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private IContainer _game;
    public GameView GameView { get; private set; }
    public StateMachine StateMachine { get; private set; }
    public CardView ActiveCard { get; private set; }
    public Player ActivePlayer { get; private set; }
}
