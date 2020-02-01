using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public enum PlayerType { Player1, Player2 };

    public PlayerType thisPlayerType;

    CharacterInfo charInfo;

    InputManager ipmanager;

    Rigidbody2D rb2D;

    bool moveRightFired;
    bool moveLeftFired;
    bool moveUpFired;

    [SerializeField] float groundRaycastDist;

    public bool isStandingOnGround;
    public bool jumpHeld;
    public bool jumpStarted;

    // Start is called before the first frame update
    void Start()
    {

        charInfo = this.gameObject.GetComponent<CharacterInfo>();

        rb2D = this.gameObject.GetComponent<Rigidbody2D>();

        ipmanager = GameObject.FindObjectOfType<InputManager>();

        if (thisPlayerType == PlayerType.Player1)
        {

            ipmanager.playerOne_Up += PlayerUp;
            ipmanager.playerOne_NotUp += PlayerNotUp;
            ipmanager.playerOne_Down += PlayerDown;
            ipmanager.playerOne_Left += PlayerLeft;
            ipmanager.playerOne_Right += PlayerRight;
            ipmanager.playerOne_X += PlayerX;

        } 

        if(thisPlayerType == PlayerType.Player2)
        {
            ipmanager.playerTwo_Up += PlayerUp;
            ipmanager.playerTwo_NotUp += PlayerNotUp;
            ipmanager.playerTwo_Down += PlayerDown;
            ipmanager.playerTwo_Left += PlayerLeft;
            ipmanager.playerTwo_Right += PlayerRight;
            ipmanager.playerTwo_X += PlayerX;

        }

    }

    // Update is called once per frame
    void Update()
    {

        LayerMask groundLayer = LayerMask.GetMask("groundCollider");

        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, groundRaycastDist, groundLayer);

        if(hit.collider != null)
        {

            Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.gameObject.CompareTag("Ground"))
                isStandingOnGround = true;
            else
                isStandingOnGround = false;

        } else
        {
            isStandingOnGround = false;
        }

    }


    private void LateUpdate()
    {

        //change velocity depending on whether a particular function was fired or not in this frame

        if (moveLeftFired)
        {
            moveLeftFired = false;

        } else
        {
            //If there was no move left input, set the horizontal velocity to 0
            if(rb2D.velocity.x < 0)
            {

                Vector2 newVel = new Vector2(0, rb2D.velocity.y);

                rb2D.velocity = newVel;

            }


        }

        if (moveRightFired)
        {
            moveRightFired = false;

        }
        else
        {
            //If there was no move left input, set the horizontal velocity to 0
            if (rb2D.velocity.x > 0)
            {

                Vector2 newVel = new Vector2(0, rb2D.velocity.y);

                rb2D.velocity = newVel;

            }


        }

        if (!moveUpFired)
        {
            if (rb2D.velocity.y > 0)
            {

                Vector2 newVel = new Vector2(rb2D.velocity.x, 0);

                rb2D.velocity = newVel;

            }

            jumpHeld = false;
        }

        

    }


    //Functions to manage inputs (movement functions) + special actions

    void PlayerUp()
    {
        if(jumpStarted)
            jumpHeld = true;

        if (isStandingOnGround && !moveUpFired)
        {

            StartCoroutine(JumpCoroutine());

            StartCoroutine(JumpCDHeld());

            jumpStarted = true;

        } else
        {

            

        }

        moveUpFired = true;

    }

    void PlayerNotUp()
    {

        moveUpFired = false;

    }

    IEnumerator JumpCoroutine()
    {
        
        if (!jumpHeld)
        {

            yield return null;

        }

        while (jumpHeld)
        {
            if (this.rb2D.velocity.y < charInfo.GetMaxJumpSpeed())
            {
                //positive x
                Vector3 upDir = new Vector3(0, 1, 0);

                rb2D.AddForce(upDir * charInfo.GetJumpHeight());
            }

            yield return new WaitForEndOfFrame();
        }

        

    }

    IEnumerator JumpCDHeld ()
    {

        yield return new WaitForSeconds(charInfo.GetJumpKeypress());

        jumpHeld = false;

        jumpStarted = false;

    }




    void PlayerDown()
    {
        


    }


    void PlayerRight()
    {

        if (Mathf.Abs(rb2D.velocity.x) < charInfo.GetMaxMovespeed())
        {
            //positive x
            Vector2 rightDir = new Vector2(1, 0);

            rb2D.AddForce(rightDir * charInfo.GetMoveSpeed());
        }

        moveRightFired = true;

    }


    void PlayerLeft()
    {
        if (Mathf.Abs(rb2D.velocity.x) < charInfo.GetMaxMovespeed())
        {

            //negative x

            Vector2 leftDir = new Vector2(-1, 0);

            rb2D.AddForce(leftDir * charInfo.GetMoveSpeed());

        }

        moveLeftFired = true;

    }


    void PlayerX()
    {



    }



    //Lose Health functions (collision detection)

    private void OnCollisionEnter2D(Collision2D collision)
    {

        BodypartInfo bpi = collision.gameObject.GetComponent<BodypartInfo>();

        if (bpi != null)
        {

            if(charInfo.SetBodyPart(bpi.thisBodyPart, true))
                Destroy(bpi.gameObject);


        }

        if (collision.gameObject.CompareTag("Damage"))
        {

            charInfo.LoseRandomBodyPart();

        }

        if (collision.gameObject.CompareTag("Item"))
        {

            ItemInfo item = collision.gameObject.GetComponent<ItemInfo>();

            if(item.thisItemType != ItemInfo.ItemType.None)
            {

                charInfo.EquipItem(item.thisItemType);

            }

        }



    }





}
