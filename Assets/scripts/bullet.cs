using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody rb;
    public LayerMask whatIsEnemies;

    [Range(0f, 1f)]
    public float bounciness;
    public bool useGravity;

    //put damage values here
    public int bulletDamage;

    //lifetime
    public int maxCollisions;
    public float maxLifetime;
    private float lifetime;

    int collisions;
    PhysicMaterial physics_mat;

    // Start is called before the first frame update
    void Start()
    {
        Setup();

    }

    void OnEnable()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        //when to despawn:
        if (collisions > maxCollisions) destroyBullet();

        //count down liftime:
        lifetime -= Time.deltaTime;
        if (lifetime <= 0) destroyBullet();
    }

    private void destroyBullet()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, 1f, whatIsEnemies);
        print("Something");
        for (int i = 0; i < enemies.Length; i++)
        {
            //UNCOMMENT THIS ONCE A HEALTH SCRIPT IS MADE!!!!
            print(enemies[i].gameObject.name);
            enemies[i].GetComponentInChildren<GameHandler>().damage(bulletDamage);
        }

        Invoke("Delay", 0.05f);
    }

    private void Delay()
    {
        GetComponent<Rigidbody>().velocity = (Vector3.zero);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet")) return;

        collisions++;

        destroyBullet();
    }

    private void Setup()
    {
        //Create a new Physic material
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //Assign material to collider
        GetComponent<SphereCollider>().material = physics_mat;

        //Set gravity
        rb.useGravity = useGravity;

        lifetime = maxLifetime;
    }

}
