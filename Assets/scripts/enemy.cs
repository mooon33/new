using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter(Collision other)
{
    if (other.gameObject.tag == "Sword")
    {
        GetComponent<Animation>().Play("mixamo_com");
    }
}
    }
}
