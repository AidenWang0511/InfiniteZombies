using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunAgain : PlayerController
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void tryAgain()
    {
        
        SceneManager.LoadScene("GameScene");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
