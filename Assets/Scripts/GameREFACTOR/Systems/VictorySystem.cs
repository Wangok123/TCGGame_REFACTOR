using System.Linq;
using GameREFACTOR.Data;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Systems
{
    public class VictorySystem : GameSystem
    {
        public const string GAME_OVER_NOTIFICATION = "VictorySystem.gameOverNotification";
        
        public Player Winner { get; private set; }

        public void SetWinner(Player winner)
        {
            Winner = winner;
        }
        
        public bool IsGameOver() => Winner != null;
        
        public bool CheckGameOver()
        {
            if (Winner != null) return true;
            
            //ToDO: 更新结算方式
            
            // var match = Container.GetMatch();
            // if (match.Players.Any(p => p.Deck.Count == 0))
            // {
            //     Winner = match.Players.Single(p => p.Deck.Count != 0);
            // }
            
            return Winner != null;
        }
    }
    
    public static class VictorySystemExtensions
    {
        public static bool CheckGameOver(this IContainer game)
        {
            return game.GetSystem<VictorySystem>().CheckGameOver();
        }
        
        public static bool IsGameOver(this IContainer game)
        {
            return game.GetSystem<VictorySystem>().IsGameOver();
        }

        public static void SetWinner(this IContainer game, Player winner)
        {
            game.GetSystem<VictorySystem>().SetWinner(winner);
        }
    }
}