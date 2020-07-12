using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    [SerializeField] private CharacterAnimation _characterAnimation;
    [SerializeField] private Weapon _weapon;
    public int damage;
    public float range;
    public float attackSpeed;

    private void Start()
    {
        Debug.Log(_weapon.damage);
        ChangeDamage(_weapon.damage);
        ChangeRange(_weapon.range);
        ChangeAttackSpeed(_weapon.attackSpeed);
    }

    public void ChangeDamage(int newDamage)
    {
        damage = newDamage;
    }
    public void ChangeRange(float newRange)
    {
        range = newRange;
    }
    public void ChangeAttackSpeed(float newAttackSpeed)
    {
        attackSpeed = newAttackSpeed;
        if (_characterAnimation != null)
        {
            _characterAnimation.ChangeAttackSpeed(attackSpeed);
        }
    }

}
