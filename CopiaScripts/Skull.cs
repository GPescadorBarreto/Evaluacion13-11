using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    int damage = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // When the dog reaches the skull, the skull deals damage to him
    void OnTriggerEnter2D(Collider2D other){
      other.gameObject.GetComponent<DogMovement>().Damage(damage);
      Destroy(gameObject);
    }
}
