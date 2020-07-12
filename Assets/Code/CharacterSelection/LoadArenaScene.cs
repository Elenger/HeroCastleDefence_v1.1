using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArenaScene : MonoBehaviour
{
    public float secondsToCreation;
    [SerializeField] private PhotonView _photonView;
    private Player _anotherPlayer;

    private void Start()
    {
        _anotherPlayer = PhotonNetwork.PlayerListOthers[0];
    }

    public void CreateCharacter()
    {
        StartCoroutine(Timer());
    }

    private void LoadArena()
    {
        _photonView.RPC("LoadArenaRPC", RpcTarget.MasterClient);
    }

    [PunRPC]
    private void LoadArenaRPC()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        SceneManager.LoadScene(2);
    }

    IEnumerator Timer()
    {
        while (true)
        {
            if (BothPlayersIsReady())
            {
                LoadArena();
            }

            yield return new WaitForSeconds(secondsToCreation);
            LoadArena();
        }
    }

    private bool BothPlayersIsReady()
    {
        bool thisPlayerIsReady = (bool) PhotonNetwork.LocalPlayer.CustomProperties["PlayerIsReadyProperties"];
        bool enemyPlayerIsReady = false;

        if (PhotonNetwork.PlayerList.Length > 1)
        {
            enemyPlayerIsReady = (bool) _anotherPlayer.CustomProperties["PlayerIsReadyProperties"];
        }
        else
        {
            Debug.Log("Second player does not exist");
            enemyPlayerIsReady = false;
            LoadArena();
        }


        if (enemyPlayerIsReady == true && thisPlayerIsReady == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
