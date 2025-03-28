using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    private bool _canAttack;
    [SerializeField] private CharacterAnimation _characterAnimation;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackCD;
    [SerializeField] private float _attackTime;
    private float _currentTimeToattck;

    private void FixedUpdate()
    {
        if (_currentTimeToattck < _attackCD)
        {
            _currentTimeToattck += Time.fixedDeltaTime;
        }
    }

    public void Attack()
    {
        if (_currentTimeToattck >= _attackCD)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        _characterAnimation.OnAttack();
        _currentTimeToattck = 0;
        _canAttack = true;
        yield return new WaitForSeconds(_attackTime);
        _canAttack = false;
    }

    public bool CanAttack()
    {
        return _canAttack;
    }

    public int GetDamageValue()
    {
        return _damage;
    }

    public void EndAttack()
    {
        _canAttack = false;
    }
}
