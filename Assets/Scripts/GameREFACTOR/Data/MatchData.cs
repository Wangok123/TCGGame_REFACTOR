using System.Collections.Generic;
using UnityEngine;

namespace GameREFACTOR.Data
{
    public class MatchData : ScriptableObject
    {
        public const int LOCAL_PLAYER_INDEX = 0;
        
        public List<Player> Players { get; private set; }
        public Player LocalPlayer;
        
        public int CurrentPlayerIndex;
        
        public Player CurrentPlayer => Players[CurrentPlayerIndex];

        public void Initialize(GameSettings settings)
        {
            CurrentPlayerIndex = 0;
            Players = new List<Player>(1)
            {
                LocalPlayer
            };
            
            LocalPlayer.Index = LOCAL_PLAYER_INDEX;
            LocalPlayer.PlayerName = "Player 1";
        }
    }
}