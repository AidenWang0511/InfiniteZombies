using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bullet;
    public float shootSpeed;
    private float timeTracker;
    private bool canShoot = true;
    public FixedButton Fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CurrentLocation = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        Quaternion CurrentRotation = Quaternion.Euler(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z);
        if ((Fire.Pressed || Input.GetKey(KeyCode.Mouse0)) && canShoot)
        {
            //Input.GetKey(KeyCode.Mouse0)
            //Handheld.Vibrate();
            Instantiate(bullet, CurrentLocation, CurrentRotation);
            canShoot = false;
        }
        timeTracker += Time.deltaTime;
        if (timeTracker >= shootSpeed)
        {
            canShoot = true;
            timeTracker = timeTracker - shootSpeed;
        }

    }
}
