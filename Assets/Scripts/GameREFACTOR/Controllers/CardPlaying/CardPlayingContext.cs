using GameREFACTOR.Systems.Core;
using GameREFACTOR.Views.Game;

namespace GameREFACTOR.Controllers.CardPlaying
{
    public class CardPlayingContext : IGameSystem
    {
        public IContainer Container { get; set; }
        public CardView ActiveCardView { get; set; }
    }
}