using UnityEditor;
using UnityEngine;

public class PoseCollectionMenu
{
    [MenuItem("Tools/Patti's Pose Collection/Add Pose Prefab")]
    public static void AddPosePrefab()
    {
        // Path inside your package zip (Runtime/Prefabs/PattiPose.prefab)
        string prefabPath = "Packages/com.pattilirious.pose-collection/Runtime/Prefabs/PattiPose.prefab";

        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (prefab != null)
        {
            PrefabUtility.InstantiatePrefab(prefab);
            Debug.Log("Patti's Pose Prefab added to the scene!");
        }
        else
        {
            Debug.LogError("Could not find prefab at: " + prefabPath);
        }
    }
}