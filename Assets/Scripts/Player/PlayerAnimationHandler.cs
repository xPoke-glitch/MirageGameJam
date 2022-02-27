using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private EquippedWeapon _equippedWeapon;
    private Movement _movement;
    private Player _player;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _equippedWeapon = GetComponent<EquippedWeapon>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (_movement.IsMoving)
        {
            animator.SetBool("IsMoving", true);
            if (_movement.IsRunning)
            {
                animator.speed = 2f;
            }
            else
            {
                animator.speed = 1f;
            }
            // animator.SetLayerWeight(1, 1);
        }
        else
        {
            animator.SetBool("IsMoving", false);
            //animator.SetLayerWeight(1, 0);
        }

        if (_equippedWeapon.IsAttacking)
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }

        if (_player.isHurt)
        {
            animator.SetBool("IsHurt", true);
        }
        else
        {
            animator.SetBool("IsHurt", false);
        }
    }

    public void IncreaseSpeed(float customSpeed)
    {
        animator.speed = customSpeed;
    }
}
