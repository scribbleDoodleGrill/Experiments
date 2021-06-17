using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    //[SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem jet1;
    [SerializeField] ParticleSystem jet2;
    [SerializeField] ParticleSystem jet3;
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;
       //bool isTransitioning = false;
     
    AudioSource audioSource;
  bool isTransitioning = false;
    bool collisionDisabled = false;


     void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

     void OnTriggerEnter(Collider other) 
    {
         if (isTransitioning || collisionDisabled) { return; }
       StartCrashSequence();

    }
//here to paste down


// here  to paste up

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.PlayOneShot(crash);

        crashVFX.Play();
                jet1.Stop();
        jet2.Stop();
        jet3.Stop();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }
// here to paste down

 //void StartSuccessSequence()
   // {
      
   //     GetComponent<PlayerControls>().enabled = false;
     //   Invoke("LoadNextLevel", loadDelay);
   // }



    //here to paste up

    void ReloadLevel()
    {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


//down is pasted
//void LoadNextLevel()
    //{
     //   int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      //  int nextSceneIndex = currentSceneIndex + 1;
     //   if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
       // {
      //      nextSceneIndex = 0;
       // }
       // SceneManager.LoadScene(nextSceneIndex);
    //}



}



