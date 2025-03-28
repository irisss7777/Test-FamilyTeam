using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput3D : MonoBehaviour
{
    [SerializeField] protected KeyCode _keyForMoveRight;
    [SerializeField] protected KeyCode _keyForMoveLeft;
    [SerializeField] protected KeyCode _keyForMoveForward;
    [SerializeField] protected KeyCode _keyForMoveBack;
    [SerializeField] protected CharacterMove3D _characterMove;
    [SerializeField] protected CharacterCombat _characterCombat;
    private void FixedUpdate()
    {
        AttackInput();
    }

    private void AttackInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _characterMove.StopMove();
            _characterCombat.Attack();
        }
    }

}
