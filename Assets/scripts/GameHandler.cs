using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public HealthBar healthBar;
    Health healthSystem;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new Health(100);
        healthBar.Setup(healthSystem);

    }

    public void damage(int damage)
    {
        healthSystem.Damage(damage);
    }

}
