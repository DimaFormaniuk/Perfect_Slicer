using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnifeBlade : MonoBehaviour
{
    public event UnityAction OnDizziness;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            OnDizziness?.Invoke();
        }
    }
}
