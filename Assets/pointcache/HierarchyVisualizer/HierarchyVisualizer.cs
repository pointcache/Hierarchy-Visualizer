#if UNITY_EDITOR
namespace pointcache.HierarchyVisualizer
{
    using UnityEngine;
    using System;
    using System.Collections.Generic;
    using UnityEditor;

    /// <summary>
    /// Tool that shows the bones in viewport, you can also select the bones. 
    /// Dont forget to disable it after you finished work.
    /// Toggle mesh modifies hide flags, be aware.
    /// </summary>
    public class HierarchyVisualizer : MonoBehaviour
    {
        [SerializeField]
        private bool HideMesh = true;

        public void ToggleMesh()
        {
            var mr = GetComponent<SkinnedMeshRenderer>();
            if (!mr)
            {
                mr = GetComponentInChildren<SkinnedMeshRenderer>();
            }
            mr.enabled = !mr.enabled;
        }

        public void On()
        {
            AddDrawersRecursive(transform);
            var mr = GetComponent<SkinnedMeshRenderer>();
            if (!mr)
            {
                mr = GetComponentInChildren<SkinnedMeshRenderer>();
            }
            mr.enabled = !HideMesh;
            mr.gameObject.hideFlags = HideFlags.NotEditable;
        }

        public void Off()
        {
            RemoveDrawersRecursive(transform);
            var mr = GetComponent<SkinnedMeshRenderer>();
            if (!mr)
            {
                mr = GetComponentInChildren<SkinnedMeshRenderer>();
            }
            mr.enabled = true;
            mr.gameObject.hideFlags = HideFlags.None;

        }

        /// <summary>
        /// Adds bone drawers to whole hierarchy
        /// </summary>
        /// <param name="tr"></param>
        void AddDrawersRecursive(Transform tr)
        {
            if (tr.childCount > 0)
            {
                foreach (Transform t in tr)
                {
                    if (!t.gameObject.GetComponent<BoneDrawer>())
                        t.gameObject.AddComponent<BoneDrawer>();
                    AddDrawersRecursive(t);
                }
            }
        }

        void RemoveDrawersRecursive(Transform tr)
        {
            if (tr.childCount > 0)
            {
                foreach (Transform t in tr)
                {
                    var drawer = t.gameObject.GetComponent<BoneDrawer>();
                    if (drawer)
                        DestroyImmediate(drawer);
                    RemoveDrawersRecursive(t);
                }
            }
        }
    }
}
#endif