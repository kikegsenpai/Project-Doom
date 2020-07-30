using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementShooter : MonoBehaviour
{
    public NavMeshAgent agente;
    public GameObject jugador;
    public Transform pistol;
    public GameObject bullet;
    public float viewDistance = 10f;
    public LayerMask raycastMask;

    public float rateOfFire = 0.7f;
    float nextShot=0f;

    Vector3 direction;
    bool visto = false;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        direction =  jugador.transform.position- pistol.position ;
        direction.Normalize();

        RaycastHit hit;
        bool inVision = Physics.Raycast(pistol.position, direction,out hit, viewDistance, raycastMask);
        if (inVision && hit.transform.name.Equals("Player"))
        {
            if (!visto)
            {
                visto = true;
            }
            else
            {
                agente.isStopped = true;
                Vector3 aux = jugador.transform.position - pistol.position;
                aux.y = 0f;
                Quaternion wanted = Quaternion.LookRotation(aux);
                transform.rotation = Quaternion.Lerp(transform.rotation, wanted, Time.time * 0.01f);

                if (nextShot <= 0)
                {
                    Instantiate(bullet,
                    pistol.position,
                    Quaternion.identity
                    );
                    nextShot = rateOfFire;
                }
                else
                {
                    nextShot -= Time.deltaTime;
                }
            }
            Debug.DrawRay(pistol.position, direction*hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(pistol.position, direction * hit.distance, Color.black);
            if (visto)
            {
                agente.isStopped = false;
                agente.SetDestination(jugador.transform.position);
            }
        }
       
        /*
        if (visto)
        {
            if (Vector3.Distance(pistol.position, jugador.transform.position) <= viewDistance)
            {
                agente.isStopped = true;
                Vector3 aux=jugador.transform.position-pistol.position;
                //Debug.DrawRay(pistol.position, aux);
                aux.y = 0f;
                Quaternion wanted = Quaternion.LookRotation(aux);
                transform.rotation=Quaternion.Lerp(transform.rotation, wanted, Time.time * 0.01f);

                if (nextShot<=0)
                {
                    Instantiate(bullet,
                    pistol.position,
                    Quaternion.identity
                    ) ; 
                    nextShot = rateOfFire;
                }
                else
                {
                    nextShot -= Time.deltaTime;
                }
            }
            else
            {
                agente.isStopped = false;

                agente.SetDestination(jugador.transform.position);
            }
        }*/
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pistol.position, viewDistance);
        Gizmos.DrawWireSphere(pistol.position, 0.5f);
        //Gizmos.DrawWireSphere(jugador.transform.position, 0.5f);
        //Gizmos.DrawLine(pistol.position, jugador.transform.position);
    }
}
