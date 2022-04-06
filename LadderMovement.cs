/**
* ========================================================================================
* File:		LadderMovement.cs
* Author: 	Philipp Hermann
* Brief: 	this script handles movement on ladders and the connected animations.
* Date: 	06.04.2022
* Version: 	1.0
* ========================================================================================
* Licenced under the GNU general public licence v3.0
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour{

    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D playerrigidbody;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if(isLadder && Mathf.Abs(vertical)>0f){
            isClimbing = true;
            animator.SetBool("IsClimbing", true);
        }
        if(!isClimbing){
            animator.SetBool("IsClimbing", false);
        }
    }

    private void FixedUpdate(){
        if(isClimbing){
            playerrigidbody.gravityScale = 0f;
            playerrigidbody.velocity = new Vector2(playerrigidbody.velocity.x, vertical*speed);
        }
        else{
            playerrigidbody.gravityScale = 3f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision){
        if(collision.CompareTag("Ladder")){
            isLadder=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Ladder")){
            isLadder = false;
            isClimbing = false;
        }
    }
}
