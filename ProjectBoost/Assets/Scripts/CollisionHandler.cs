using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnCollisionEnter(Collision other)

    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                 StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }

    void StartSuccessSequence()
    {
       audioSource.PlayOneShot(success);
        // to do add particle effect upon crash
         GetComponent<Movement>().enabled = false;
    Invoke ("LoadNextLevel" , LevelLoadDelay);
    }
    void StartCrashSequence()
    {
        audioSource.PlayOneShot(crash);
        // to do add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke ("ReloadLevel", LevelLoadDelay);
    }


    }

    void LoadNextLevel()
    {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    
    }


    void ReloadLevel ()
       {
           int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
           SceneManager.LoadScene(currentSceneIndex);
    }
}
