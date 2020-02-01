using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] float gunKnockbackImpulse;

    [SerializeField] float swordRange;
    [SerializeField] float gunRange;

    [SerializeField] float swordCDTime;
    [SerializeField] float gunCDTime;

    [SerializeField] bool swordCD;
    [SerializeField] bool gunCD;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseWeapon(ItemInfo.ItemType item, Vector2 origin, Vector2 direction)
    {

        if (item == ItemInfo.ItemType.Sword && !swordCD)
            UseSword(origin, direction);

        if (item == ItemInfo.ItemType.Gun && !gunCD)
            UseGun(origin, direction);

    }

    void UseSword(Vector2 origin, Vector2 direction)
    {

        LayerMask playerMask = LayerMask.GetMask("light layer");

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, swordRange, playerMask);

        if(hit.collider != null)
        {

            if (hit.collider.gameObject.CompareTag("Player"))
            {

                hit.collider.gameObject.GetComponent<CharacterInfo>().LoseRandomBodyPart();

                swordCD = true;
                StartCoroutine(WeaponCD_CR(ItemInfo.ItemType.Sword));

            }

        }

    }

    void UseGun(Vector2 origin, Vector2 direction)
    {
        LayerMask playerMask = LayerMask.GetMask("light layer");

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, gunRange, playerMask);

        if (hit.collider != null)
        {

            if (hit.collider.gameObject.CompareTag("Player"))
            {

                Rigidbody2D otherRb2D = hit.collider.gameObject.GetComponent<Rigidbody2D>();

                otherRb2D.AddForce(direction * gunKnockbackImpulse, ForceMode2D.Impulse);

                gunCD = true;
                StartCoroutine(WeaponCD_CR(ItemInfo.ItemType.Gun));

            }

        }

    }

    IEnumerator WeaponCD_CR(ItemInfo.ItemType item)
    {

        if(item == ItemInfo.ItemType.Sword)
        {

            yield return new WaitForSeconds(swordCDTime);

            swordCD = false;

        } 

        if(item == ItemInfo.ItemType.Gun)
        {

            yield return new WaitForSeconds(gunCDTime);

            gunCD = false;

        }

        yield return null;

    }


}
