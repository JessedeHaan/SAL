using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    public float speed;
    public float WaterFillRate;
    public Animator myanamator;
    private CharacterController characterController;
    public Slider slider;
    [SerializeField]
    private float moveSpeed = 100f;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private float jumpSpeed = 8.0f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
       
      
    }
    // Use this for initialization
    void Start () {
       

	}
	
	// Update is called once per frame
	void Update () {
        Movement();

        Waterjump();
    }

    void Movement()
    { 

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        myanamator.SetFloat("RunHorozontal", horizontal);
        myanamator.SetFloat("RunVerticle", vertical);
        var movement = new Vector3(horizontal, 0, vertical);
        characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);


       
        moveDirection.y -= gravity * Time.deltaTime;
       characterController.Move(moveDirection * Time.deltaTime);
    }

    public void DrinkWater()
    {
        WaterFillRate = WaterFillRate + 0.1f * Time.deltaTime;
        slider.value = WaterFillRate;
        if (WaterFillRate >= 1)
        {
            WaterFillRate = 1;
            
        }
       
    }

    public void Waterjump()
    {
        slider.value = WaterFillRate;
        
            if (Input.GetKey(KeyCode.Space) && (WaterFillRate > 0))
            {
                moveDirection.y = jumpSpeed;
              

                WaterFillRate = WaterFillRate - 0.5f * Time.deltaTime;
            }
        
    }

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
}
