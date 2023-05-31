using System.Collections.Generic;
using GameREFACTOR.Data.Cards.CardAttributes;
using GameREFACTOR.Enums;
using UnityEngine;

namespace GameREFACTOR.Data.Cards
{
    [CreateAssetMenu(menuName = "REFACTOR/CardData")]
    public class CardData : ScriptableObject
    {
        [HideInInspector]
        public string Id;

        [Space(10)]
        public string CardName;

        [Space(10)]
        public int Cost;
        
        [TextArea]
        [Space(10)]
        public string CardDescription;

        [TextArea]
        [Space(10)]
        public string ExtraDescription;
        
        [Space(10)]
        public Tag Tags;

        [Space(10)]
        [Tooltip("This field is used to compare cards for uniqueness when cards have the 'Unique' tag. If this field is empty, the Card Name will be used instead.")]
        public string UniquenessKey;

        public string effectText;
        
        public Sprite Image;

        public List<CardAttribute> Attributes = new List<CardAttribute>();
        
    }
}