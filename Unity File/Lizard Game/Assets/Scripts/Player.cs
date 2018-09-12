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
    public SphereCollider col;

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
      Debug.Log(Physics.Raycast(transform.position, Vector3.down, Raydistance));

       // Waterjump();
        EatFireFly();
    }

    void Movement()
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
        slider.value = WaterFillRate;

        if (Input.GetKey(KeyCode.Space) && (WaterFillRate > 0))
        {
            // moveDirection.y = jumpSpeed;
            rb.AddForce(0, 10f, 0);



            WaterFillRate = WaterFillRate - 0.5f * Time.deltaTime;
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, 400f, 0);

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
        WaterFillRate = WaterFillRate + 0.3f * Time.deltaTime;
        slider.value = WaterFillRate;
        if (WaterFillRate >= 1)
        {
            WaterFillRate = 1;
            
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
            if (Input.GetKey(KeyCode.V))
            {
                Debug.Log("V key was pressed.");
                DrinkWater();
            }
        }
        else return;
    }

    public void EatFireFly()
    {
        if (Input.GetKeyDown(KeyCode.C))
            {
            Tounge.SetActive(true);
            //Instantiate(Tounge.gameObject, ToungePoint.transform.position, ToungePoint.transform.rotation);
        }
    }
    private bool IsGrounded()
    {
       return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,col.bounds.min.y, col.bounds.center.z ), col.radius * .9f, groundLayer)
        ;
    }
    
  
    
}
