using GameREFACTOR.Data.Cards;
using GameREFACTOR.Systems.Core;
using Container = System.ComponentModel.Container;

namespace GameREFACTOR.Data
{
    public class Ability : Container, IGameSystem
    {
        public IContainer Container { get; set; }
        public Card card { get { return Container as Card; } }
        public string actionName { get; set; }
        public object userInfo { get; set; }
    }
}