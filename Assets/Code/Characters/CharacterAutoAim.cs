using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAutoAim : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 3;
    private Transform _target;

    public void AimCharacterToTarget(Transform target)
    {
        _target = target;
        /* Vector3 targetPosition = target.position;
         targetPosition.y = 2;*/

        StartCoroutine("ChangeRotation");
    }

    IEnumerator ChangeRotation()
    {
        for(;;)
        {
            yield return new WaitForFixedUpdate();
            Quaternion targetRotation = Quaternion.LookRotation(_target.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed);
            if (targetRotation == transform.rotation) yield break;
        }
    }
}
