using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    public int Health;
    public Animator anim;

    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;
        if (Health <= 0)
        {
            anim.SetTrigger("Die");
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            anim.SetTrigger("Hit");
        }
    }
}
