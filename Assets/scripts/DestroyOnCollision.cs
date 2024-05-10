using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnColl : MonoBehaviour
{
    void OnCollEnter(Collision collision)
    {
        // Если объект, с которым произошло столкновение, помечен как "Destroyable", уничтожим его.
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            // Уничтожим объект через 0,2 секунды, чтобы дать время для каких-либо дополнительных эффектов.
            Destroy(collision.gameObject, 0.2f);
        }
    }
}

