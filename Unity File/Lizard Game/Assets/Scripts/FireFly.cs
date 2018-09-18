using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFly : MonoBehaviour {
    public GameObject tougne;
    public GameObject Rune;
 
   // public Transform snap;
    public Collider flyColider;
    public GameObject FireflyStationary;
    public GameObject FireflyMoving;
    public GameObject FireflyCharging;
    public GameObject FireflyShockwave;
    public GameObject player;
    private Rigidbody rb;
 
    public bool moving;
   
    public float speed;
     public bool runeenter = false;

    // Use this for initialization

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        FireflyMoving.SetActive(false);
        FireflyCharging.SetActive(false);
        FireflyShockwave.SetActive(false);
    }

    void Start () {
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {

        
        
        if (runeenter == false)
        {
            FireflyShockwave.SetActive(false);
            FireflyCharging.SetActive(false);
            
            if (moving == true)
            {
                FireflyMoving.SetActive(true);
                FireflyStationary.SetActive(false);
            }
            else if (moving == false)
            {
                FireflyStationary.SetActive(true);
                FireflyMoving.SetActive(false);
            }

        }
        else if( runeenter == true)
        {
            FireflyShockwave.SetActive(true);
            FireflyCharging.SetActive(true);
            FireflyMoving.SetActive(false);
            FireflyStationary.SetActive(false);
        }

     /*  if(moving == true)
        {
            float move = speed * Time.deltaTime;
            Debug.Log("firefly hit");
            transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, move);
        }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tougne"))
           
        {
            rb.isKinematic = false;
            runeenter = false;
            this.gameObject.transform.parent = null;
            this.gameObject.transform.parent = tougne.transform;
           
            moving = true;

            player.GetComponent<Player>().Fireflyeaten = true;
           //transform.position = snap.transform.position;
            //moving = true;
           
            

        }
        if (other.CompareTag("Rune"))
        {
            runeenter = true;
            this.gameObject.transform.parent = Rune.transform;
            rb.velocity = Vector3.zero;
            transform.position = Rune.transform.position;
            rb.isKinematic = true;


            //transform.position = snap.transform.position;
            //moving = true;

            // Invoke("Destroy", 1f);

        }
        if (other.CompareTag("Ground")){
            rb.isKinematic = true;
        }

    }
  
    // void Destroy()
    // {
    //   gameObject.SetActive(false);

    // }
}
