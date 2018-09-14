﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFly : MonoBehaviour {
    public GameObject tougne;
    public GameObject Rune;
    public GameObject target;
   // public Transform snap;
    public Collider flyColider;
    public GameObject FireflyStationary;
    public GameObject FireflyMoving;
    public GameObject player;
    private Rigidbody rb;
    public bool moving;
   
    public float speed;
    // Use this for initialization
 
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        FireflyMoving.SetActive(false);
    }

    void Start () {
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (moving == true)
        {
            FireflyMoving.SetActive(true);
            FireflyStationary.SetActive(false);
        }
        else
        {
            FireflyStationary.SetActive(true);
            FireflyMoving.SetActive(false);
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
            this.gameObject.transform.parent = null;
            this.gameObject.transform.parent = tougne.transform;
            moving = true;

            player.GetComponent<Player>().Fireflyeaten = true;
           //transform.position = snap.transform.position;
            //moving = true;
           
            Invoke("Destroy", 1f);

        }
        if (other.CompareTag("Rune"))
        {
            this.gameObject.transform.parent = Rune.transform;
            rb.velocity = Vector3.zero;
            transform.position = Rune.transform.position;
            

           
            //transform.position = snap.transform.position;
            //moving = true;

           // Invoke("Destroy", 1f);

        }

    }
    void Destroy()
    {
        gameObject.SetActive(false);
    }
}
