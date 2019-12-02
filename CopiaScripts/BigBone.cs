using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBone : MonoBehaviour
{
  public int value = 3;

  // Start is called before the first frame update
  void Start()
  {}

  // Update is called once per frame
  void Update()
  {}

  // When the dog reaches the bone, the bone gives him its value as a reward
  void OnTriggerEnter2D (Collider2D other){
    other.gameObject.GetComponent<DogMovement>().AddBone(value);
    Destroy(gameObject); // Destroy the bone
  }
}
