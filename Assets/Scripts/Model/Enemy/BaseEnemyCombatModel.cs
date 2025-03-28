using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyCombatModel : MonoBehaviour, IDamagable
{
    [SerializeField] private int _maxHP;
    [SerializeField] private EnemyAnimation _enemyAnimation;
    private int _currentHP;

    public int CurrentHP
    {
        get
        {
            return _currentHP;
        }
        set
        {
            _currentHP -= value;
            if(_currentHP <= 0)
            {
                StartCoroutine(Die());
            }
            else
            {
                _enemyAnimation.Damage();
            }
        }
    }

    private void Awake()
    {
        _currentHP = _maxHP;
    }

    public void GetDamage(int damage)
    {
        CurrentHP = damage;
    }

    private IEnumerator Die()
    {
        _enemyAnimation.Die();
        yield return new WaitForSeconds(0.7f);
        Destroy(this.gameObject);
    }
}
