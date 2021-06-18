using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxiHitPoints = 5;
    [SerializeField] int currentHitPoint = 0;
   
    void Start()
    {
        currentHitPoint = maxiHitPoints;
    }

    
   void OnParticleCollision(GameObject other) {
        ProcessHit();
    }
    
    void ProcessHit ()
    {
        currentHitPoint--;
        if(currentHitPoint <= 0){
            Destroy(gameObject);
        }
    }
        
   
}
