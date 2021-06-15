using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 2;

    ScoreBoard scoreBoard;

    void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }


   void OnParticleCollision(GameObject other)
    {
            ProcessHit();
            if (hitPoints <1)
            {
                KillEnemy();
            }
    }

    void ProcessHit()
    {
        hitPoints--;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void KillEnemy ()
    {
          GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parent;
            Destroy(gameObject);
    }




}
