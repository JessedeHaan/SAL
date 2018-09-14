using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    public float speed;
    public float WaterFillRate;
    public Animator myanamator;
    // private CharacterController characterController;
    private Rigidbody rb;
    public Slider slider;
    [SerializeField]
    private float moveSpeed = 100f;
    public float gravity = 20.0F;
   // private Vector3 moveDirection = Vector3.zero;
    [SerializeField]
    public float jumpSpeed = 8.0f;
    public GameObject Tounge;
    public Transform ToungePoint;
    public float Raydistance = 0.5f;
    public LayerMask groundLayer;
    private SphereCollider col;
    public bool Fireflyeaten = false;
    public bool action = false;
    public GameObject FireflyGO;
    public Transform Currentpos;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public bool rockPull = false;

    private void Awake()
    {
       // characterController = GetComponent<CharacterController>();
       rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }
    // Use this for initialization
    void Start () {
        Tounge.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        Movement();
      Physics.Raycast(transform.position, Vector3.down, Raydistance);

       // Waterjump();
        EatFireFly();
        if (Fireflyeaten == true)
        {
            ShootFirefly();
        }
    }

    void Movement()
    {
        if(rockPull == true)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
            myanamator.SetFloat("RunHorozontal", x * 20);
            myanamator.SetFloat("RunVerticle", z * 20);
            transform.Translate(x, 0, z, Space.World);


            Vector3 movement = new Vector3(x, 0.0f, z);
            if (Input.GetButtonDown("Let_Go"))
            {
                rockPull = false;
            }
        }
        if (action == false && rockPull == false)
        {
            
            if (IsGrounded())
            {
                var x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
                var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
                myanamator.SetFloat("RunHorozontal", x * 100);
                myanamator.SetFloat("RunVerticle", z * 100);
                transform.Translate(x, 0, z, Space.World);


                Vector3 movement = new Vector3(x, 0.0f, z);
                if (movement != Vector3.zero)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
                }
            }
            else
            {
                var x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed / 2f;
                var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed / 2f;
                myanamator.SetFloat("RunHorozontal", x * 100);
                myanamator.SetFloat("RunVerticle", z * 100);
                transform.Translate(x, 0, z, Space.World);


                Vector3 movement = new Vector3(x, 0.0f, z);
                if (movement != Vector3.zero)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
                }
            }
        }
        else
        {
            Debug.Log("action being made");
        }
        slider.value = WaterFillRate;

        if(Fireflyeaten == true)
        {
            WaterFillRate = WaterFillRate - 0.5f * Time.deltaTime;
            if (WaterFillRate <= 0)
            {
                WaterFillRate = 0;

            }
        }
        if (rockPull == false)
        {
            if (Input.GetButton("Jump") && (WaterFillRate > 0))
            {
                // moveDirection.y = jumpSpeed;
                rb.AddForce(0, 10f, 0);



                WaterFillRate = WaterFillRate - 0.5f * Time.deltaTime;
            }

            if (IsGrounded() && Input.GetButtonDown("Jump"))
            {
                rb.AddForce(0, 400f, 0);

            }
        }
        /*   var horizontal = Input.GetAxis("Horizontal");
           var vertical = Input.GetAxis("Vertical");
           myanamator.SetFloat("RunHorozontal", horizontal);
           myanamator.SetFloat("RunVerticle", vertical);
           var movement = new Vector3(horizontal, 0, vertical);
           characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);
             if  (movement != Vector3.zero)
                  {
                 transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
                 }
           moveDirection.y -= gravity * Time.deltaTime;
          characterController.Move(moveDirection * Time.deltaTime);

          
                     */
    }   

    public void DrinkWater()
    {
        if (Fireflyeaten == false)
        {
            WaterFillRate = WaterFillRate + 0.3f * Time.deltaTime;
            slider.value = WaterFillRate;
            if (WaterFillRate >= 1)
            {
                WaterFillRate = 1;

            }

        }
    }

  /*  public void Waterjump()
    {
        slider.value = WaterFillRate;
        
            if (Input.GetKey(KeyCode.Space) && (WaterFillRate > 0))
            {
                moveDirection.y = jumpSpeed + 0.5f;
            


            WaterFillRate = WaterFillRate - 0.3f * Time.deltaTime;
            }

        if (Input.GetKey(KeyCode.Space) && (characterController.isGrounded))
        {
            moveDirection.y = jumpSpeed;
        }

            }
     */ 

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Debug.Log("Player is ready to drink");
            if (Input.GetButton("Interact"))
            {
                Debug.Log("V key was pressed.");
                DrinkWater();
            }
        }
        if (other.CompareTag("Rock"))
        {
            Debug.Log("ready to pull");
            if (Input.GetButton("Interact"))
            {
                rockPull = true;
                other.transform.parent = gameObject.transform;
                Debug.Log("Intraction key was pressed.");
               
              
            }
        }
        else return;
    }

    public void EatFireFly()
    {
        if (Fireflyeaten == false)
        {
            if (Input.GetButtonDown("Shoot") && Time.time > nextFire)
            {

                action = true;
                Invoke("Action", 0.5f);
                Tounge.SetActive(true);
                //Instantiate(Tounge.gameObject, ToungePoint.transform.position, ToungePoint.transform.rotation);
                nextFire = Time.time + fireRate;
            }
        }
    }
    private bool IsGrounded()
    {
       return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,col.bounds.min.y, col.bounds.center.z ), col.radius * .9f, groundLayer)
        ;
    }

    public void ShootFirefly()
    {
        if (Input.GetButtonDown("Shoot") && Fireflyeaten == true)
        {
            FireflyGO.SetActive(true);
            FireflyGO.transform.parent = null;
            FireflyGO.transform.position = Currentpos.transform.position;
            FireflyGO.GetComponent<Rigidbody>().velocity = Currentpos.transform.forward * 6;
            nextFire = Time.time + fireRate;
            Fireflyeaten = false;
        }
    }

    public void Action()
    {
        action = false;
    }
    
  
    
}
