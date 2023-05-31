using GameREFACTOR.Data;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.Enums;
using GameREFACTOR.GameActions.Actions;
using GameREFACTOR.GameActions.GameFlow;
using GameREFACTOR.Systems.Core;
using UnityEngine;

namespace GameREFACTOR.Systems
{
    public class PlayerSystem : GameSystem, IObserve
    {
        private const int STARTING_HAND_AMOUNT = 5;
        private const int PER_TURN_AMOUNT = 5;
        private int DrawCardOffset = 0;

        private HandSystem _handSystem;
        private AbilitySystem _abilitySystem;
        private MatchData _match;

        private bool IsFirstTurn = true;
        
        public void Awake()
        {
            _handSystem = Container.GetSystem<HandSystem>();
            _abilitySystem = Container.GetSystem<AbilitySystem>();
            _match = Container.GetMatch();

            Global.Events.Subscribe(Notification.Perform<BeginGameAction>(), OnPerformBeginGame);
            Global.Events.Subscribe(Notification.Perform<ChangeTurnAction>(), OnPerformChangeTurn);
        }

        public void Destroy()
        {
            Global.Events.Unsubscribe(Notification.Perform<BeginGameAction>(), OnPerformBeginGame);
            Global.Events.Unsubscribe(Notification.Perform<ChangeTurnAction>(), OnPerformChangeTurn);
        }

        private void OnPerformBeginGame(object sender, object args)
        {
            
            _match.CurrentPlayerIndex = 0;

            Container.ChangeTurn();
        }

        private void OnPerformChangeTurn(object sender, object args)
        {
            var action = (ChangeTurnAction) args;
            var player = _match.Players[action.NextPlayerIndex];

            if (IsFirstTurn)
            {
                _handSystem.DrawCards(_match.LocalPlayer, STARTING_HAND_AMOUNT);
            }
            else
            {
                _handSystem.DrawCards(player, PER_TURN_AMOUNT + DrawCardOffset);
            }
        }

        public void ChangeZone (Card card, Zones zone, Player toPlayer = null) {
            var cardSystem = Container.GetSystem<CardSystem>();
            cardSystem.ChangeZone (card, zone, toPlayer);
        }
    }
}