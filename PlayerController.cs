using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Transform weapon;
    public float offset;
    public float offset2;

    public LogicScript logic;
    public bool playerIsAlive = true;


    public Transform shotPoint;
    public GameObject projectiles;

    public float timeBetweenShots;
    float nextShotTime;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void FixedUpdate()
    {
        //player movement
        if (playerIsAlive == true)
        {
            Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            transform.position += playerInput.normalized * speed * Time.deltaTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if (playerIsAlive == true)
        {
            //weapon rotation
            Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
            weapon.rotation = Quaternion.Euler(0f, 0f, angle + offset);


            Vector3 displacement2 = shotPoint.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float angle2 = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
            shotPoint.rotation = Quaternion.Euler(0f, 0f, angle2 + offset2);

            //shooting
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time > nextShotTime)
                {
                    nextShotTime = Time.time + timeBetweenShots;
                    GameObject orb = Instantiate(projectiles, shotPoint.position, shotPoint.rotation);
                    Rigidbody2D rb = orb.GetComponent<Rigidbody2D>();

                }
            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            logic.gameOver();
            playerIsAlive = false;
        }


    }
}
