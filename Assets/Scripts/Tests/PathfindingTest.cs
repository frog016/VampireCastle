using System.Linq;
using Assets.Scripts.Pathfind;
using Assets.Scripts.Pathfind.Walker;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathfindingTest : MonoBehaviour
{
    [SerializeField] private Tilemap[] _tilemaps;

    private void Awake()
    {
        Test();
    }

    private void Test()
    {
        var finder = new TilemapPathfinder(new SlideWalker());
        var path= finder.FindPath(_tilemaps);

        Debug.Log(string.Join("", path));
    }
}
