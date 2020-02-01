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
    private BodyState bodyState;

    private void Start()
    {
        bodyState = new BodyState();
        RepaintBody();
    }

    private void Update()
    {
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
            bodyState.hasHeart != characterInfo.hasHeart;
        }
    }

    private void UpdateBodyState() {
        bodyState.hasHead = characterInfo.hasHead;
        bodyState.hasHands = characterInfo.hasHands;
        bodyState.hasChest = characterInfo.hasChest;
        bodyState.hasLegs = characterInfo.hasLegs;
        bodyState.hasHeart = characterInfo.hasHeart;
    }

    private void RepaintBody() {
        UpdateBodyState();
        foreach (var bodyPart in FindObjectsOfType<CharacterBodyDisplayer>()) {
            bodyPart.UpdateAccrodingTo(bodyState);
        }
    }

    private void RepaintBodyFromDebugState()
    {
        foreach (var bodyPart in FindObjectsOfType<CharacterBodyDisplayer>())
        {
            bodyPart.UpdateAccrodingTo(debugger.debugState);
        }
    }
}
