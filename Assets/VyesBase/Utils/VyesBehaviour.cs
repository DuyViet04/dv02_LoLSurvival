using UnityEngine;

namespace VyesBase.Utils
{
    public abstract class VyesBehaviour : MonoBehaviour
    {
        protected virtual void Awake()
        {
            LoadComponents();
        }

        protected virtual void Reset()
        {
            LoadComponents();
        }

        protected virtual void LoadComponents()
        {
            //For override...
        }
    }
}