using UnityEditor;
using UnityEngine;

public class PoseHeightAdjuster : EditorWindow
{
    private GameObject selectedPose;
    private float heightOffset = 0f;

    [MenuItem("Tools/Patti's Pose Collection/Adjust Pose Height")]
    public static void ShowWindow()
    {
        GetWindow<PoseHeightAdjuster>("Pose Height Adjuster");
    }

    private void OnGUI()
    {
        GUILayout.Label("Adjust Pose Height", EditorStyles.boldLabel);

        selectedPose = Selection.activeGameObject;
        if (selectedPose == null)
        {
            EditorGUILayout.HelpBox("Select your pose prefab instance in the Hierarchy.", MessageType.Info);
            return;
        }

        heightOffset = EditorGUILayout.Slider("Height Offset", heightOffset, -2f, 2f);

        if (GUILayout.Button("Apply Height"))
        {
            Undo.RecordObject(selectedPose.transform, "Adjust Pose Height");
            Vector3 pos = selectedPose.transform.localPosition;
            pos.y = heightOffset;
            selectedPose.transform.localPosition = pos;
            Debug.Log($"Set {selectedPose.name} height to {heightOffset}");
        }
    }
}
