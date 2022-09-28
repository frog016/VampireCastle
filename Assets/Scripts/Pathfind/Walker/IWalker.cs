using UnityEngine;

namespace Assets.Scripts.Pathfind.Walker
{
    public interface IWalker
    {
        Vector2 Walk(Vector2 start, Vector2 direction);
    }
}