﻿using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class MobNavMesh : MonoBehaviourPun
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private PhotonView _photonView;
    private float _distanceDifference;
    public Vector3 targetCharacterPosition;
    public Vector3 targetCastlePosition;

    private void Update()
    {
        _distanceDifference = Vector3.Distance(targetCharacterPosition, transform.position);
        if (_distanceDifference <= 10)
        {
            Debug.Log("Current target is Player's character");
            _navMeshAgent.SetDestination(targetCharacterPosition);
        }
        else
        {
            Debug.Log("Current target is Player's castle");
            _navMeshAgent.SetDestination(targetCastlePosition);
        }
    }  
}
