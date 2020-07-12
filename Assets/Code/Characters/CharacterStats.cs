using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "CharacterStats", menuName = "Character/Character Stats")]
public class CharacterStats : ScriptableObject
{
    public float healthPoint;
    public float defencePoint;
    public float moveSpeed;
    public float attackSpeed;
    public float skillCooldownSpeed;
    public float castSpeed;
    public float attackDamage;
    public float skillDamage;
    
    
}
