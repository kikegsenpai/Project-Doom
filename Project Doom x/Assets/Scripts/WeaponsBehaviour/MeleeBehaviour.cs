using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MeleeBehaviour : MonoBehaviour
{
    public String primaryTriggerName;
    public String secondaryTriggerName;

    public float damage = 30f;
    //public SoundManagerScript soundFX;
    public GameObject blood;
    public GameObject impact;
    public float cooldownPrimary = 0.3f;
    public float cooldownAlternate = 0.1f;
    float nextShot = 0f;
    public Animator animacion;
    public float rangeOfAttac = 1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && nextShot <= 0)
        {
            animacion.SetTrigger(primaryTriggerName);
            //soundFX.playSound("shot");
            RaycastHit hit;
            bool hitted = Physics.Raycast(transform.position, transform.forward, out hit,rangeOfAttac);
            if (hitted)
            {
                HealthManager aux = hit.collider.gameObject.GetComponent<HealthManager>();
                if (aux != null)
                {
                    aux.recibeImpacto(damage);
                }
                
                if (hit.collider.CompareTag("Enemy"))
                {
                    GameObject creado = Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(creado, 1f);

                }
                else
                {
                    GameObject creado = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));

                }
                Debug.DrawLine(transform.position, hit.point, Color.red, 2f);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward * rangeOfAttac, Color.black, 2f);
            }
            nextShot = cooldownPrimary;
            

        } else if (Input.GetButtonDown("Fire2") && nextShot <= 0)
        {
            animacion.SetTrigger(secondaryTriggerName);
            //soundFX.playSound("shot");
            RaycastHit hit;
            bool hitted = Physics.Raycast(transform.position, transform.forward, out hit, rangeOfAttac);
            if (hitted)
            {
                HealthManager aux = hit.collider.gameObject.GetComponent<HealthManager>();
                if (aux != null)
                {
                    aux.recibeImpacto(damage);
                }

                if (hit.collider.CompareTag("Enemy"))
                {
                    GameObject creado = Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(creado, 1f);

                }
                else
                {
                    GameObject creado = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));

                }
                Debug.DrawLine(transform.position, hit.point, Color.red, 2f);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward * rangeOfAttac, Color.black, 2f);
            }
            nextShot = cooldownAlternate;


        }
        nextShot -= Time.deltaTime;
    }
}
