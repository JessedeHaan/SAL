using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToungeMove : MonoBehaviour {
    
    public Transform startPoint;
    public Transform endPoint;
    [SerializeField]
    public float speed;
    private Vector3 pos1;
    private Vector3 pos2;
    public float rotateSpeed = 5f;



    void OnEnable()
    {
       
     
        pos1 = startPoint.transform.position;
        gameObject.transform.position = pos1;
       pos2 = endPoint.transform.position;
        Invoke("Destroy", 0.5f);
    }
    // Use this for initialization
    void Start () {

       
        
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 Currentpos = startPoint.position;
        Vector3 targetpos = endPoint.position;
        if (Vector3.Distance(Currentpos, targetpos) > .1f)
        {
            Vector3 directionOfTravel = targetpos - Currentpos;
            //now normalize the direction, since we only want the direction information
            directionOfTravel.Normalize();
            //scale the movement on each axis by the directionOfTravel vector components

            this.transform.Translate(
                (directionOfTravel.x * speed * Time.deltaTime),
                (directionOfTravel.y * speed * Time.deltaTime),
                (directionOfTravel.z * speed * Time.deltaTime),
                Space.World);
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
        //transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1f));
       

    }
    

public void Destroy()
    {
        gameObject.SetActive(false);
    }
}

