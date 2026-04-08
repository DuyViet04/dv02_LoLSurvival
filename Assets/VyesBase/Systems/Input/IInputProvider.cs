using UnityEngine;

namespace VyesBase.Systems.Input
{
    public interface IInputProvider
    {
        Vector2 MoveInput { get; }
        Vector2 MousePosition { get; }
        bool Jump { get; }
    }
}