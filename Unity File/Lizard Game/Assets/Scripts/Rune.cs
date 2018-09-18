using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour {

    public GameObject fireflyOB;
    public Transform BridgeSpawnPoint;
    public GameObject bridgeOB;
    // Use this for initialization
    private void Awake()
    {
        bridgeOB.SetActive(false);
    }
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.childCount > 3)
            {
            Debug.Log("bridge is being made");
            bridgeOB.SetActive(true);
            bridgeOB.transform.position = BridgeSpawnPoint.transform.position;
            //Do stuff here
        }
        else
        {
            bridgeOB.SetActive(false);
        }
    }
}
