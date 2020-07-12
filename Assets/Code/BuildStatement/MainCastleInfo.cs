using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCastleInfo : MonoBehaviour
{
    [SerializeField] private DefeatController _defeatController; 
    private int _healthPoint = 500;

    public void TakeDamage(int damage)
    {
        _healthPoint -= damage;
        if (_healthPoint <= 0) _defeatController.Loss();
    }
}
