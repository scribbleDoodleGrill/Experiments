using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;
     [SerializeField] ParticleSystem leftThrusterParticles;
      [SerializeField] ParticleSystem rightThrusterParticles;


    Rigidbody rb;
    AudioSource audioSource;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
             rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
               if(!audioSource.isPlaying)
               {
                audioSource.PlayOneShot(mainEngine); 
               }
               if (!mainEngineParticles.isPlaying)
               {
                    mainEngineParticles.Play();
               }
               
             
        }
           else
        {
            audioSource.Stop();        
            mainEngineParticles.Stop();
        } 
               
    }

         void ProcessRotation()
    {
         if (Input.GetKey(KeyCode.A))
         {
            ApplyRotation(rotationThrust);
            if (!rightThrusterParticles.isPlaying)
               {
                    rightThrusterParticles.Play();
               }
         }
        else if (Input.GetKey(KeyCode.D))
        {
           ApplyRotation(-rotationThrust);
            if (!leftThrusterParticles.isPlaying)
               {
                    leftThrusterParticles.Play();
               }
        }
        else
        {
            rightThrusterParticles.Stop();
            leftThrusterParticles.Stop();

        }
    }

     void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
    

}
