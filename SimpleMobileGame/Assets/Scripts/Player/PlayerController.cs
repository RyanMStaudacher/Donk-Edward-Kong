using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("The speed of the player")]
    [SerializeField] private float speed = 5f;

    //[Tooltip("The max speed of the player")]
    //[SerializeField] private float maxSpeed = 5f;

    private Vector2 touchOrigin;
    private Vector2 newTouchPosition;
    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody;
    private bool hasSetAnimatorBool = false;

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

                //playerRigidbody.AddForce(Vector2.right * speed * Time.deltaTime);

                //if (playerRigidbody.velocity.magnitude >= maxSpeed)
                //{
                //    playerRigidbody.velocity = playerRigidbody.velocity.normalized * maxSpeed;
                //}

                //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
            }
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

                //playerRigidbody.AddForce(-Vector2.right * speed * Time.deltaTime);

                //if (playerRigidbody.velocity.magnitude >= maxSpeed)
                //{
                //    playerRigidbody.velocity = playerRigidbody.velocity.normalized * maxSpeed;
                //}

                //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
            }
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
            hasSetAnimatorBool = false;
        }

        //if (Input.GetKey(KeyCode.D))
        //{
        //    if (!hasSetAnimatorBool)
        //    {
        //        playerAnimator.SetBool("isMoving", true);
        //        hasSetAnimatorBool = true;
        //    }
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);

        //    if (GetComponent<SpriteRenderer>().flipX == true)
        //    {
        //        GetComponent<SpriteRenderer>().flipX = false;
        //    }
        //    //playerRigidbody.AddForce(Vector2.right * speed * Time.deltaTime);

        //    //if (playerRigidbody.velocity.magnitude >= maxSpeed)
        //    //{
        //    //    playerRigidbody.velocity = playerRigidbody.velocity.normalized * maxSpeed;
        //    //}

        //    //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    if (!hasSetAnimatorBool)
        //    {
        //        playerAnimator.SetBool("isMoving", true);
        //        hasSetAnimatorBool = true;
        //    }
        //    transform.Translate(-Vector3.right * speed * Time.deltaTime);

        //    if (GetComponent<SpriteRenderer>().flipX == false)
        //    {
        //        GetComponent<SpriteRenderer>().flipX = true;
        //    }
        //    //playerRigidbody.AddForce(-Vector2.right * speed * Time.deltaTime);

        //    //if (playerRigidbody.velocity.magnitude >= maxSpeed)
        //    //{
        //    //    playerRigidbody.velocity = playerRigidbody.velocity.normalized * maxSpeed;
        //    //}

        //    //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
        //}
        //else
        //{
        //    //playerAnimator.SetBool("isMoving", false);
        //}
    }
}
