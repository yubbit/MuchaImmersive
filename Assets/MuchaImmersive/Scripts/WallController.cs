using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [System.Serializable]
    public struct Painting
    {
        public int PaintingNumber;
        public PaintingController PaintingController;    
    }

    public enum State 
    {
        Idle,
        Activated
    }

    // [SerializeField] private GameObject AudioController;
    [SerializeField] private Painting[] Paintings;
    public Painting CurrPainting { get => Paintings[_currPaintingIndex]; }
    private int _currPaintingIndex;
    public State CurrState { get; private set; }

    void Start()
    {
        CurrState = State.Idle;
        _currPaintingIndex = 0;
        CurrPainting.PaintingController.SetStateIdle();
    }

    void Update()
    {
        if (CurrState == State.Idle &&
            CurrPainting.PaintingController.CurrState == PaintingController.State.Active)
        {
            CurrState = State.Activated;
        }

        foreach (Painting painting in Paintings)
        {
            if (painting.PaintingNumber != CurrPainting.PaintingNumber)
            {
                painting.PaintingController.SetStateDisabled();
            }
        }
    }

    public void LoadNextPainting()
    {
        CurrPainting.PaintingController.SetStateDisabled();
        _currPaintingIndex = (_currPaintingIndex + 1) % Paintings.Length;
        CurrPainting.PaintingController.SetStateIdle();

        CurrState = State.Idle;
    }

    void ResetState()
    {
        foreach (Painting painting in Paintings)
        {
            painting.PaintingController.SetStateDisabled();
        }
        _currPaintingIndex = 0;
        CurrPainting.PaintingController.SetStateIdle();

        CurrState = State.Idle;
    }
}
