using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using Photon.Pun;

public class ShootingMechanics : MonoBehaviour
{
    [SerializeField] private Rigidbody _projectile;
    [SerializeField] private float _projectileSpeed = 20f;
    private PhotonView _PV;

    private void Start()
    {
        _PV = gameObject.GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _PV.IsMine)
        {
            GameObject cloneObject = PhotonNetwork.Instantiate(_projectile.name, transform.position, transform.rotation);
            Rigidbody cloneRigidbody = cloneObject.GetComponent<Rigidbody>();
            cloneRigidbody.velocity = transform.TransformDirection(Vector3.forward * _projectileSpeed);
        }
    }
}