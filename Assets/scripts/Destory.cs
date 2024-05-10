using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("weapon")) // Проверяем тег объекта, с которым произошло столкновение
        {
            Destroy(collision.gameObject); // Уничтожаем объект
        }
    }
}