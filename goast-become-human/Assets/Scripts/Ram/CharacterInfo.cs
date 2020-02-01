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


    [SerializeField] float normalJumpForce;
    [SerializeField] float legsJumpForce;
    [SerializeField] float moveForce;
    [SerializeField] float maxSpeed;
    [SerializeField] float maxJumpSpeed;
    [SerializeField] float maxJumpKeypress;

    [SerializeField] string groundTag;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBodyPart( BodypartInfo.BodyPart bodyPartToSet, bool isAdd )
    {

        if(bodyPartToSet == BodypartInfo.BodyPart.Hands)
            hasHands = isAdd;

        if (bodyPartToSet == BodypartInfo.BodyPart.Legs)
            hasLegs = isAdd;

        if (bodyPartToSet == BodypartInfo.BodyPart.Chest)
            hasChest = isAdd;

        if (bodyPartToSet == BodypartInfo.BodyPart.Head)
            hasHead = isAdd;

        if (bodyPartToSet == BodypartInfo.BodyPart.Heart)
            hasHeart = isAdd;

    }

    public void LoseRandomBodyPart()
    {

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

    public string GetGroundTag()
    {

        return groundTag;

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
