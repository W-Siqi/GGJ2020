using System.Collections;
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

        playerOneHand_Empty.SetActive(true);
        playerOneHand_Empty.SetActive(false);

        playerOneHeart_Empty.SetActive(true);
        playerOneHeart_Full.SetActive(false);


        playerTwoHand_Empty.SetActive(true);
        playerTwoHand_Full.SetActive(false);

        playerTwoLegs_Empty.SetActive(true);
        playerTwoLegs_Full.SetActive(false);

        playerTwoChest_Empty.SetActive(true);
        playerTwoChest_Full.SetActive(false);

        playerTwoHand_Empty.SetActive(true);
        playerTwoHand_Empty.SetActive(false);

        playerTwoHeart_Empty.SetActive(true);
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
        }
        else
        {

            playerOneChest_Full.SetActive(false);
            playerOneChest_Empty.SetActive(true);

        }

        if (playerOne_CharInfo.hasHeart)
        {

            playerOneHeart_Full.SetActive(true);
            playerOneHeart_Empty.SetActive(false);
        }
        else
        {

            playerOneHeart_Full.SetActive(false);
            playerOneHeart_Empty.SetActive(true);

        }

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
        }
        else
        {

            playerTwoChest_Full.SetActive(false);
            playerTwoChest_Empty.SetActive(true);

        }

        if (playerTwo_CharInfo.hasHeart)
        {

            playerTwoHeart_Full.SetActive(true);
            playerTwoHeart_Empty.SetActive(false);
        }
        else
        {

            playerTwoHeart_Full.SetActive(false);
            playerTwoHeart_Empty.SetActive(true);

        }

    }
}
