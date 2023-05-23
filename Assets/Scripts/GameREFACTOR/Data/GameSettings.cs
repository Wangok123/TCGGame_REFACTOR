using System.Collections.Generic;
using GameREFACTOR.Data.Cards;
using UnityEngine;

namespace GameREFACTOR.Data
{
    [CreateAssetMenu(menuName = "REFACTOR/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public float TweenTimescale;
        
        public bool DebugMode;
        
        [HideInInspector] public bool OverridePlayerDeck;
        [HideInInspector] public CardData LocalStarting;
        [HideInInspector] public List<CardData> LocalDeck;
    }
}