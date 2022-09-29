using System.Collections.Generic;

namespace Assets.Scripts.Pathfind.Walker
{
    public interface IWalker<TCell, in TMap>
    {
        IEnumerable<TCell> Walk(TCell start, TCell direction, TMap map);
    }
}