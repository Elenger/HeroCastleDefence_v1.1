using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHighlight : MonoBehaviour
{
    //   [SerializeField] private Material _material;
    [SerializeField] private Renderer _renderer;

    public void ShopInTarget(bool shopInTarget)
    {
        if (shopInTarget)
        {
            ShopHighlightOn();
        }
        else
        {
            ShopHighlightOff();
        }
    }

    private void ShopHighlightOn()
    {
        _renderer.material.SetFloat("EmissionMultiply", 1);
    }

    private void ShopHighlightOff()
    {
        _renderer.material.SetFloat("EmissionMultiply", 0);
    }
}
