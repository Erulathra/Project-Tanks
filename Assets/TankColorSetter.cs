using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankColorSetter : MonoBehaviour
{
    [SerializeField] private Color color;

    
    // Start is called before the first frame update
    void Start()
    {
        var renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var renderer in renderers)
        {
            renderer.material.color = color;
        }
    }

}
