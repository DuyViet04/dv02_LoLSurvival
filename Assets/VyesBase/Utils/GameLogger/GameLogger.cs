using UnityEngine;

namespace VyesBase.Utils.GameLogger
{
    public static class GameLogger
    {
        public static void Log(string message)
        {
            Debug.Log($"<b> Vyes Log </b>: {message}");
        }

        public static void LogWarning(string message)
        {
            Debug.LogWarning($"<b> <color=yellow> Vyes Warning </color> </b>: {message}");
        }

        public static void LogError(string message)
        {
            Debug.LogError($"<b> <color=red> Vyes Error </color> </b>: {message}");
        }
    }
}