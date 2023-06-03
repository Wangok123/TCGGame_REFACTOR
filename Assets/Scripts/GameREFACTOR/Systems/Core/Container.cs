using System;
using System.Collections.Generic;

namespace GameREFACTOR.Systems.Core
{
    public interface IContainer
    {
        T AddSystem<T>(string key = null) where T : IGameSystem, new();
        T AddSystem<T>(T system, string key = null) where T : IGameSystem;
        T GetSystem<T>(string key = null) where T : IGameSystem;
        ICollection<IGameSystem> Systems();
    }

    public class Container : IContainer
    {
        private readonly Dictionary<string, IGameSystem> _systems = new();

        public T AddSystem<T>(string key = null) where T : IGameSystem, new() => AddSystem(new T(), key);

        public T AddSystem<T>(T system, string key = null) where T : IGameSystem
        {
            key ??= typeof(T).Name;

            _systems.Add(key, system);
            system.Container = this;
            return system;
        }

        public T GetSystem<T>(string key = null) where T : IGameSystem
        {
            key ??= typeof(T).Name;
            T system;
            if (_systems.ContainsKey(key))
            {
                system = (T)_systems[key];
            }
            else
            {
                throw new ArgumentException($"{key} not in Container");
            }

            return system;
        }

        public ICollection<IGameSystem> Systems()
        {
            return _systems.Values;
        }
    }
}