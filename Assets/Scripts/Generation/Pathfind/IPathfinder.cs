namespace Assets.Scripts.Pathfind
{
    public interface IPathfinder<out TCell, in TMap>
    {
        TCell[] FindPath(TMap map);
    }
}