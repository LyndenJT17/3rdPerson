using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletpattern2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float angle = 0f;
    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.1f);
    }
    private void Fire()
    {
        float bulDirX = transform.rotation.eulerAngles.x + Mathf.Sin((angle * Mathf.PI) / 180f);
        float bulDirY = transform.rotation.eulerAngles.y + Mathf.Cos((angle * Mathf.PI) / 180f);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
        bul.transform.position = transform.position;
        bul.transform.rotation = transform.rotation;
        bul.SetActive(true);
        bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
        angle += 10f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    private void OLDFire()
    {
        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
        float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
        bul.transform.position = transform.position;
        bul.transform.rotation = transform.rotation;
        bul.SetActive(true);
        bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
        angle += 10f;
    }
}
