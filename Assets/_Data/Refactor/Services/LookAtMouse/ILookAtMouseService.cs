using UnityEngine;

namespace _Data.Refactor.Services.LookAtMouse
{
    public interface ILookAtMouseService
    {
        void LookAtMouse(Camera camera, Vector2 mousePosition, Transform target);
    }
}