using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class located on a mob
public class DamageSystem : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    public bool attackAnimationIsActive = false; //filling from animations event
    private bool _scriptHolderIsMob = false;
    void Start()
    {
        if(CompareTag("Mob"))
        {
            _scriptHolderIsMob = true;
        }
    }

    private void SetAttackAnimationIsActive(int eventValue)
    {
        attackAnimationIsActive = eventValue == 1 ? true : false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (attackAnimationIsActive)
        {
            if (_scriptHolderIsMob)
            {
                if (other.TryGetComponent(out CharacterHealthController characterHealthController))
                {
                    characterHealthController.TakeDamage(_weapon.damage);
                }
                else if (other.TryGetComponent(out MainCastleInfo mainCastleInfo))
                {
                    mainCastleInfo.TakeDamage(_weapon.damage);
                }
            }
            else 
            {
                if (other.TryGetComponent(out MobInfo mobInfo))
                {
                    mobInfo.TakeDamage(_weapon.damage);
                }
            }
        }
    }
}