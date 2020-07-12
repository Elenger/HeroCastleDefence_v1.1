using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class OwnPicture : MonoBehaviour
{
    [SerializeField] Sprite[] _avatarsPictureArray;
    [SerializeField] private Image _ownImage;

    private void Start()
    {
        Player _localPlayer = PhotonNetwork.LocalPlayer;
        int avatarNumber = (int) _localPlayer.CustomProperties["AvatarNumberForEnemyPictureProperties"];
        _ownImage.sprite = _avatarsPictureArray[avatarNumber];
    }
}
