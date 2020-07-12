using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobWeaponAnimation : MonoBehaviour
{
    [SerializeField] private Transform _weapon;

    [SerializeField] private Animator _animator;

    #region AttackAnimation
    [SerializeField] private string _attackName;
    [SerializeField] private Vector3 _attackPosition;
    [SerializeField] private Vector3 _attackRotation;
    private Quaternion _quaternionAttack;
    
    #endregion
    
    #region RunAnimation
    [SerializeField] private string _runName;
    [SerializeField] private Vector3 _runPosition;
    [SerializeField] private Vector3 _runRotation;
    private Quaternion _quaternionRun;
    #endregion

    private void Start()
    {
        _quaternionAttack = Quaternion.Euler(_attackRotation);
        _quaternionRun = Quaternion.Euler(_runRotation);   
    }

    void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(_attackName))
        {
            _weapon.localPosition = _attackPosition;
            _weapon.localRotation = _quaternionAttack;
        }else if (_animator.GetCurrentAnimatorStateInfo(0).IsName(_runName))
        {
            _weapon.localPosition = _runPosition;
            _weapon.localRotation = _quaternionRun;
        }
    }
}
