using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target; // Целевой объект (ваш персонаж)
    public float moveSpeed = 3f; // Скорость движения противника
    public float minDistance = 1f; // Минимальное расстояние, на котором противник останавливается

    private void Update()
    {
        if (target != null)
        {
            // Вычисляем направление к цели
            Vector3 direction = (target.position - transform.position).normalized;

            // Если расстояние до цели больше минимального, двигаемся к цели
            if (Vector3.Distance(transform.position, target.position) > minDistance)
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
                transform.LookAt(target); // Вращаем противникa в сторону цели
            }
        }
    }
}