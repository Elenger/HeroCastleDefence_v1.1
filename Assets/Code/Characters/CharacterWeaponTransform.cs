using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeaponTransform : MonoBehaviour
{
    [SerializeField] private Transform _weapon;

    [SerializeField] private Animator _animator;
    
    #region IdleAnimation
    [SerializeField] private string _idleName;
    [SerializeField] private Vector3 _idlePosition;
    [SerializeField] private Vector3 _idleRotation;
    private Quaternion _quaternionIdle;
    #endregion

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
        _quaternionIdle =Quaternion.Euler(_idleRotation);
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
        }else if (_animator.GetCurrentAnimatorStateInfo(0).IsName(_idleName))
        {
            _weapon.localPosition = _idlePosition;
            _weapon.localRotation = _quaternionIdle;
        }
    }
}
