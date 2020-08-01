using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void recibeImpacto(float damage)
    {
        health -= damage;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.name.Equals("Porrito"))
        {
            health -= other.GetComponent<LauncherBehaviour>().damage;
        }
    }
}
