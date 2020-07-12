using Photon.Pun;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviourPunCallbacks
{
    [SerializeField] private Slider _slider;

    [SerializeField] private PhotonView _photonView;
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private Transform _mainCameraTransform;
    [SerializeField] private CinemachineFreeLook _cinemachineFreeLook;

    [SerializeField] private ShopUpgradeCharacterController shopUpgradeCharacterController;
    private GameObject _currentCharacter;

    public void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _photonView.RPC("SpawnCharacter", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    private void SpawnCharacter()
    {
        Transform spawnPoint = (PhotonNetwork.IsMasterClient ? _spawnPoints[0] : _spawnPoints[1]);

        _currentCharacter = PhotonNetwork.Instantiate(SelectedCharacter.Prefab.name,
        spawnPoint.position, Quaternion.identity);


        ThirdPersonMovement thirdPersonMovement = _currentCharacter.GetComponent<ThirdPersonMovement>();
        thirdPersonMovement.mainCameraTransform = _mainCameraTransform;
        thirdPersonMovement.cinemachineFreeLook = _cinemachineFreeLook;
        MobCreation mobCreation = gameObject.GetComponent<MobCreation>();
        mobCreation.targetCharacter = _currentCharacter;

        CharacterRespawnDeathController characterRespawnDeathController = _currentCharacter.GetComponent<CharacterRespawnDeathController>();
        characterRespawnDeathController.spawnPoint = spawnPoint;

        ChangeSliderHealthBar healthBar = _currentCharacter.GetComponent<ChangeSliderHealthBar>();
        healthBar.slider = _slider;

        AimCharacterToMob aimCharacterToMob = _currentCharacter.GetComponent<AimCharacterToMob>();
        aimCharacterToMob.cinemachineFreeLook = _cinemachineFreeLook;
        
        ShopInteraction shopInteraction = _currentCharacter.GetComponent<ShopInteraction>();
        shopInteraction.cinemachineFreeLook = _cinemachineFreeLook;
        
        shopUpgradeCharacterController.characterStatsInfo = _currentCharacter.GetComponent<CharacterStatsInfo>();
    }

}