using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProyectileController : MonoBehaviour
{
    public float speed=5f;
    public float damage = 10f;
    Vector3 direction;
    GameObject jugador;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Player");
        direction = jugador.transform.position - transform.position;
        direction.Normalize();
        direction = direction * speed;
        Destroy(this.gameObject, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction;
        //transform.Translate(direction * speed * Time.deltaTime);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Equals("Player"))
        {
            jugador.GetComponent<HealthManagerPlayer>().recibeImpacto(damage);
        }
        if (!collision.transform.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }

}
