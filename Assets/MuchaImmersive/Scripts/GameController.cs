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

    // void Update()
    // {
    //     // TODO: These conditionals will be replaced by proximity based logic
    //     if (Input.GetKeyDown(KeyCode.Alpha1)) {
    //         if (_currWall != 0)
    //         {
    //             if (_currWall != -1)
    //                 _wallControllers[_currWall].LoadNextPainting();
    //             // TODO: Pass the current painting's number to SetStateActive for specific interactions
    //             _wallControllers[0].SetStateActive();
    //             _currWall = 0;
    //             _currState = State.Active;
    //         }
    //     }

    //     if (Input.GetKeyDown(KeyCode.Alpha2)) {
    //         if (_currWall != 1)
    //         {
    //             if (_currWall != -1)
    //                 _wallControllers[_currWall].LoadNextPainting();
    //             _wallControllers[1].SetStateActive();
    //             _currWall = 1;
    //             _currState = State.Active;
    //         }
    //     }

    //     if (Input.GetKeyDown(KeyCode.Alpha3)) {
    //         if (_currWall != 2)
    //         {
    //             if (_currWall != -1)
    //                 _wallControllers[_currWall].LoadNextPainting();
    //             _wallControllers[2].SetStateActive();
    //             _currWall = 2;
    //             _currState = State.Active;
    //         }
    //     }

    //     if (Input.GetKeyDown(KeyCode.Alpha4)) {
    //         if (_currWall != 3)
    //         {
    //             if (_currWall != -1)
    //                 _wallControllers[_currWall].LoadNextPainting();
    //             _wallControllers[3].SetStateActive();
    //             _currWall = 3;
    //             _currState = State.Active;
    //         }
    //     }
    // }

    // public void ResetState()
    // {
    //     _currWall = -1;
    //     _currState = State.Idle;

    //     foreach (WallController wallController in _wallControllers)
    //     {
    //         wallController.SetStateIdle();
    //     }
    // }

    // public void LoadNextPainting()
    // {
    //     _wallControllers[_currWall].LoadNextPainting();
    //     _currWall = (_currWall + 1) % _wallControllers.Length;
    //     _wallControllers[_currWall].SetStateActive();
    // }

    // TODO: Create function to load specific painting given number
}
