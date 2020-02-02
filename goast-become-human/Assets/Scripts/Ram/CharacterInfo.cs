using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{

    public bool hasHead;
    public bool hasHands;
    public bool hasLegs;
    public bool hasChest;
    public bool hasHeart;

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

    AudioSource audioSource;
    SoundRepo soundRepo;

    bool winSoundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {

        equippedItem = ItemInfo.ItemType.None;

        audioSource = this.gameObject.GetComponent<AudioSource>();

        soundRepo = GameObject.FindObjectOfType<SoundRepo>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!winSoundPlayed)
        {

            if (hasHands && hasLegs && hasHead && hasChest && hasHeart)
            {
                audioSource.PlayOneShot(GameObject.FindObjectOfType<SoundRepo>().win);
                winSoundPlayed = true;
            }
        }

    }

    public bool SetBodyPart( BodypartInfo.BodyPart bodyPartToSet, bool isAdd )
    {

        if (bodyPartToSet == BodypartInfo.BodyPart.Hands && (!hasHands || !isAdd) )
        {
            hasHands = isAdd;

            if (isAdd)
            {

                audioSource.PlayOneShot(soundRepo.gainBodyPart);

            }

            if (!isAdd)
            {
                equippedItem = ItemInfo.ItemType.None;
                DropEquippedItem();
            }

            return true;
        }

        if (bodyPartToSet == BodypartInfo.BodyPart.Legs && (!hasLegs || !isAdd) )
        {
            hasLegs = isAdd;

            if (isAdd)
            {

                audioSource.PlayOneShot(soundRepo.gainBodyPart);

            }

            return true;
        }

        if (bodyPartToSet == BodypartInfo.BodyPart.Chest && (!hasChest || !isAdd) )
        {
            hasChest = isAdd;

            if (isAdd)
            {
                BufferHealthModifier(chestHealth);
                audioSource.PlayOneShot(soundRepo.gainBodyPart);

            } else
            {
                BufferHealthModifier(-chestHealth);
            }
                
            return true;
        }

        if (bodyPartToSet == BodypartInfo.BodyPart.Head && (!hasHead || !isAdd))
        {
            hasHead = isAdd;

            if (isAdd)
            {

                equippedItem = ItemInfo.ItemType.None;

                audioSource.PlayOneShot(soundRepo.gainBodyPart);

                DropEquippedItem();

            }

            return true;
        }

        if (bodyPartToSet == BodypartInfo.BodyPart.Heart && (!hasHeart || !isAdd))
        {
            //If adding heart check if the player has all the other parts. If not, return false.
            if (isAdd)
            {

                if(!hasChest || !hasHands || !hasLegs || !hasHead)
                {

                    return false;

                }

            }

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


    public bool EquipItem(ItemInfo.ItemType item)
    {
        if (!hasHands || hasHead)
        {
            return false;
        }

        if (equippedItem == item)
        {

            return false;

        }
        else
        {
            equippedItem = item;
            DropEquippedItem();

            return true;
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
