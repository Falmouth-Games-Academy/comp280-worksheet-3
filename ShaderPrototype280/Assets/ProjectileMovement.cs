using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField]
    float height;

    Rigidbody rb;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -2)
        {
            Debug.Log(rb.velocity);
            rb.AddForce(new Vector3(0, height, 0), ForceMode.Impulse);
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
