using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehavior : MonoBehaviour {

  
    
    public Transform ammoPos;
    public GameObject PlayerPos;
    public GameObject PlayerPos2;
    private GameObject target;
    private GameObject target2;
    



    [SerializeField]
    public float RangeDetect =30f;
    public float speed;
    // Use this for initialization
    void Start () {
       
        //target = GameObject.FindObjectOfTyp.name("Player_1");
    }
	
	// Update is called once per frame
	void Update () {
       
        float move = speed * Time.deltaTime;


        target = GameObject.Find("Player_1");

        target2 = GameObject.Find("Player_2");


        if (target != null) {

            if (Vector3.Distance(transform.position, target.transform.position) < RangeDetect)
            {


               
                transform.position = Vector3.MoveTowards(ammoPos.transform.position, target.transform.position, move);
            }
        }

        if (target2 != null) {
            if (Vector3.Distance(ammoPos.transform.position, target2.transform.position) < RangeDetect)
            {
                
                transform.position = Vector3.MoveTowards(ammoPos.transform.position, target2.transform.position, move);
            }
        }



    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RangeDetect);
    }

    


   
    


}
