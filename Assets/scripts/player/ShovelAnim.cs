using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelAnim : MonoBehaviour
{
    public int handAttack;
    public float timer;
    public Transform targetRotate;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (timer <= 0.01f)
            {
                Vector3 dir = targetRotate.position - transform.position;
                dir.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir),40 * Time.deltaTime);
            }
        }
        if (animator.GetInteger("Attack") == 1)
        {
            StartCoroutine(TimerAttack(1.2f));
        }

    }

    IEnumerator TimerAttack(float time)
    {
        timer = timer + Time.deltaTime;
        if (timer >= time)
        {
            timer = 0;
            animator.SetInteger("Attack", 0);
            yield return null;
        }
    }
}
