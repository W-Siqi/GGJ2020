using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public enum ItemType { None, Sword, Gun};

    public ItemType thisItemType;

    BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {

        collider = this.gameObject.GetComponent<BoxCollider2D>();

        collider.enabled = false;

        StartCoroutine(ActivateCollider());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ActivateCollider()
    {

        yield return new WaitForSeconds(1.0f);

        collider.enabled = true;

    }


}
