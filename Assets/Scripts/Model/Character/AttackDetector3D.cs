using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetector3D : MonoBehaviour
{
    [SerializeField] private CharacterCombat _characterCombat;

    private void OnTriggerEnter(Collider collision)
    {
        if(_characterCombat.CanAttack())
        {
            if (collision.gameObject.TryGetComponent(out IDamagable outIDamagable) && collision.gameObject != this.gameObject)
            {
                _characterCombat.EndAttack();
                IDamagable target = collision.gameObject.GetComponent(typeof(IDamagable)) as IDamagable;
                target.GetDamage(_characterCombat.GetDamageValue());
            }

        }
    }
}
