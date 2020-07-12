using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShaderTest : MonoBehaviour
{
    [SerializeField] private Material _material;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _material.SetFloat("Color_Multiply",10);
        }else if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            _material.SetFloat("Color_Multiply",0);
        }
    }
}
