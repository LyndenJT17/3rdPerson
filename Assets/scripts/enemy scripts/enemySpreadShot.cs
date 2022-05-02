using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpreadShot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    public float fireRate;
    public float nextFire;
    public int fireIndex;

    Vector3 angleToFire;
    float baseAngle = 20;

    public void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;

    }

    // Update is called once pr frame
    public void Update()
    {
        CheckIfTimeToFire();
    }
    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;

            angleToFire = new Vector3 (currentRotation.x, currentRotation.y + baseAngle, currentRotation.z);

            Instantiate(bullet, transform.position, Quaternion.Euler(angleToFire));
            nextFire = Time.time + fireRate;
        }
    }
}
