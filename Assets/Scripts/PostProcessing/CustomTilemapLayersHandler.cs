using Edgar.Unity;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Edgar/Custom tilemap layers handler", fileName = "CustomTilemapLayersHandler")]
public class CustomTilemapLayersHandler : TilemapLayersHandlerBaseGrid2D
{
    public override void InitializeTilemaps(GameObject gameObject)
    {
        gameObject.AddComponent<Grid>();
        CreateTilemapGameObject("Floor", gameObject, 0);

        var wallsTilemapObject = CreateTilemapGameObject("Walls", gameObject, 1);
        AddCompositeCollider(wallsTilemapObject);
    }

    protected GameObject CreateTilemapGameObject(string name, GameObject parentObject, int sortingOrder)
    {
        var tilemapObject = new GameObject(name);
        tilemapObject.transform.SetParent(parentObject.transform);
        tilemapObject.AddComponent<Tilemap>();

        var tilemapRenderer = tilemapObject.AddComponent<TilemapRenderer>();
        tilemapRenderer.sortingOrder = sortingOrder;

        return tilemapObject;
    }

    protected void AddCompositeCollider(GameObject tilemapGameObject, bool isTrigger = false)
    {
        var tilemapCollider2D = tilemapGameObject.AddComponent<TilemapCollider2D>();
        tilemapCollider2D.usedByComposite = true;

        var compositeCollider2d = tilemapGameObject.AddComponent<CompositeCollider2D>();
        compositeCollider2d.geometryType = CompositeCollider2D.GeometryType.Outlines;
        compositeCollider2d.isTrigger = isTrigger;

        tilemapGameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}