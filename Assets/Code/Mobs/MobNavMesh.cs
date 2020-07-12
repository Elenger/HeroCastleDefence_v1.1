using System;
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
    private const int _agrOnPlayerDistance = 10;
    private bool _stopMovement = false;
    private bool _targetIsDead = false;
    public Transform targetCharacterTransform;
    public Vector3 targetCastlePosition;

    private void SetStopMovement(int eventValue)
    {
        _stopMovement = eventValue == 1 ? true : false;
    }

    private void Awake()
    {
        if (!_photonView.IsMine) enabled = false;
    }

    private void OnEnable()
    {
        EventManager.current.LifeStatusChanged += ChangeTarget;
    }

    private void OnDisable()
    {
        EventManager.current.LifeStatusChanged -= ChangeTarget;
    }

    private void ChangeTarget(bool lifeStatus)
    {
        if (lifeStatus)
        {
            _navMeshAgent.SetDestination(targetCharacterTransform.position);
            _targetIsDead = false;
        }
        else
        {
            _navMeshAgent.SetDestination(targetCastlePosition);
            _targetIsDead = true;
        }
    }

    private void Update()
    {
        if (_stopMovement) return;

        Vector3 targetCharacterPosition = targetCharacterTransform.position;
        _distanceDifference = Vector3.Distance(targetCharacterPosition, transform.position);

        if (_distanceDifference <= _agrOnPlayerDistance && !_targetIsDead)
        {
            _navMeshAgent.SetDestination(targetCharacterPosition);
        }
        else
        {
            _navMeshAgent.SetDestination(targetCastlePosition);
        }
    }  
}
