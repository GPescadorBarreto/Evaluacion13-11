using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject bee;
    int beeDirection = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // FixedUpdate is called before every physics update
    // The bee will fly above the ground back and forth between the boundaries of the scenery
    void FixedUpdate()
    {
      if(bee.transform.position.x < -5){
         beeDirection = 1;
         bee.GetComponent<SpriteRenderer>().flipX = true;

       }
      else if(bee.transform.position.x > 3.5){
        bee.GetComponent<SpriteRenderer>().flipX = false;
        beeDirection = -1;
      }
      bee.transform.position += 0.03f*beeDirection*transform.right;
    }
}
