using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{

    
    private int HP = 100;
    public Animator animator;
    public Slider healthBar;

    private void Update()
    {
        healthBar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            animator.SetTrigger("mixamo_com");
            GetComponent<Collider>().enabled = false;

        }
        else
        {
            animator.SetTrigger("mixamo_com");
        }
    }
}
