/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageHandler
{
    void TakeDamage(int damage);
}

//this class located on a mobs and character
public class DamageSystem : MonoBehaviour
{
    [SerializeField] private WeaponInfo _weaponInfo;
    public bool attackAnimationIsActive = false; //filling from animations event
    private bool _scriptHolderIsMob = false;

    private void SetAttackAnimationIsActive(int eventValue)
    {
        attackAnimationIsActive = eventValue == 1 ? true : false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (attackAnimationIsActive && other.TryGetComponent(out IDamageHandler damageHadler))
        {
            damageHadler.TakeDamage(_weaponInfo.damage);
        }
    }

}

*/