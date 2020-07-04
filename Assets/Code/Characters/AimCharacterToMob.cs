﻿using Photon.Pun;
using System;
using Cinemachine;
using UnityEngine;

public class AimCharacterToMob : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private CharacterAutoAim _characterAutoAim;
    private int _previousMobID;
    private bool _previousObjectIsMob = false;
    private Vector3 _rayPosition;
    public CinemachineFreeLook cinemachineFreeLook;
    
    private void Awake()
    {
        if (!_photonView.IsMine) enabled = false;
    }

    private void Update()
    {
        _rayPosition = transform.position;
        _rayPosition.y = transform.position.y + 1;
        
        Vector3 direction = new Vector3(1, 0, 1);
        Vector3 cameraDirection = Vector3.Scale(cinemachineFreeLook.transform.forward, direction);
        

        Ray rayToMob = new Ray(_rayPosition, cameraDirection);

        Debug.DrawRay(_rayPosition, cameraDirection * 200, Color.red);

        if (Physics.Raycast(rayToMob, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.transform.CompareTag("Mob") && !_previousObjectIsMob)
            {
                int mobID = hit.transform.GetComponent<PhotonView>().ViewID;
                EventManager.current.OnMobHighlightingTurnOn(mobID);
                _characterAutoAim.AimCharacterToTarget(hit.transform);
                _previousObjectIsMob = true;
                _previousMobID = mobID;
            }
            else if (_previousObjectIsMob)
            {
                EventManager.current.OnMobHighlightingTurnOff(_previousMobID);
                _previousObjectIsMob = false;
            }
        }
        else if (_previousObjectIsMob)
        {
            EventManager.current.OnMobHighlightingTurnOff(_previousMobID);
            _previousObjectIsMob = false;
        }
    }
}
