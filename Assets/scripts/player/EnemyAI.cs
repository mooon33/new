using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5.0f;
    public float obstacleRande = 5.0f;
    public bool _alive = true;

    [SerializeField]
    private GameObject[] _fireballsPrefab;
    private GameObject _fireball;

    private void Start()
    {
        _alive = true;
    }

    private void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                if (hitObject.GetComponent<CharacterController>())
                {
                    if (_fireball == null)
                    {
                        int randFireball = Random.Range(1, _fireballsPrefab.Length);
                        _fireball = Instantiate(_fireballsPrefab[randFireball]) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRande)
                {
                    float angleRotation = Random.Range(-100, 100);
                    transform.Rotate(0, angleRotation, 0);
                }

            }
        }
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}