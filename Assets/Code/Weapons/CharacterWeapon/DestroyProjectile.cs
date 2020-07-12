using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DestroyProjectile : MonoBehaviour
{ 
    void Start()
    {
        StartCoroutine(DestroyCoroutines());
    }

    IEnumerator DestroyCoroutines()
    {
        for (;;)
        {
            yield return new WaitForSeconds(3.0f);
            PhotonView.Get(this).RPC("DestroyObject", RpcTarget.All);
        }
    }

    [PunRPC]
    private void DestroyObject()
    {
        PhotonNetwork.Destroy(gameObject);
    }

}
