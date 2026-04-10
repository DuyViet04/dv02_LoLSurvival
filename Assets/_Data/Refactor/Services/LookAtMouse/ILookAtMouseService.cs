using UnityEngine;
using VyesBase.Core.Architecture.Interfaces;

namespace _Data.Refactor.Services.LookAtMouse
{
    public interface ILookAtMouseService : IService
    {
        void LookAtMouse(Camera camera, Vector2 mousePosition, Transform target);
    }
}