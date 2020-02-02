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

    LineRenderer line;
    AudioSource audioSource;
    SoundRepo soundRepo;

    // Start is called before the first frame update
    void Start()
    {

        line = this.gameObject.GetComponent<LineRenderer>();

        line.enabled = false;

        audioSource = this.gameObject.GetComponent<AudioSource>();
        soundRepo = GameObject.FindObjectOfType<SoundRepo>();
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

        audioSource.PlayOneShot(soundRepo.swordPress);

        LayerMask playerMask = LayerMask.GetMask("player");

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, swordRange, playerMask);

        if(hit.collider != null)
        {

            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("sword hit : " + hit.collider.gameObject.name);

                hit.collider.gameObject.GetComponent<CharacterInfo>().LoseRandomBodyPart();

                swordCD = true;
                StartCoroutine(WeaponCD_CR(ItemInfo.ItemType.Sword));

            }

        }

    }

    void UseGun(Vector2 origin, Vector2 direction)
    {
        audioSource.PlayOneShot(soundRepo.gunPress);

        LayerMask playerMask = LayerMask.GetMask("player");

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, gunRange, playerMask);

        if (hit.collider != null)
        {

            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("gun hit : " + hit.collider.gameObject.name);

                Rigidbody2D otherRb2D = hit.collider.gameObject.GetComponent<Rigidbody2D>();

                otherRb2D.AddForce(direction * gunKnockbackImpulse, ForceMode2D.Force);

                gunCD = true;
                StartCoroutine(WeaponCD_CR(ItemInfo.ItemType.Gun));

                DrawBulletPath(origin, hit.point);

            }

        } else
        {

            DrawBulletPath(origin, direction * 100);

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


    void DrawBulletPath(Vector2 startPos, Vector2 endPos)
    {
        line.enabled = true;

        Vector3 pos1 = new Vector3(startPos.x, startPos.y, 0);
        Vector3 pos2 = new Vector3(endPos.x, endPos.y, 0);

        line.SetPosition(0, pos1);
        line.SetPosition(1, pos2);

        StartCoroutine(LineDissapear());

    }

    IEnumerator LineDissapear()
    {

        yield return new WaitForSeconds(0.1f);

        line.enabled = false;

    }

}
