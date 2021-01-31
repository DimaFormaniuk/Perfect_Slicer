using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyFood : MonoBehaviour
{
    public event UnityAction OnCountFood;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Food food))
        {
            OnCountFood?.Invoke();
        }
        Destroy(collision.gameObject);
    }
}
