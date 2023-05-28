using GameREFACTOR.StateManagement;

namespace GameREFACTOR.Systems.Core
{
    public static class GameFactory
    {
        public static Container Create()
        {
            Container game = new Container();
            
            // Add System
            game.AddSystem<ActionSystem>();
            game.AddSystem<MatchSystem>();
            game.AddSystem<TurnSystem>();
            game.AddSystem<GlobalGameStateSystem>();
            game.AddSystem<PlayerSystem>();
            
            // Add Others
            game.AddSystem<StateMachine>();
            return game;
        }
    }
}