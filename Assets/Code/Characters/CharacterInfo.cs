using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{/*
    [SerializeField] private ChangeSliderHealthBar _healthBar;
    [SerializeField] private Animator _animator;
    [SerializeField] private ThirdPersonMovement _thirdPersonMovement;
    [SerializeField] private CharacterAnimation _characterAnimation;
    [SerializeField] private int _healthPoint = 100;
    public List<GameObject> mobList = new List<GameObject>();
    public Transform spawnPoint;
    private const int _respawnTime = 8;
    private bool _alreadyDead = false;

    public void SetHealth(int newHealthPoint)
    {
        _healthPoint = newHealthPoint;
    }

    public int GetHealth()
    {
        return _healthPoint;
    }
    
      public void TakeDamage(int damage)
      {
          _healthPoint = _healthPoint - damage;

          _healthBar.ChangeHealthBar(_healthPoint);
          if (_healthPoint <= 0) Death();
      }

        private void Death()
        {
            if (!_alreadyDead)
            {
                foreach (GameObject mob in mobList)
                {
                    MobNavMesh mobNavMesh = mob.GetComponent<MobNavMesh>();
                    mobNavMesh.stopChasingPlayer = true;

                    MobAttack mobAttack = mob.GetComponent<MobAttack>();
                    mobAttack.stopAttackingPlayer = true;
                }

                _thirdPersonMovement.stopMovement = true;
                _animator.Play("Death");
                _alreadyDead = true;

                _characterAnimation.dontChangeAnimation = true;

                StartCoroutine("Respawn");
            }
        }

        IEnumerator Respawn()
        {
            yield return new WaitForSeconds(_respawnTime);
            transform.position = spawnPoint.position;
            _healthPoint = 100;
            _healthBar.ChangeHealthBar(_healthPoint);
            _thirdPersonMovement.stopMovement = false;
            _alreadyDead = false;
            _characterAnimation.dontChangeAnimation = false;
            _animator.Play("Idle");

            foreach (GameObject mob in mobList)
            {
                MobNavMesh mobNavMesh = mob.GetComponent<MobNavMesh>();
                mobNavMesh.stopChasingPlayer = false;

                MobAttack mobAttack = mob.GetComponent<MobAttack>();
                mobAttack.stopAttackingPlayer = false;
            }
        }*/
}
