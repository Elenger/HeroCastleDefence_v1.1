using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;
    private bool _actionAnimationIsActive = false;
    private Vector3 previousFrame;
    public bool dontChangeAnimation = false;  

    private void SetActionAnimationIsActive(int eventValue)
    {
        _actionAnimationIsActive = eventValue == 1 ? true : false;
    }

    public void ChangeAttackSpeed(float newAttackSpeed)
    {
        _animator.SetFloat("AttackSpeed", newAttackSpeed);
    }

    void Update()
    {
        if (dontChangeAnimation) return;

        if (Input.GetMouseButtonDown(0) && !_actionAnimationIsActive)
        {
            _animator.Play("Attack");
        }
        else if (!_actionAnimationIsActive && previousFrame == transform.position)
        {
            _animator.Play("Idle");
        }
        else if (!_actionAnimationIsActive && previousFrame != transform.position)
        {
            _animator.Play("Run");
        }
        previousFrame = transform.position;
    }
}
