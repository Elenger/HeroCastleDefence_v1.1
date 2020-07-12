using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttack : MonoBehaviour
{
    [SerializeField] private WeaponInfo _weaponInfo;
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private Animator animator;
    private bool _stopAttack = false;
    public GameObject targetCharacter;
    public Vector3 targetCastlePosition;

    private void Awake()
    {
        if (!_photonView.IsMine) enabled = false;
    }

    private void OnEnable()
    {
        EventManager.current.LifeStatusChanged += ChangeAttackStatus;
    }

    private void OnDisable()
    {
        EventManager.current.LifeStatusChanged -= ChangeAttackStatus;
    }

    private void ChangeAttackStatus(bool lifeStatus)
    {
        _stopAttack = !lifeStatus;
    }

    void Update()
    {
        if (_stopAttack)
        {
            CancelInvoke();
            return;
        }

        float distanceToCharacter = Vector3.Distance(targetCharacter.transform.position, transform.position);
        float distanceToMainCastle = Vector3.Distance(targetCastlePosition, transform.position);

        if (distanceToCharacter <= _weaponInfo.range && !IsInvoking())
        {
            //attacks animation is ON. Should make a normal delay instead 1f
            InvokeRepeating("StartAnimation", 0f, 1f);
        }
        else if (distanceToMainCastle <= _weaponInfo.range && !IsInvoking())
        {
            //attacks animation is ON. Should make a normal delay instead 1f
            InvokeRepeating("StartAnimation", 0f, 1f);
        }
        else
        {
            CancelInvoke();
        }
    }

    private void StartAnimation()
    {
         animator.Play("Attack");
    }
}
