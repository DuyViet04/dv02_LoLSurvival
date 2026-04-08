#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace VyesBase.Utils.AutoBind
{
    public static class AutoBindRuntime
    {
        public static void Process(MonoBehaviour target)
        {
            // Lấy toàn bộ Field trong target có Attribute = AutoBind
            var fields = target.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttribute<AutoBindAttribute>() != null);

            foreach (var field in fields)
            {
                var fieldType = field.FieldType;
                
                // Lấy giá trị tại Field và kiểm tra Null
                var value = field.GetValue(target);
                bool isNullOrEmpty = value == null || (value is Object obj && obj == null);

                if (!isNullOrEmpty) continue;

                // Lấy các thông số của Attribute
                var attr = field.GetCustomAttribute<AutoBindAttribute>();
                var scope = attr.Scope;
                var path = attr.Path;

                var searchType = fieldType;
                Object result = null;

                switch (scope)
                {
                    case BindScope.Self:
                        if (searchType == typeof(GameObject)) result = target.gameObject;
                        else result = target.GetComponent(searchType);
                        break;
                    case BindScope.Parent:
                        if (searchType == typeof(GameObject))
                        {
                            if (target.transform.parent != null) result = target.transform.parent.gameObject;
                        }
                        else
                        {
                            result = target.GetComponentInParent(searchType, true);
                        }
                        break;
                    case BindScope.Children:
                        if (string.IsNullOrEmpty(path))
                        {
                            // Chỉ tìm con trực tiếp
                            foreach (Transform child in target.transform)
                            {
                                var c = child.GetComponent(searchType);
                                if (c != null)
                                {
                                    result = c;
                                    break;
                                }
                                if (searchType == typeof(GameObject))
                                {
                                    result = child.gameObject;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            var t = target.transform.Find(path);
                            if (t != null)
                            {
                                result = t.GetComponent(searchType) ??
                                         (searchType == typeof(GameObject) ? (Object)t.gameObject : null);
                            }
                        }
                        break;
                    case BindScope.Scene:
                        if (string.IsNullOrEmpty(path))
                        {
                            result = Object.FindAnyObjectByType(searchType);
                        }
                        else
                        {
                            var go = GameObject.Find(path);
                            if (go != null)
                            {
                                result = go.GetComponent(searchType) ??
                                         (searchType == typeof(GameObject) ? (Object)go : null);
                            }
                        }
                        break;
                    case BindScope.Global:
                        result = FindAsset(searchType, path);
                        break;
                }

                if (result != null)
                {
                    field.SetValue(target, result);

                    GameLogger.GameLogger.Log(
                        $"[AutoBind] <color=yellow>{target.name}</color>: Load <color=yellow> {field.Name} ({fieldType.Name}) </color>");
                }
                else
                {
                    GameLogger.GameLogger.LogError(
                        $"[AutoBind] <color=yellow> {field.Name} ({fieldType.Name}) </color> not find in <color=yellow> {target.name} </color>");
                }
            }
        }

        #region HELPER_FUNCTIONS

        // Hàm tìm Asset theo kiểu dữ liệu và Path
        private static Object FindAsset(Type type, string path)
        {
            return AssetDatabase.LoadAssetAtPath(path, type);
        }

        #endregion
    }
}
#endif