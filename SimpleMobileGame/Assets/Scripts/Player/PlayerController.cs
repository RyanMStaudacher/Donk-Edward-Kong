using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("The speed of the player")]
    [SerializeField] private float speed = 5f;

    [Tooltip("How high you jump")]
    [SerializeField] private float jumpSpeed = 5f;

    private Rigidbody2D playerRigidbody;
    private Vector2 touchOrigin;
    private Vector2 newTouchPosition;
    private Animator playerAnimator;
    private bool hasSetAnimatorBool = false;

    private void OnEnable()
    {
        JumpButton.shouldJump += Jump;
    }

    private void OnDisable()
    {
        JumpButton.shouldJump -= Jump;
    }

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        TestController();
    }

    private void TestController()
    {
        //Get touches
        if(Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];

            if(myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;
            }
            else if(myTouch.phase == TouchPhase.Moved)
            {
                newTouchPosition = myTouch.position;
            }

            //Move right
            if(newTouchPosition.x > touchOrigin.x)
            {
                if(!hasSetAnimatorBool)
                {
                    playerAnimator.SetBool("isMoving", true);
                    hasSetAnimatorBool = true;
                }

                transform.Translate(Vector3.right * speed * Time.deltaTime);

                if(GetComponent<SpriteRenderer>().flipX == true)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }
            //Move left
            else if(newTouchPosition.x < touchOrigin.x)
            {
                if (!hasSetAnimatorBool)
                {
                    playerAnimator.SetBool("isMoving", true);
                    hasSetAnimatorBool = true;
                }

                transform.Translate(-Vector3.right * speed * Time.deltaTime);

                if (GetComponent<SpriteRenderer>().flipX == false)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
            }
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
            hasSetAnimatorBool = false;
        }

        //Land
        if (playerRigidbody.velocity.y == 0f && playerAnimator.GetBool("isJumping") == true)
        {
            playerAnimator.SetBool("isJumping", false);
        }

#if UNITY_EDITOR
        //Move right
        if (Input.GetKey(KeyCode.D))
        {
            if (!hasSetAnimatorBool)
            {
                playerAnimator.SetBool("isMoving", true);
                hasSetAnimatorBool = true;
            }

            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (GetComponent<SpriteRenderer>().flipX == true)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        //Move left
        else if(Input.GetKey(KeyCode.A))
        {
            if (!hasSetAnimatorBool)
            {
                playerAnimator.SetBool("isMoving", true);
                hasSetAnimatorBool = true;
            }

            transform.Translate(-Vector3.right * speed * Time.deltaTime);

            if (GetComponent<SpriteRenderer>().flipX == false)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
#endif
    }

    private void Jump()
    {
        if(playerRigidbody.velocity.y == 0f && playerAnimator.GetBool("isJumping") == false)
        {
            playerRigidbody.AddForce(Vector2.up * jumpSpeed * Time.deltaTime, ForceMode2D.Impulse);
            playerAnimator.SetBool("isJumping", true);
        }
    }
}
