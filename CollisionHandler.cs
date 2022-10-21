using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CollisionHandler : MonoBehaviour
{
    AudioSource au;
    
    [SerializeField] AudioClip CrashSound;
    [SerializeField] AudioClip SuccessSound;

    [SerializeField] ParticleSystem CrashParticles;
    [SerializeField] ParticleSystem SuccessParticles;
    
    bool crashed = false;
    bool collisionDisabled = false;
        
    

    void Start() 
    {
       
        au = GetComponent<AudioSource>();
    }

    void Update() 
    {
        
        respondTotheDebug();
        
    }

     void respondTotheDebug()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            loadNextLevel();
        }

        else if(Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = true;
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if (crashed == true || collisionDisabled == true){return;}        
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is friendly");
                break;
            case "Finish":
                Debug.Log("FİNİSHHH");
                startSuccess();
                Invoke("loadNextLevel",1.5f);
                break;
            default:
                Debug.Log("You blew up!");
                crashed = true;
                StartCrashSequence();
                break;
        }
            
    }
    public void loadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex +1;
        if (nextSceneIndex ==SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void reloadTheScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }   

    void startSuccess()
    {
        crashed = true;
        au.Stop();
        au.PlayOneShot(SuccessSound);
        SuccessParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("loadNextLevel", 1.5f);
    }

    void StartCrashSequence()
    {
        crashed = true;
        au.Stop();
        au.PlayOneShot(CrashSound);
        CrashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("reloadTheScene", 1.5f);
        
    }

}

