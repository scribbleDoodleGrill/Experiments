using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)

    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                 Debug.Log("Congrats you finished");
                break;
            case "Fuel":
                Debug.Log("You picked up a fuel");
                break;
            default:
                ReloadLevel();
                break;
        }




    }

    void ReloadLevel ()
       {
        SceneManager.LoadScene(0);
    }
}
