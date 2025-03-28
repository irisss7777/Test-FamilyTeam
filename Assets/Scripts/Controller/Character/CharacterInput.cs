using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] protected KeyCode _keyForMoveRight;
    [SerializeField] protected KeyCode _keyForMoveLeft;
    [SerializeField] protected CharacterMove _characterMove;
    [SerializeField] protected CharacterCombat _characterCombat;

    protected void FixedUpdate()
    {
        MoveInput();
        AttackInput();
    }


    protected void MoveInput()
    {
        if(Input.GetKey(_keyForMoveRight) && Input.GetKey(_keyForMoveLeft) == false)
        {
            _characterMove.MoveRight();
        }
        if (Input.GetKey(_keyForMoveLeft) && Input.GetKey(_keyForMoveRight) == false)
        {
            _characterMove.MoveLeft();
        }
        if(Input.GetKey(_keyForMoveRight) == false && Input.GetKey(_keyForMoveLeft) == false)
        {
            _characterMove.Stay();
        }
        else
        {
            _characterMove.Move();
        }
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
