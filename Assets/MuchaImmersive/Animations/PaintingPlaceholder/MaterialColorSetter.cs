using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorSetter : MonoBehaviour
{
    [SerializeField] private Renderer _Renderer;
    public Color Color;

    void LateUpdate()
    {
        _Renderer.material.SetColor("_Color", Color);
    }
}
