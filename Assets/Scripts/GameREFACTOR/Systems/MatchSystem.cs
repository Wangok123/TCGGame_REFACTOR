using GameREFACTOR.Data;
using GameREFACTOR.Systems.Core;

namespace GameREFACTOR.Systems
{
    public class MatchSystem : GameSystem
    {
        public MatchData Match { get; set; }
    }

    public static class MatchSystemExtensions {
        public static MatchData GetMatch(this IContainer container) => container.GetSystem<MatchSystem>().Match;
    }
}