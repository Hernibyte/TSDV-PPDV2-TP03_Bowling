using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraSystem : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private GameObject objetoAInstanciar;
    [SerializeField] private int cantInstance;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        Vector3 mousePos = Input.mousePosition;

        Ray ray = cam.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 200))
            {
                if (hit.collider.CompareTag("Pine"))
                {
                    Destroy(hit.transform.gameObject);
                    for (int i = 0; i < cantInstance; i++)
                    {
                        Vector3 vec = new Vector3(Random.Range(hit.transform.position.x - 1, hit.transform.position.x + 1),
                            Random.Range(hit.transform.position.y - 1, hit.transform.position.y + 1), 
                            Random.Range(hit.transform.position.z - 1, hit.transform.position.z + 1));
                        Instantiate(objetoAInstanciar, vec, Quaternion.identity);
                    }
                }
                else
                {
                    GameManager.EndGame();
                }
            }
        }

        transform.LookAt(objetoAInstanciar.transform);
    }
}
