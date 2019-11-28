using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    float x;
    float y;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        y = -rb.mass;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, y, Input.GetAxis("Horizontal") * speed);

        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(Jump());
    }

    public IEnumerator Jump()
    {
        y = jumpForce;
        yield return new WaitForSeconds(1);
        y = -rb.mass;
    }
}
