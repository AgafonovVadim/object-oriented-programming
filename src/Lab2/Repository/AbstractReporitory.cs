using System.Collections.Generic;

namespace ObjectOrientedProgramming.Lab2.Repository;

public abstract class AbstractReporitory<T> : IRepository<T>
    where T : ISellable
{
    private Dictionary<string, T> _storage = new();

    public virtual void Add(T component)
    {
        string config = component.CountConfig();
        _storage.TryAdd(config, component);
    }

    public T GetItem(string config)
    {
        return _storage[config];
    }
}