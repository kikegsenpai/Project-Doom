using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementChaser : MonoBehaviour
{
    public NavMeshAgent agente;
    public GameObject jugador;
    public Transform enemigo;
    public float viewDistance = 10f;

    bool visto = false;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(enemigo.position, jugador.transform.position);

        if (Vector3.Distance(enemigo.position, jugador.transform.position) <= viewDistance)
        {
            visto = true;
        }
        if (visto)
        {
            agente.SetDestination(jugador.transform.position);
        }

    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(enemigo.position, viewDistance);
    }
}
