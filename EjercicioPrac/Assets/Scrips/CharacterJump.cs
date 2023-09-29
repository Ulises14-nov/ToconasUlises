using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
        [SerializeField] private float jumpForce = 2500f;//fuerza
    private bool isGrounded;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    
    
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded && Input.GetButtonDown("Jump")){
            Jump();
        }
    }

   private void OnCollisionEnter2D(Collision2D collision) {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        isGrounded = false;
    }

    public void Jump(){
        rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
        PlayJumpSound();
    }

    private void PlayJumpSound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

}
