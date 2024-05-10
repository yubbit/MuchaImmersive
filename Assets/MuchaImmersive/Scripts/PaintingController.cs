using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingController : MonoBehaviour
{
    public enum State {
        Disabled,
        Idle,
        Active
    }

    [System.Serializable]
    public struct SubAnimationTrigger
    {
        public CollisionList CollisionList;
        public string AnimationName;
    }

    [SerializeField] GameController _gameController;    
    [SerializeField] private int[] _quadrantActivatorIndices;
    [SerializeField] private SubAnimationTrigger[] SubAnimationTriggers;
    [SerializeField] private Animator _paintingAnimator;
    public State CurrState { get; private set; }

    void Update()
    {
        if (_quadrantActivatorIndices.Contains(_gameController.CurrActiveQuadrant))
        {
            SetStateActive();
        }

        if (!_quadrantActivatorIndices.Contains(_gameController.CurrActiveQuadrant))
        {
            SetStateInactive();
        }

        foreach (SubAnimationTrigger subAnimationTrigger in SubAnimationTriggers)
        {
            int objectCount = subAnimationTrigger.CollisionList.CollisionObjects.Count;
            _paintingAnimator.SetBool("On" + subAnimationTrigger.AnimationName, objectCount > 0);
        }
    }

    public void SetStateDisabled()
    {
        // TODO: Disable music here
        _paintingAnimator.SetTrigger("SetDisabled");
        CurrState = State.Disabled;
    }

    public void SetStateIdle()
    {
        // TODO: Disable music here
        _paintingAnimator.SetTrigger("SetIdle");
        CurrState = State.Idle;
    }

    public void SetStateInactive()
    {
        // TODO: Disable music here
        _paintingAnimator.SetBool("OnQuadrant", false);
        CurrState = State.Idle;
    }

    public void SetStateActive()
    {
        // TODO: Enable music here
        _paintingAnimator.SetBool("OnQuadrant", true);        
        CurrState = State.Active;
    }
}
