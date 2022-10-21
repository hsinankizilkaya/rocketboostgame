using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource au;
    
    [SerializeField] AudioClip mainEngine;
    [SerializeField] float ThrustForce = 1.2f;
    [SerializeField] float RotateSpeed = 1f;
    [SerializeField] ParticleSystem JetGasParticles;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        au = GetComponent<AudioSource>();
    }
    void Update()
    {
        processThrust();
        processRotate();
    }
    public void processThrust()
    {
        Physics.gravity = new Vector3(0,-40f,0);
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(0,0,ThrustForce * Time.deltaTime);
            if(!au.isPlaying)
            {
                au.PlayOneShot(mainEngine);
            }
            if(!JetGasParticles.isPlaying)
            {
                JetGasParticles.Play();
            }
            
        }
        else
        {
            au.Stop();
            JetGasParticles.Stop();
        }
    }
    

    private void processRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.Rotate(Vector3.left * RotateSpeed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.transform.Rotate(Vector3.right * RotateSpeed * Time.deltaTime);
        }

    }
}
