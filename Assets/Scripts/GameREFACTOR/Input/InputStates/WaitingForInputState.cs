using System.Collections.Generic;
using GameREFACTOR.Data.Cards.TargetSelectors;
using GameREFACTOR.StateManagement;
using GameREFACTOR.StateManagement.GameStates;
using GameREFACTOR.Systems;
using GameREFACTOR.Views;
using GameREFACTOR.Views.UI.ToolTips;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameREFACTOR.Input.InputStates
{
    public class WaitingForInputState : BaseInputState, IClickableHandler, ITooltipContent
    {
        public void OnClickNotification(object sender, object args)
        {
            var gameStateMachine = Game.GetSystem<StateMachine>();
            var cardSystem = Game.GetSystem<CardSystem>();
            var clickData = (PointerEventData) args;
            
            if (gameStateMachine.CurrentState is not PlayerIdleState)
            {
                return;
            }
            
            var clickable = (Clickable) sender;
            var cardView = clickable.GetComponent<CardView>();
            if (cardView == null)
            {
                return;
            }
            
            InputController.SetActiveCard(cardView);
            
            InputController.TargetSelectors = new List<ManualTargetSelector>();
            InputController.SelectorIndex = 0;
            
            if (clickData.button == PointerEventData.InputButton.Right)
            {
                PreviewCard(cardView);
            }
            else if (clickData.button == PointerEventData.InputButton.Left)
            {
                DetermineDesiredAction(cardSystem, cardView);

                if (InputController.DesiredAction != null)
                {
                    PerformInputAction();
                }
            }
        }

        private void DetermineDesiredAction(CardSystem cardSystem, CardView cardView)
        {
            if (cardSystem.IsPlayable(cardView.Card))
            {
                var conditions = cardView.Card.GetTargetSelectors<ManualTargetSelector>(AbilityType.PlayCondition);
                var effects = cardView.Card.GetTargetSelectors<ManualTargetSelector>(AbilityType.PlayEffect);

                InputController.TargetSelectors.AddRange(conditions);
                InputController.TargetSelectors.AddRange(effects);

                InputController.ConditionCount = conditions.Count;
                InputController.SetDesiredAction(new PlayCardAction(cardView.Card));
            }
        }

        public string GetDescriptionText()
        {
            throw new System.NotImplementedException();
        }

        public string GetActionText(MonoBehaviour context = null)
        {
            throw new System.NotImplementedException();
        }
    }
}