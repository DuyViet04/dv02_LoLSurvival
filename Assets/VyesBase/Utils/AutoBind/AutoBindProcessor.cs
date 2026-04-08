#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace VyesBase.Utils.AutoBind
{
    [InitializeOnLoad]
    public static class AutoBindProcessor
    {
        static AutoBindProcessor()
        {
            EditorApplication.hierarchyChanged += OnHierarchyChanged;
        }

        private static void OnHierarchyChanged()
        {
            if (Selection.activeGameObject)
            {
                ProcessGameObject(Selection.activeGameObject);
            }
        }

        private static void ProcessGameObject(GameObject go)
        {
            var components = go.GetComponents<MonoBehaviour>();
            foreach (var component in components)
            {
                AutoBindRuntime.Process(component);
                EditorUtility.SetDirty(component);
            }
        }
    }
}
#endif