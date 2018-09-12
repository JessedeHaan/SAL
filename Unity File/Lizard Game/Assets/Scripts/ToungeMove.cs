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

    void OnEnable()
    {
        gameObject.transform.position = startPoint.position;
        pos1 = startPoint.transform.position;
        pos2 = endPoint.transform.position;
        Invoke("Destroy", 0.5f);
    }
    // Use this for initialization
    void Start () {

       
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1f));
    }
    void Destroy()
    {
        gameObject.transform.position = startPoint.position;
        gameObject.SetActive(false); 
        //Destroy(gameObject);
    }
}
