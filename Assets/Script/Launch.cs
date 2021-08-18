using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    //public GameObject bulletSpawned;
    public GameObject bulletSpawned;
    Rigidbody rb;
    private Transform cameraDirection;
    private Vector3 speed = new Vector3(0, 0, 100);
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        cameraDirection = Camera.main.transform;
        speed = cameraDirection.TransformDirection(speed);

    }

    

    // Update is called once per frame
    void Update()
    {
        
        
        rb.velocity = speed;
    }
}
