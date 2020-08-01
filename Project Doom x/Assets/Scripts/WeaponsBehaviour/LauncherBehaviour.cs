using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LauncherBehaviour : MonoBehaviour
{
    public ParticleSystem smoke;
    public String triggerName;
    public float damage = 1f;
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
        if (Input.GetButtonDown("Fire1") && nextShot <= 0 && ammoCount > 0)
        {
            animacion.SetTrigger(triggerName);
            //soundFX.playSound("shot");
            Invoke("echarHumo", 1.8f);
            nextShot = cooldownShoot;
            ammoCount--;
        }
        nextShot -= Time.deltaTime;
        ammoDisplay.text = ammoCount.ToString();

    }
    void echarHumo()
    {
        smoke.Play();
    }
}
