using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textmeshcanvas : MonoBehaviour
{

    Canvas cnvs;
    bool paused = false;    
    // Start is called before the first frame update
    void Start()
    {
        cnvs = GetComponent<Canvas>();
        cnvs.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
        quitApplication();
    }

    void quitApplication()
    {
        if((Input.GetKey(KeyCode.Escape)))
        {
            paused = true;
        }

        if(paused == true)
        {
            Time.timeScale = 0;
            cnvs.enabled = true;
            
        }

        if((Input.GetKey(KeyCode.P)))
        {
            paused = false;
        }

        if(paused == false)
        {
            Time.timeScale = 1;
            cnvs.enabled = false;
        }


    }
}
