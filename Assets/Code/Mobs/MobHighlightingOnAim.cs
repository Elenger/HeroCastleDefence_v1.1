using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHighlightingOnAim : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private Material _materialWithHighlight;
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private GameObject _circle;
    private int _mobID;

    //On Mob Destroy we also need to destroy Materials
    private void Start()
    {
        _circle.SetActive(false);
        _mobID = _photonView.ViewID;

    }

    private void OnEnable()
    {
        EventManager.current.MobHighlightingStatusChanged += HighlightingChange;
    }

    private void OnDisable()
    {
        EventManager.current.MobHighlightingStatusChanged -= HighlightingChange;
    }


    private void HighlightingChange(bool highlightingStatus, int mobEventID)
    {
        if (_mobID == mobEventID)
        {
            if (highlightingStatus)
            {
                _circle.SetActive(true);
                _renderer.material.SetFloat("Color_Multiply",10);
            }
            else
            {
                _circle.SetActive(false);
                _renderer.material.SetFloat("Color_Multiply",0);
            }
        }
    }
}
