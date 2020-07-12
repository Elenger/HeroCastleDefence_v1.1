using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatController : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _textDefeat;
    [SerializeField] private PhotonView _photonView;
    private bool _gameOver = false;

    public void Loss()
    {
        if (!_gameOver)
        {
            _textDefeat.text = "You loss";
            Debug.Log("You loss");
            _gameOver = true;
            _photonView.RPC("Win", RpcTarget.Others);
        }
    }

    [PunRPC]
    public void Win()
    {
        _textDefeat.text = "You win";
        Debug.Log("You win");
        _gameOver = true;
    }
}
