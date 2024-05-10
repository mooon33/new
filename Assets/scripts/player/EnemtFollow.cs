using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target; // ������� ������ (��� ��������)
    public float moveSpeed = 3f; // �������� �������� ����������
    public float minDistance = 1f; // ����������� ����������, �� ������� ��������� ���������������

    private void Update()
    {
        if (target != null)
        {
            // ��������� ����������� � ����
            Vector3 direction = (target.position - transform.position).normalized;

            // ���� ���������� �� ���� ������ ������������, ��������� � ����
            if (Vector3.Distance(transform.position, target.position) > minDistance)
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
                transform.LookAt(target); // ������� ���������a � ������� ����
            }
        }
    }
}