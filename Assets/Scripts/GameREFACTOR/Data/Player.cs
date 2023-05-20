using GameREFACTOR.Enums;
using UnityEngine;

namespace GameREFACTOR.Data
{
    [CreateAssetMenu(menuName = "REFACTOR/Player")]
    public class Player : ScriptableObject
    {
        public ControlMode ControlMode { get; set; }
        public int Index { get; set; }
        public int ActionsAvailable { get; set; }
        public Deck SelectedDeck { get; set; }
    }
}