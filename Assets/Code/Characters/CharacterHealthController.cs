using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthController : MonoBehaviour
{

    [SerializeField] private CharacterRespawnDeathController _characterRespawnDeathController;
    [SerializeField] private int _healthPoint = 100;

    public void TakeDamage(int damage)
    {
        _healthPoint -= damage;

        _characterRespawnDeathController.CheckForDeath(_healthPoint);
    }

    public void RestoreHealth()
    {
        _healthPoint = 100;
    }
}
