using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void OnMove()
    {
        _animator.SetBool("Walk", true);
    }

    public void OnStay()
    {
        _animator.SetBool("Walk", false);
    }

    public void OnAttack()
    {
        _animator.SetTrigger("Attack");
    }
}
