using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFly : MonoBehaviour {
    public GameObject tougne;
    public GameObject target;
    public Collider flyColider;
    public bool moving;
   
    public float speed;
    // Use this for initialization
    void Start () {
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {
       if(moving == true)
        {
            float move = speed * Time.deltaTime;
            Debug.Log("firefly hit");
            transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, move);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tougne"))
        {
            moving = true;
            Destroy(flyColider);
            Invoke("Destroy", 1f);

        }

    }
    void Destroy()
    {
        gameObject.SetActive(false);
    }
}
