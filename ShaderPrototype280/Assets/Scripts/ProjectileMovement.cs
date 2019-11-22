using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    float z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        z = transform.position.z + 1 * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, z);

        Destroy(gameObject, 5);
    }
}
