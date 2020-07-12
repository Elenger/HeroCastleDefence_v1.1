using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Photon.Pun;

public class Fireball : MonoBehaviour
{
    [SerializeField] private GameObject _explosionVFX;
    
    private void OnCollisionEnter(Collision other)
    {
        PhotonView.Get(this).RPC("DestroyObject", RpcTarget.All);
        if (_explosionVFX != null)
        {
            PhotonNetwork.Instantiate(_explosionVFX.name, transform.position, transform.rotation);
        }
    }

    private void Start()
    {
        StartCoroutine(DestroyObjectCoroutines());    
    }

    [PunRPC]
    private void DestroyObject()
    {
    PhotonNetwork.Destroy(gameObject);
    }

    IEnumerator DestroyObjectCoroutines()
    {
        for (;;)
        {
            yield return new WaitForSeconds(10.0f);
            PhotonView.Get(this).RPC("DestroyObject", RpcTarget.All);
        }
    }
}
