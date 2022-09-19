using UnityEditor;

[CustomEditor(typeof(UsableItemsInstaller))]
public class UsableItemsInstallerEditor : Editor
{
    private SerializedProperty _itemsProperty;

    private void OnEnable()
    {
        _itemsProperty = serializedObject.GetIterator();
    }


    public override void OnInspectorGUI()
    {
        var count = _itemsProperty.arraySize;
        for (var i = 0; i < count; i++)
        {
            EditorGUILayout.PropertyField(_itemsProperty.GetArrayElementAtIndex(i));
        }
    }
}
