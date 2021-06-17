using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start here");
        StartCoroutine (FollowPath());
        Debug.Log("Finishing start");
        
    }

    IEnumerator FollowPath()
  {
      foreach(Waypoint waypoint in path)
      {
          transform.position = waypoint.transform.position;
          Debug.Log(waypoint.name);
          yield return new WaitForSeconds(waitTime);
      }

  }


}
