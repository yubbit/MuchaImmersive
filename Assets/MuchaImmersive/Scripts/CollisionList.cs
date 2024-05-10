using System;
using System.Collections.Generic;
using UnityEngine;

public class CollisionList : MonoBehaviour
{
    public List<GameObject> CollisionObjects { get; private set; }

    void Start()
    {
        CollisionObjects = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!CollisionObjects.Contains(collider.gameObject))
        {
            CollisionObjects.Add(collider.gameObject);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (CollisionObjects.Contains(collider.gameObject))
        {
            CollisionObjects.Remove(collider.gameObject);
        }
    }
}
