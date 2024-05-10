using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageScript : MonoBehaviour
{
    public int damageAmount = 100;
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Ch19")
        {
            animator.SetTrigger("mixamo_com");
            GetComponent<Collider>().enabled = false;
        }
    }
}
