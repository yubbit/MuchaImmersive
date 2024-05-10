using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    [SerializeField] private WallController[] _wallControllers;
    [SerializeField] private Collider[] _quadrantColliders;
    [SerializeField] private Collider[] _regionColliders;
    public int CurrActiveQuadrant { get; private set; }
    private int _currPaintingGroup;

    void Start()
    {
        Debug.Log ("displays connected: " + Display.displays.Length);

        CurrActiveQuadrant = 0;
        _currPaintingGroup = 0;
    }

    void Update()
    {
        for (int i = 0; i < _quadrantColliders.Length; i++)
        {
            CollisionList collisionList = _quadrantColliders[i].GetComponent<CollisionList>();
            if (collisionList.CollisionObjects.Count > 0)
            {
                CurrActiveQuadrant = i + 1;
                break;
            }
        }

        int activatedCount = 0;
        foreach (WallController wallController in _wallControllers)
        {
            if (wallController.CurrState == WallController.State.Activated)
            {
                ++activatedCount;
            }
        }

        if (activatedCount == 4)
        {
            foreach (WallController wallController in _wallControllers)
            {
                wallController.LoadNextPainting();
            }
        }
    }
}
