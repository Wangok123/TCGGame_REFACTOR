using GameREFACTOR.Data;
using GameREFACTOR.StateManagement;

namespace GameREFACTOR.Systems.Core
{
    public static class GameFactory
    {
        public static Container Create(MatchData match, GameSettings settings)
        {
            Container game = new Container();
            
            match.Initialize(settings);
            
            // Add System
            game.AddSystem<ActionSystem>();
            game.AddSystem<MatchSystem>().Match = match;
            game.AddSystem<TurnSystem>();
            game.AddSystem<GlobalGameStateSystem>();
            game.AddSystem<PlayerSystem>();
            game.AddSystem<ManaSystem>();
            game.AddSystem<CardSystem>();
            // Add Others
            game.AddSystem<StateMachine>();
            return game;
        }
    }
}