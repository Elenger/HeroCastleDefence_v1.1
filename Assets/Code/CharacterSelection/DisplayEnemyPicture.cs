using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class DisplayEnemyPicture : MonoBehaviour
{
    [SerializeField] Sprite[] _avatarsPictureArray;
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private Image _imageForEnemyAvatar;
    private Player _anotherPlayer;
    private Hashtable _hash = new Hashtable();
    public int myAvatarNumberForEnemyPlayer;

    private void Start()
    {
        _anotherPlayer = PhotonNetwork.PlayerListOthers[0];
        _hash.Add("AvatarNumberForEnemyPictureProperties", myAvatarNumberForEnemyPlayer);
    }

    public void SetMyAvatarPicturesNumber(int avatarNumber)
    {
        myAvatarNumberForEnemyPlayer = avatarNumber;
        SetAvatarNumberForEnemyPictureProperties();
    }

    private void SetAvatarNumberForEnemyPictureProperties()
    {
        _hash["AvatarNumberForEnemyPictureProperties"] = myAvatarNumberForEnemyPlayer;
        PhotonNetwork.SetPlayerCustomProperties(_hash);
        _photonView.RPC("SetAvatarNumberForEnemyPicturePropertiesRPC", RpcTarget.Others);
    }

    [PunRPC]
    private void SetAvatarNumberForEnemyPicturePropertiesRPC()
    {
        int avatarNumber = (int) _anotherPlayer.CustomProperties["AvatarNumberForEnemyPictureProperties"];
        _imageForEnemyAvatar.sprite = _avatarsPictureArray[avatarNumber];
    }
}
