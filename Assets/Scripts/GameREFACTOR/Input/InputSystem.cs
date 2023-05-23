using System;
using System.Collections.Generic;
using GameREFACTOR.Data;
using GameREFACTOR.Data.Cards.TargetSelectors;
using GameREFACTOR.GameActions;
using GameREFACTOR.Input.InputStates;
using GameREFACTOR.StateManagement;
using GameREFACTOR.Systems;
using GameREFACTOR.Systems.Core;
using GameREFACTOR.Views;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private IContainer _game;
    public GameViewSystem GameView { get; private set; }
    public StateMachine StateMachine { get; private set; }
    public CardView ActiveCard { get; private set; }
    public Player ActivePlayer { get; private set; }
    public GameAction DesiredAction { get; private set; }
    
    public List<ManualTargetSelector> TargetSelectors { get; set; }
    public int SelectorIndex { get; set; }
    public int ConditionCount { get; set; }

    private void Awake()
    {
        GameView = GetComponent<GameViewSystem>();
        _game = GameView.Container;
        
        StateMachine = new StateMachine
        {
            Container = GameView.Container
        };
        
        StateMachine.AddState( new WaitingForInputState { InputController = this } );
        StateMachine.AddState( new PreviewState { InputController = this } );
        StateMachine.AddState( new DiscardPilePreviewState { InputController = this } );
        StateMachine.AddState( new TargetingState { InputController = this } );
        StateMachine.AddState( new CancelableTargetingState { InputController = this } );
        StateMachine.AddState( new ResetState { InputController = this } );

        StateMachine.ChangeState<WaitingForInputState>();
    }

    public void SetActiveCard(CardView cardView)
    {
        ActiveCard = cardView;
        ActivePlayer = cardView.Card.Owner;
    }
}
