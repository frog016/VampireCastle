using System.Collections.Generic;

namespace Assets.Scripts.Pathfind
{
    public interface IPathfinder<TCell>
    {
        List<TCell> FindPath();
    }
}