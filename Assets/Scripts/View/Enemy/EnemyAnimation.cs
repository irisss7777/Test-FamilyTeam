using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Die()
    {
        _animator.SetTrigger("Die");
    }

    public void Damage()
    {
        _animator.SetTrigger("Damage");
    }
}
