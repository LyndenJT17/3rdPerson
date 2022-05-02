using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{

    public float moveSpeed = 7f;
    public float distance = 20f;
    Rigidbody rb;

    PlayerController target;
    Vector3 moveDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindObjectOfType<PlayerController>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        Destroy(gameObject, distance);
    }

    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);

        }
    }
}
