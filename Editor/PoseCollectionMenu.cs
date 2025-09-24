using UnityEditor;
using UnityEngine;

public class PoseCollectionMenu
{
    [MenuItem("Tools/Patti's Pose Collection/Add Pose Prefab")]
    public static void AddPosePrefab()
    {
        string prefabPath = "Packages/com.pattilirious.pose-collection/Runtime/Prefabs/PoseCollection.prefab";

        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (prefab == null)
        {
            Debug.LogError("Could not find prefab at: " + prefabPath);
            return;
        }

        // Check if something is selected in the hierarchy
        GameObject parent = Selection.activeGameObject;

        GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);

        if (parent != null)
        {
            // Parent under the selected object (e.g. avatar root)
            instance.transform.SetParent(parent.transform, false);
            Debug.Log("Patti's Pose Prefab added under " + parent.name);
        }
        else
        {
            Debug.Log("Patti's Pose Prefab added at scene root.");
        }

        // Select the new instance for convenience
        Selection.activeObject = instance;
    }
}
