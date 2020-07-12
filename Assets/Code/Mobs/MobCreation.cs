using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class MobCreation : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private Transform[] _spawnPointsTransform;
    [SerializeField] private Transform[] _targetCastlesTransform;
    private Vector3 _spawnPointPosition;
    private Vector3 _targetCastlePosition;
    private GameObject _mob;
    public GameObject targetCharacter;

    private void Start()
    {
        _spawnPointPosition = (PhotonNetwork.IsMasterClient ? _spawnPointsTransform[0].position : _spawnPointsTransform[1].position);
        _targetCastlePosition = (PhotonNetwork.IsMasterClient ? _targetCastlesTransform[0].position : _targetCastlesTransform[1].position);
    }

    public void CreateMob(GameObject selectedMob)
    {
        _photonView.RPC("CreateMobRPC", RpcTarget.OthersBuffered, selectedMob.name);
    }

    [PunRPC]
    private void CreateMobRPC(string selectedMobName)
    {
        Vector3 force = Vector3.forward;
        Vector3 torque = Vector3.forward;
        object[] instantiationData = { force, torque, true };
        _mob = PhotonNetwork.Instantiate(selectedMobName, _spawnPointPosition, Quaternion.Euler(0.0f, 0.0f, 0.0f), 0, instantiationData);

        MobNavMesh mobNavMesh = _mob.GetComponent<MobNavMesh>();
        mobNavMesh.targetCastlePosition = _targetCastlePosition;
        mobNavMesh.targetCharacterTransform = targetCharacter.transform;
        MobAttack mobAttack = _mob.GetComponent<MobAttack>();
        mobAttack.targetCharacter = targetCharacter;
        mobAttack.targetCastlePosition = _targetCastlePosition;
    }
}
