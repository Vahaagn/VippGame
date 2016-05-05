namespace VippGame.Core.Interfaces
{
    public interface IGameObject : IDrawable, IUpdatable
    {
        int Id { get; }
    }
}