using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{

    public bool hasHead { get; private set; }
    public bool hasHands { get; private set; }
    public bool hasLegs { get; private set; }
    public bool hasChest { get; private set; }
    public bool hasHeart { get; private set; }

    public ItemInfo.ItemType equippedItem;

    [SerializeField] float normalJumpForce;
    [SerializeField] float legsJumpForce;
    [SerializeField] float moveForce;
    [SerializeField] float maxSpeed;
    [SerializeField] float maxJumpSpeed;
    [SerializeField] float maxJumpKeypress;

    [SerializeField] int chestHealth;

    public int playerHealth = 0;

    public int playerHealthBuffer = 0;

    // Start is called before the first frame update
    void Start()
    {

        equippedItem = ItemInfo.ItemType.None;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SetBodyPart( BodypartInfo.BodyPart bodyPartToSet, bool isAdd )
    {

        if (bodyPartToSet == BodypartInfo.BodyPart.Hands && !hasHands)
        {
            hasHands = isAdd;

            if (!isAdd)
            {
                equippedItem = ItemInfo.ItemType.None;
                DropEquippedItem();
            }

            return true;
        }

        if (bodyPartToSet == BodypartInfo.BodyPart.Legs && !hasLegs)
        {
            hasLegs = isAdd;
            return true;
        }

        if (bodyPartToSet == BodypartInfo.BodyPart.Chest && !hasChest)
        {
            hasChest = isAdd;

            if (isAdd)
            {
                BufferHealthModifier(chestHealth);
            } else
            {
                BufferHealthModifier(-chestHealth);
            }
                
            return true;
        }

        if (bodyPartToSet == BodypartInfo.BodyPart.Head && !hasHead)
        {
            hasHead = isAdd;
            return true;
        }

        if (bodyPartToSet == BodypartInfo.BodyPart.Heart && !hasHeart)
        {
            hasHeart = isAdd;
            return true;
        }

        return false;

    }

    public void LoseRandomBodyPart()
    {

        if(playerHealthBuffer > 0)
        {

            playerHealthBuffer--;

            return;
        }

        List<BodypartInfo.BodyPart> currentBodyParts = new List<BodypartInfo.BodyPart>();

        if (hasHands)
            currentBodyParts.Add(BodypartInfo.BodyPart.Hands);

        if (hasLegs)
            currentBodyParts.Add(BodypartInfo.BodyPart.Legs);

        if (hasChest)
            currentBodyParts.Add(BodypartInfo.BodyPart.Chest);

        if (hasHead)
            currentBodyParts.Add(BodypartInfo.BodyPart.Head);

        if (hasHeart)
            currentBodyParts.Add(BodypartInfo.BodyPart.Heart);

        //Choose random body part

        if (currentBodyParts.Count == 0)
            return;

        int randInt = Random.Range(0, currentBodyParts.Count);

        BodypartInfo.BodyPart dropPart = currentBodyParts[randInt];

        SetBodyPart(dropPart, false);

    }


    void BufferHealthModifier(int amt)
    {

        playerHealthBuffer += amt;

        if (playerHealthBuffer < 0)
            playerHealthBuffer = 0;

        if (playerHealth > chestHealth)
            playerHealthBuffer = chestHealth;

    }


    public void EquipItem(ItemInfo.ItemType item)
    {
        if (!hasHands)
        {
            return;
        }

        if (equippedItem == item)
        {

            return;

        }
        else
        {
            equippedItem = item;
            DropEquippedItem();
        }
    }

    void DropEquippedItem()
    {

        //TODO - drop equipped item

    }

    //GETTER FUNCTIONS
    public float GetMoveSpeed()
    {
        return moveForce;
    }

    public float GetJumpHeight()
    {
        if (hasLegs)
            return legsJumpForce;
        else
            return normalJumpForce;

    }

    public float GetMaxMovespeed()
    {

        return maxSpeed;

    }

    public float GetMaxJumpSpeed()
    {

        return maxJumpSpeed;

    }

    public float GetJumpKeypress()
    {

        return maxJumpKeypress;

    }



}
