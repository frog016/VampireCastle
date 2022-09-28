using System.Linq;
using Assets.Scripts.Pathfind;
using Assets.Scripts.Pathfind.Walker;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathfindingTest : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;

    private void Awake()
    {
        Test();
    }

    private void Test()
    {
        var finder = new TilemapPathfinder(_tilemap, new SlideWalker(_tilemap));
        var path= finder.FindPath();

        Debug.Log(string.Join("", path));
    }
}
