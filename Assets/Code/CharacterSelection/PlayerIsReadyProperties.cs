using Photon.Pun;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerIsReadyProperties : MonoBehaviour
{
    private Hashtable _hash = new Hashtable();

    void Start()
    {
        _hash.Add("PlayerIsReadyProperties", false);
        PhotonNetwork.SetPlayerCustomProperties(_hash);
    }

    public void SetPlayerIsReadyPropertiesTrue()
    {
        _hash["PlayerIsReadyProperties"] = true;
        PhotonNetwork.SetPlayerCustomProperties(_hash);
    }
}
