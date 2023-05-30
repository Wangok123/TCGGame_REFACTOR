using System.Collections.Generic;
using GameREFACTOR.Data.Cards;

namespace GameREFACTOR.GameActions.Actions
{
    /// <summary>
    /// 洗牌功能
    /// </summary>
    public class ReviveCardAction : GameAction
    {
        public List<Card> ReviveCards { get; set; }
    }
}