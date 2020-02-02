using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDrawer : MonoBehaviour
{
    [System.Serializable]
    public class BodyState {
        public bool hasLegs;
        public bool hasHands;
        public bool hasHead;
        public bool hasHeart;
        public bool hasChest;
        public bool hasGun;
        public bool hasSword;

        public bool isFullBodyOn {
            get {
                return  hasHead &&
                        hasHands &&
                        hasChest &&
                        hasLegs &&
                        hasHeart;
            }
        }
    }

    [System.Serializable]
    public class Debugger {
        public bool isDebugOn = false;
        public BodyState debugState = new BodyState();
    }

    [SerializeField]
    Debugger debugger;

    [SerializeField]
    private CharacterInfo characterInfo;
    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private SpriteRenderer goastBodyRenderer;
    [SerializeField]
    private SpriteRenderer humanRenderer;
    [SerializeField]
    Color goastHiddenColor;


    private BodyState bodyState;

    private void Start()
    {
        bodyState = new BodyState();
        RepaintBody();
    }

    private void Update()
    {
        UpdateCharacterFacingDirection();

        if (debugger.isDebugOn) {
            RepaintBodyFromDebugState();
        }
        else if (isBodyStateChanged) {
            RepaintBody();
        }
    }

    private bool isBodyStateChanged {
        get {
            return bodyState.hasHead != characterInfo.hasHead ||
            bodyState.hasHands != characterInfo.hasHands ||
            bodyState.hasChest != characterInfo.hasChest ||
            bodyState.hasLegs != characterInfo.hasLegs ||
            bodyState.hasHeart != characterInfo.hasHeart ||
            bodyState.hasGun != (characterInfo.equippedItem== ItemInfo.ItemType.Gun)||
            bodyState.hasSword != (characterInfo.equippedItem == ItemInfo.ItemType.Sword);
        }
    }

    private bool isAnyBodyPart {
        get {
            return bodyState.hasHead ||
            bodyState.hasHands ||
            bodyState.hasChest ||
            bodyState.hasLegs ||
            bodyState.hasHeart;
        }
    }

    private void UpdateBodyState() {
        bodyState.hasHead = characterInfo.hasHead;
        bodyState.hasHands = characterInfo.hasHands;
        bodyState.hasChest = characterInfo.hasChest;
        bodyState.hasLegs = characterInfo.hasLegs;
        bodyState.hasHeart = characterInfo.hasHeart;
        bodyState.hasGun = (characterInfo.equippedItem == ItemInfo.ItemType.Gun);
        bodyState.hasSword = (characterInfo.equippedItem == ItemInfo.ItemType.Sword);

    }

    private void RepaintBody() {
        // paint body part
        UpdateBodyState();
        foreach (var bodyPart in GetComponentsInChildren<CharacterBodyDisplayer>()) {
            bodyPart.UpdateAccrodingTo(bodyState);
        }

        // adjust goast alpha
        if (isAnyBodyPart)
        {
            goastBodyRenderer.color = goastHiddenColor;
        }
        else {
            goastBodyRenderer.color = Color.white;
        }

        BecomeHumanCheck();
    }

    private void UpdateCharacterFacingDirection() {
        if (characterController.facingLeft)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void RepaintBodyFromDebugState()
    {
        foreach (var bodyPart in GetComponentsInChildren<CharacterBodyDisplayer>())
        {
            bodyPart.UpdateAccrodingTo(debugger.debugState);
        }
    }

    private void BecomeHumanCheck() {
        var isFullBody =  bodyState.hasHead &&
            bodyState.hasHands &&
            bodyState.hasChest &&
            bodyState.hasLegs &&
            bodyState.hasHeart;

        if (isFullBody)
            humanRenderer.enabled = true;
        else
            humanRenderer.enabled = false;
    }
}
