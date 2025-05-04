using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUp : MonoBehaviour
{
    public void PickUp()
    {
        ExpSpawner.Instance.Despawn(this.transform.parent);
    }
}
