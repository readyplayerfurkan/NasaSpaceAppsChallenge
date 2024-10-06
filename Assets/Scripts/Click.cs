using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField] private GameEvent onCircleClicked;
    public float lifeTime;

    void Update()
    {
        Destroy(gameObject,lifeTime);
    }
    void OnMouseDown()
    {
       onCircleClicked.Raise();

       Destroy(gameObject); // Destroy the target
    }
}
