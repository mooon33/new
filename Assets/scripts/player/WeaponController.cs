using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Shovel;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public AudioClip ShovelAttackSound;
    public bool IsAttacking = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                ShovelAttack();
            }
        }
    }

    public void ShovelAttack()
    {
        IsAttacking = true;
        CanAttack = false;
        Animator anim = Shovel.GetComponent<Animator>();
        anim.SetTrigger("Attack");

        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(ShovelAttackSound);

        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool()); 
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1f);
        IsAttacking = false;
    }
}
