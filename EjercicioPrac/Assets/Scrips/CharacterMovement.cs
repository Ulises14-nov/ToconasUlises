using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
        [SerializeField] private float movementSpeed=1250f; 
   private bool isFacingRight=true;
   private Rigidbody2D rb;

    private void Start()
    {
	rb=GetComponent<Rigidbody2D>();        
    }

    private void Update()
    {
		float movementX=Input.GetAxis("Horizontal");
		Move(movementX*movementSpeed); 
		if(movementX <0 && isFacingRight)
		{	
			Flip();
		}else if(movementX >0 && !isFacingRight)
		{	
			Flip();
		}   
    }

	public void Move(float velocity){
		rb.velocity=new Vector2(velocity*Time.deltaTime, rb.velocity.y);
	}
	private void Flip(){
		transform.localScale=new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		isFacingRight=!isFacingRight;
	}

}
