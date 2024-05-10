using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    private void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            Ray ray = _camera.ScreenPointToRay(screenCenter);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                if (target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereInicatorCoroutine(hit.point));
                    Debug.DrawLine(this.transform.position, hit.point, Color.green, 20);
                }
            }
        }
    }

    private IEnumerator SphereInicatorCoroutine(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(6);

        Destroy(sphere);
    }
}
