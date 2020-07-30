using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{
    bool[] weapons = new bool[2]; //1-Pistol //2-Escopeta
    public SoundManagerScript soundFX;
    public TextMeshProUGUI ammoDisplay;
    public GameObject blood;
    public GameObject impact;
    public int ammoCount = 10;
    public float cooldownShoot = 0.5f;
    float nextShot = 0f;
    public Animator animacion;
    // Start is called before the first frame update
    void Start()
    {
        ammoDisplay.text = ammoCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammoCount = 10;
        }
        if (Input.GetButtonDown("Fire1") && nextShot<=0 && ammoCount>0)
        {

            animacion.SetTrigger("Disparar");
            soundFX.playSound("shot");
            RaycastHit hit;
            bool hitted = Physics.Raycast(transform.position, transform.forward, out hit);
            if (hitted)
            {
                HealthManager aux = hit.collider.gameObject.GetComponent<HealthManager>();
                if (aux!=null)
                {
                    aux.recibeImpacto(34f);
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
                Debug.DrawRay(transform.position, transform.forward*100f, Color.black, 2f);
            }
            nextShot = cooldownShoot;
            ammoCount--;

        }
        nextShot -= Time.deltaTime;
        ammoDisplay.text = ammoCount.ToString();

    }
}
