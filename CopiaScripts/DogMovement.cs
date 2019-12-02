using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    float scaleMove = 1f;
    float moveHorizontal;
    float moveVertical;
    public int boneValue = 0;
    public int life = 3;
    float euphoriaTimer = 0;
    float poopTimer = 0;
    Animator animator;
    SpriteRenderer renderer;
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
      rigidbody = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();
      renderer = GetComponent<SpriteRenderer>();
    }

    // FixedUpdate is called once before every physics update
    void FixedUpdate()
    {
      //Movimientos
      moveHorizontal = 0;
      moveVertical = 0;
        if(Input.GetAxis("Horizontal") != 0){
          if(Input.GetAxis("Horizontal") < 0) renderer.flipX = true;
          else renderer.flipX = false;
          moveHorizontal = scaleMove*Input.GetAxis("Horizontal");
        }
        else if(Input.GetKey(KeyCode.J)){
          renderer.flipX = true;
          moveHorizontal = scaleMove*-1;
        }
        else if(Input.GetKey(KeyCode.K)){
          renderer.flipX = false;
          moveHorizontal = scaleMove;
        }

        if(Input.GetAxis("Vertical") != 0)
          moveVertical = scaleMove*Input.GetAxis("Vertical");
        else if(Input.GetKey(KeyCode.I))
          moveVertical = scaleMove;
        else if(Input.GetKey(KeyCode.M))
          moveVertical = scaleMove*-1;


        //Animaciones
        // If the dog is moving in any direction, the running animation will be used
        if(rigidbody.velocity.x > 0.1 || rigidbody.velocity.x < -0.1 || rigidbody.velocity.y < -0.1 || rigidbody.velocity.y > 0.1)
          animator.SetBool("Running", true);
        else animator.SetBool("Running", false);
        rigidbody.velocity=moveHorizontal*transform.right+moveVertical*transform.up;

        // After a time has passed, the dog will loose any altered status he may have
        euphoriaTimer -= Time.deltaTime;
        poopTimer -= Time.deltaTime;
        if(euphoriaTimer <= 0) animator.SetBool("Bone", false);
        if(poopTimer <= 0) animator.SetBool("Poop", false);
    }

    // Upon encountering a bone, its value will be added to the total reward and the color will change to represent euphoria during 5 seconds
    public void AddBone(int value){
      boneValue += value;
      animator.SetBool("Bone", true);
      euphoriaTimer = 5;
      poopTimer = 0;
    }


    // Upon encountering a skull, a life will be lost and the dog's color will change to represent damage during 5 seconds
    public void Damage(int damage){
      life -= damage;
      animator.SetBool("Poop", true);
      if(life <= 0) Time.timeScale = 0;
      euphoriaTimer = 0;
      poopTimer = 5;
    }
}
