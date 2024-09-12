namespace ObjectOrientedProgramming.Lab2.Repository;

public interface IRepository<T>
    where T : ISellable
{
    void Add(T component);
}