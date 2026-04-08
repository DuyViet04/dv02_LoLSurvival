using UnityEngine;

namespace VyesBase.Systems.Combat
{
    public interface IDamageSource
    {
        string GetSourceName();
        GameObject GetOwner();
    }
}