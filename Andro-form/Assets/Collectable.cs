using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour
{

    public UnityEvent OnTouch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SendSignal(collision.gameObject);
    }

    void SendSignal(GameObject objectThatHit)
    {
        if (objectThatHit.CompareTag("Player"))
        {
            OnTouch.Invoke();
            Destroy(gameObject);
        }
    }
}
