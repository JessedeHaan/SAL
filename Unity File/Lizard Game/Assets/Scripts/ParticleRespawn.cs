using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRespawn : MonoBehaviour {
    public Transform FireflyrespawnPoint;
    public GameObject FireflyGo;
    public GameObject  runeOB;
  

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
           
            Debug.Log("Respawn");
            FireflyGo.transform.position = FireflyrespawnPoint.transform.position;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<FireFly>().moving = false;
           

        }
        if (other.CompareTag("Rune"))
        {
            
                FireflyrespawnPoint.transform.position = runeOB.transform.position;
            
        }
        else return;
    }
}
