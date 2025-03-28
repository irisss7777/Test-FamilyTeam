using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove3D : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody3D;
    [SerializeField] protected CharacterAnimation _characterAnimation;
    [SerializeField] protected float _speed;
    [SerializeField] protected CharacterCombat _characterCombat;
    public float rotationSmoothTime = 0.12f;
    private float currentRotationVelocity;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0 || verticalInput != 0)
        {
            if (!_characterCombat.CanAttack())
            {
                Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
                float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentRotationVelocity, rotationSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                _characterAnimation.OnMove();
                _rigidBody3D.velocity = new Vector3(verticalInput * -_speed, _rigidBody3D.velocity.y, horizontalInput * _speed);
            }
        }
        else
        {
            _characterAnimation.OnStay();
        }
    }

    public void StopMove()
    {
        _rigidBody3D.velocity = new Vector3(0, _rigidBody3D.velocity.y, 0);
    }
}

