namespace GameREFACTOR.GameActions.GameFlow
{
    public class ChangeTurnAction : GameAction
    {
        public int NextPlayerIndex { get; }

        public ChangeTurnAction(int targetPlayerIndex)
        {
            NextPlayerIndex = targetPlayerIndex;
        }
    }
}