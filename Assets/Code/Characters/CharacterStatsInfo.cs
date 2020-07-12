using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsInfo : MonoBehaviour
{
    [SerializeField] private CharacterAnimation _characterAnimation;
    [SerializeField] private CharacterStats _characterStats;
    
    [SerializeField] private float healthPoint;
    [SerializeField] private float defencePoint;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float skillCooldownSpeed;
    [SerializeField] private float castSpeed;
    [SerializeField] private float attackDamage;
    [SerializeField] private float skillDamage;

    private void Start()
    {
        ChangeHealthPoint(_characterStats.healthPoint);
        ChangeDefencePoint(_characterStats.defencePoint);
        ChangeMoveSpeed(_characterStats.moveSpeed);
        ChangeAttackSpeed(_characterStats.attackSpeed);
        ChangeSkillCooldownSpeed(_characterStats.skillCooldownSpeed);
        ChangeCastSpeed(_characterStats.castSpeed);
        ChangeAttackDamage(_characterStats.attackDamage);
        ChangeSkillDamage(_characterStats.skillDamage);
    }

    public void ChangeHealthPoint(float newHealthPoint)
    {
        healthPoint += newHealthPoint;
    }

    public void ChangeDefencePoint(float newDefencePoint)
    {
        defencePoint += newDefencePoint;
    }

    public void ChangeMoveSpeed(float newMoveSpeed)
    {
        moveSpeed += newMoveSpeed;
        if (_characterAnimation != null)
        {
           // _characterAnimation.ChangeMoveSpeed;
        }
    }

    public void ChangeAttackSpeed(float newAttackSpeed)
    {
        attackSpeed += newAttackSpeed;
        if (_characterAnimation != null)
        {
            _characterAnimation.ChangeAttackSpeed(attackSpeed);
        }
    }

    public void ChangeSkillCooldownSpeed(float newSkillCooldownSpeed)
    {
        skillCooldownSpeed += newSkillCooldownSpeed;
    }

    public void ChangeCastSpeed(float newCastSpeed)
    {
        castSpeed += newCastSpeed;
        if (_characterAnimation != null)
        {
            //_characterAnimation.ChangeAttackSpeed(castSpeed);
        }
    }

    public void ChangeAttackDamage(float newAttackDamage)
    {
        attackDamage += newAttackDamage;
    }

    public void ChangeSkillDamage(float newSkillDamage)
    {
        skillDamage += newSkillDamage;
    }
}
