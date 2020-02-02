using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public delegate void PlayerInputRec();

    public event PlayerInputRec playerOne_Up;
    public event PlayerInputRec playerOne_NotUp;
    public event PlayerInputRec playerOne_Right;
    public event PlayerInputRec playerOne_Left;
    public event PlayerInputRec playerOne_Down;
    public event PlayerInputRec playerOne_X;

    public event PlayerInputRec playerTwo_Up;
    public event PlayerInputRec playerTwo_NotUp;
    public event PlayerInputRec playerTwo_Right;
    public event PlayerInputRec playerTwo_Left;
    public event PlayerInputRec playerTwo_Down;
    public event PlayerInputRec playerTwo_X;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //--------PLAYER 1 INPUTS--------------------

        //UP
        if (Input.GetKey(KeyCode.W))
        {

            playerOne_Up?.Invoke();

        } else
        {

            playerOne_NotUp?.Invoke();
            
        }


        //DOWN
        if (Input.GetKey(KeyCode.S))
        {

            playerOne_Down?.Invoke();

        }
        //LEFT
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {

            playerOne_Left?.Invoke();

        }
        //RIGHT
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {

            playerOne_Right?.Invoke();

        }
        //SPECIAL
        if (Input.GetKeyDown(KeyCode.Space))
        {

            playerOne_X?.Invoke();

        }

        //############################################
        //--------PLAYER 2 INPUTS--------------------

        //UP
        if (Input.GetKey(KeyCode.UpArrow))
        {

            playerTwo_Up?.Invoke();

        } else
        {

            playerTwo_NotUp?.Invoke();

        }


        //DOWN
        if (Input.GetKey(KeyCode.DownArrow))
        {

            playerTwo_Down?.Invoke();

        }
        //LEFT (avoiding condition when both left and right are pressed together)
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {

            playerTwo_Left?.Invoke();

        }
        //RIGHT (avoiding condition when both left and right are pressed together)
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {

            playerTwo_Right?.Invoke();

        }
        //SPECIAL
        if (Input.GetKeyDown(KeyCode.Return))
        {

            playerTwo_X?.Invoke();

        }



    }

    private void FixedUpdate()
    {


    }

}
