using UnityEngine;
using TMPro;
using Photon.Pun;

public class TimeToLoadArenaScene : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private LoadArenaScene _loadArenaScene;
    [SerializeField] private TextMeshProUGUI _timerText;
    private float _secondsToLoad;

    void Start()
    {
        _secondsToLoad = _loadArenaScene.secondsToCreation + 1;
    }

    public void StartTimer()
    {
        if (!IsInvoking())
        {
            _photonView.RPC("StartTimerRPC", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    private void StartTimerRPC()
    {
        InvokeRepeating("Timer", 0f, 1f);
    }

    private void Timer()
    {
        _secondsToLoad--;
        _timerText.text = _secondsToLoad.ToString();
    }
}
