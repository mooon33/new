using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fpc: MonoBehaviour
{
    public bool Take;
    public Animation Cube;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            int F = Random.Range(1,3);
            Cube.Play(F.ToString());
        }
        
    }
}
