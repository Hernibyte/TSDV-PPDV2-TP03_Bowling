using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    [SerializeField] private float mForce;
    [SerializeField] private float rForce;
    private float movementSerialized = 0;
    public bool shoot { set; get; }
    private float yRot = 16.0f;
    private float timer = 0.0f;
    [SerializeField] private GameObject arrow;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        timer += 0.005f;

        if (!shoot)
        {
            if (timer >= 1f)
            {
                if (movementSerialized == 1)
                    movementSerialized = -1f;
                else
                    movementSerialized = 1f;

                timer = 0f;
            }

            yRot -= movementSerialized * rForce;
            transform.eulerAngles = new Vector3(0f, yRot, 0f);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Rigidbody.isKinematic = false;
                m_Rigidbody.AddForce(transform.right * mForce);
                shoot = true;
                arrow.SetActive(false);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(0f, 0f, -1f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(0f, 0f, 1f * Time.deltaTime);
            }

            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -2, 2));
        }
    }

    public void ResetParameters()
    {
        yRot = 16.0f;
        movementSerialized = 0;
        timer = 0f;
        transform.position = new Vector3(-19.39f, 0.67f, 0f);
        transform.eulerAngles = new Vector3(0f, yRot, 0f);
        arrow.SetActive(true);
        m_Rigidbody.isKinematic = true;
    }
}
