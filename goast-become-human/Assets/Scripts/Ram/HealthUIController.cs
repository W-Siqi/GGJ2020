﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUIController : MonoBehaviour
{
    [SerializeField] GameObject playerOneLegs_Full;
    [SerializeField] GameObject playerOneHand_Full;
    [SerializeField] GameObject playerOneChest_Full;
    [SerializeField] GameObject playerOneShield_Full;
    [SerializeField] GameObject playerOneHead_Full;
    [SerializeField] GameObject playerOneHeart_Full;
    [SerializeField] GameObject playerOneLegs_Empty;
    [SerializeField] GameObject playerOneHand_Empty;
    [SerializeField] GameObject playerOneChest_Empty;
    [SerializeField] GameObject playerOneShield_Empty;
    [SerializeField] GameObject playerOneHead_Empty;
    [SerializeField] GameObject playerOneHeart_Empty;
   
    

    [SerializeField] GameObject playerTwoLegs_Full;
    [SerializeField] GameObject playerTwoHand_Full;
    [SerializeField] GameObject playerTwoChest_Full;
    [SerializeField] GameObject playerTwoShield_Full;
    [SerializeField] GameObject playerTwoHead_Full;
    [SerializeField] GameObject playerTwoHeart_Full;
    [SerializeField] GameObject playerTwoLegs_Empty;
    [SerializeField] GameObject playerTwoHand_Empty;
    [SerializeField] GameObject playerTwoChest_Empty;
    [SerializeField] GameObject playerTwoShield_Empty;
    [SerializeField] GameObject playerTwoHead_Empty;
    [SerializeField] GameObject playerTwoHeart_Empty;

    CharacterInfo playerOne_CharInfo;
    CharacterInfo playerTwo_CharInfo;

    // Start is called before the first frame update
    void Start()
    {
     
        foreach ( CharacterInfo ci in GameObject.FindObjectsOfType<CharacterInfo>())
        {
            if (ci.gameObject.GetComponent<CharacterController>().thisPlayerType == CharacterController.PlayerType.Player1)
                playerOne_CharInfo = ci;

            if (ci.gameObject.GetComponent<CharacterController>().thisPlayerType == CharacterController.PlayerType.Player2)
                playerTwo_CharInfo = ci;

        }

        playerOneHand_Empty.SetActive(true);
        playerOneHand_Full.SetActive(false);

        playerOneLegs_Empty.SetActive(true);
        playerOneLegs_Full.SetActive(false);

        playerOneChest_Empty.SetActive(true);
        playerOneChest_Full.SetActive(false);

        playerOneShield_Empty.SetActive(true);
        playerOneShield_Full.SetActive(false);

        playerOneHand_Empty.SetActive(true);
        playerOneHand_Empty.SetActive(false);

        playerOneHeart_Empty.SetActive(false);
        playerOneHeart_Full.SetActive(false);


        playerTwoHand_Empty.SetActive(true);
        playerTwoHand_Full.SetActive(false);

        playerTwoLegs_Empty.SetActive(true);
        playerTwoLegs_Full.SetActive(false);

        playerTwoChest_Empty.SetActive(true);
        playerTwoChest_Full.SetActive(false);

        playerTwoShield_Empty.SetActive(true);
        playerTwoShield_Full.SetActive(false);

        playerTwoHand_Empty.SetActive(true);
        playerTwoHand_Empty.SetActive(false);

        playerTwoHeart_Empty.SetActive(false);
        playerTwoHeart_Full.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (playerOne_CharInfo.hasHands)
        {

            playerOneHand_Full.SetActive(true);
            playerOneHand_Empty.SetActive(false);
        } else
        {

            playerOneHand_Full.SetActive(false);
            playerOneHand_Empty.SetActive(true);

        }

        if (playerOne_CharInfo.hasLegs)
        {

            playerOneLegs_Full.SetActive(true);
            playerOneLegs_Empty.SetActive(false);
        }
        else
        {

            playerOneLegs_Full.SetActive(false);
            playerOneLegs_Empty.SetActive(true);

        }

        if (playerOne_CharInfo.hasHead)
        {

            playerOneHead_Full.SetActive(true);
            playerOneHead_Empty.SetActive(false);
        }
        else
        {

            playerOneHead_Full.SetActive(false);
            playerOneHead_Empty.SetActive(true);

        }

        if (playerOne_CharInfo.hasChest)
        {

            playerOneChest_Full.SetActive(true);
            playerOneChest_Empty.SetActive(false);

            if(playerOne_CharInfo.playerHealthBuffer > 0)
            {

                playerOneShield_Full.SetActive(true);
                playerOneShield_Empty.SetActive(false);

            } else
            {
                playerOneShield_Empty.SetActive(true);
                playerOneShield_Full.SetActive(false);

            }

        }
        else
        {

            playerOneChest_Full.SetActive(false);
            playerOneChest_Empty.SetActive(true);

            playerOneShield_Empty.SetActive(true);
            playerOneShield_Full.SetActive(false);

        }

        if (playerOne_CharInfo.hasHeart)
        {

            playerOneHeart_Full.SetActive(true);
            playerOneHeart_Empty.SetActive(false);
        }
        
        if(playerOne_CharInfo.hasChest && playerOne_CharInfo.hasHands && playerOne_CharInfo.hasLegs && playerOne_CharInfo.hasHead )
        {

            playerOneHeart_Empty.SetActive(true);

        } else
        {

            playerOneHeart_Empty.SetActive(false);

        }


        // ---------- PLAYER TWO  --------------------

        if (playerTwo_CharInfo.hasHands)
        {

            playerTwoHand_Full.SetActive(true);
            playerTwoHand_Empty.SetActive(false);
        }
        else
        {

            playerTwoHand_Full.SetActive(false);
            playerTwoHand_Empty.SetActive(true);

        }

        if (playerTwo_CharInfo.hasLegs)
        {

            playerTwoLegs_Full.SetActive(true);
            playerTwoLegs_Empty.SetActive(false);
        }
        else
        {

            playerTwoLegs_Full.SetActive(false);
            playerTwoLegs_Empty.SetActive(true);

        }

        if (playerTwo_CharInfo.hasHead)
        {

            playerTwoHead_Full.SetActive(true);
            playerTwoHead_Empty.SetActive(false);
        }
        else
        {

            playerTwoHead_Full.SetActive(false);
            playerTwoHead_Empty.SetActive(true);

        }

        if (playerTwo_CharInfo.hasChest)
        {

            playerTwoChest_Full.SetActive(true);
            playerTwoChest_Empty.SetActive(false);

            if (playerTwo_CharInfo.playerHealthBuffer > 0)
            {

                playerTwoShield_Full.SetActive(true);
                playerTwoShield_Empty.SetActive(false);

            }
            else
            {
                playerTwoShield_Empty.SetActive(true);
                playerTwoShield_Full.SetActive(false);

            }

        }
        else
        {

            playerTwoChest_Full.SetActive(false);
            playerTwoChest_Empty.SetActive(true);

            playerTwoShield_Full.SetActive(false);
            playerTwoShield_Empty.SetActive(true);

        }

        if (playerTwo_CharInfo.hasHeart)
        {

            playerTwoHeart_Full.SetActive(true);
            playerTwoHeart_Empty.SetActive(false);
        }
        if(playerTwo_CharInfo.hasChest && playerTwo_CharInfo.hasHands && playerTwo_CharInfo.hasLegs && playerTwo_CharInfo.hasHead)
        {
            playerTwoHeart_Empty.SetActive(true);

        } else
        {

            playerTwoHeart_Empty.SetActive(false);

        }

        HeartScaleAnim();

    }

    void HeartScaleAnim()
    {

        if(playerOneHeart_Empty.transform.parent.localScale.x > 2.5)
        {

            playerOneHeart_Empty.transform.parent.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        } else
        {

            playerOneHeart_Empty.transform.parent.localScale += Vector3.one * (Time.deltaTime / 3);

        }

        if (playerTwoHeart_Empty.transform.parent.localScale.x > 2.5)
        {

            playerTwoHeart_Empty.transform.parent.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        }
        else
        {

            playerTwoHeart_Empty.transform.parent.localScale += Vector3.one * (Time.deltaTime / 3);

        }

    }


}
