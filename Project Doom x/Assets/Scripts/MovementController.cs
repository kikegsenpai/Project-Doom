using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 10f;
    public CharacterController controller;

    public ShootController controladorDisparo;
    public Transform groundCheck;
    public float checkRadius = 0.5f;
    public LayerMask ground;
    bool isGrounded=false;
    public float gravity = -9.81f;
    public Animator animacion;


    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius,ground);
        if (isGrounded && velocity.y<0)
        {
            velocity.y = -2;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        controller.Move(velocity * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            Destroy(other.gameObject);

            controladorDisparo.ammoCount += 10;
        }
        if (other.gameObject.CompareTag("Whisky"))
        {
            Destroy(other.gameObject);

            this.transform.GetComponent<HealthManagerPlayer>().curaVida(30f);
        }
    }
}
