using System.Collections.Generic;
using GameREFACTOR.Enums;
using UnityEngine;

namespace GameREFACTOR.Data.Cards
{
    public class CardData : ScriptableObject
    {
        [HideInInspector]
        public string Id;

        [Space(10)]
        public string CardName;

        [TextArea]
        [Space(10)]
        public string CardDescription;

        [Space(10)]
        public Tag Tags;

        [Space(10)]
        [Tooltip("This field is used to compare cards for uniqueness when cards have the 'Unique' tag. If this field is empty, the Card Name will be used instead.")]
        public string UniquenessKey;

        [HideInInspector]
        public Sprite Image;

        [HideInInspector]
        public List<CardAttribute> Attributes = new List<CardAttribute>();

        [HideInInspector]
        public CardType Type;
    }
}