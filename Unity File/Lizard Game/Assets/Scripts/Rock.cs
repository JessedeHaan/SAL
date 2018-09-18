using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject player;
    public Transform RockRespawn;
    public GameObject rock;


    // Use this for initialization
    public void Awake()
    {


    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Let_Go"))
        {
            this.gameObject.transform.parent = null;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            player.GetComponent<Player>().rockPull = false;
            this.gameObject.transform.parent = null;
            Debug.Log("RespawnRock");

            rock.transform.position = RockRespawn.transform.position;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;



        }
    }
}
