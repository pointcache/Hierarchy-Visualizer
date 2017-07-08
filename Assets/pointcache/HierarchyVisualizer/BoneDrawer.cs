#if UNITY_EDITOR
namespace pointcache.HierarchyVisualizer {
    using UnityEngine;
    using System;
    using System.Collections.Generic;
    using UnityEditor;
    public class BoneDrawer : MonoBehaviour {
        const float rad = 0.05f;
        private void OnDrawGizmos() {
            Transform tr = transform;
            Vector3 pos = tr.position;

            if (transform.parent != null) {
                Gizmos.DrawLine(pos, tr.parent.position);

                Gizmos.DrawSphere(pos, rad);
            }
        }

        private void OnDrawGizmosSelected() {
            Transform tr = transform;
            Vector3 pos = tr.position;

            if (Selection.activeGameObject == gameObject && tr.childCount > 0) {
                Handles.Label(pos, "-----------  " + name);
                Gizmos.color = Color.yellow;

                foreach (Transform t in tr) {
                    Gizmos.DrawLine(pos, t.position);
                    Gizmos.DrawWireSphere(pos, rad + 0.01f);
                    Gizmos.DrawWireSphere(t.position, rad + 0.01f);
                }


            }
            else {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(pos, rad - 0.01f);
                if (Selection.activeGameObject != tr.parent)
                    Gizmos.DrawLine(pos, tr.parent.position);
            }

        }
    }
}
#endif