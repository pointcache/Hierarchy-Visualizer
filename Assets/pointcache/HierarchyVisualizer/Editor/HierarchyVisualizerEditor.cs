namespace pointcache.HierarchyVisualizer.Editor {

    using UnityEngine;
    using UnityEditor;

    [CustomEditor(typeof(HierarchyVisualizer))]
    public class HierarchyVisualizerEditor : Editor {

        public override void OnInspectorGUI() {
            HierarchyVisualizer t = target as HierarchyVisualizer;
            if (GUILayout.Button("On")) {
                t.On();
            }

            if (GUILayout.Button("Off")) {
                t.Off();
            }
            if (GUILayout.Button("Toggle Mesh")) {
                t.ToggleMesh();
            }
        }
    }

}