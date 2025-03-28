using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] protected CharacterAnimation _characterAnimation;
    [SerializeField] protected float _speed;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] protected CharacterCombat _characterCombat;

    virtual public void MoveLeft()
    {
        if (!_characterCombat.CanAttack())
        {
            _rigidBody.velocity = new Vector2(-_speed, _rigidBody.velocity.y);
            transform.localScale = new Vector3(1.5f, transform.localScale.y, transform.localScale.z);
        }
    }

    virtual public void MoveRight()
    {
        if (!_characterCombat.CanAttack())
        {
            _rigidBody.velocity = new Vector2(_speed, _rigidBody.velocity.y);
            transform.localScale = new Vector3(-1.5f, transform.localScale.y, transform.localScale.z);
        }
    }

    virtual public void Stay()
    {
        _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
        _characterAnimation.OnStay();
    }

    virtual public void Move()
    {
        if (!_characterCombat.CanAttack())
        {
            _characterAnimation.OnMove();
        }
    }

    virtual public void StopMove()
    {
        _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
    }
}

