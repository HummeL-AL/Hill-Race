public interface IGameFactory : IFactory
{
    public Player CreatePlayer();

    public MapLoader CreateMap();

    public HUD CreateHud();
}