using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainDestroy : MonoBehaviour {

     void OnEnable()
    {
        Invoke("Destroy", 2f);
    }
    void Destroy()
    {
        gameObject.SetActive(false);
    }
    void OnDisable()
    {
        CancelInvoke();
    }
}
