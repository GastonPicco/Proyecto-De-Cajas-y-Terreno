using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{

    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, boxconteiner, fpscam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equip;
    public static bool fullhands;

    void Start()
    {
        if (!equip)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equip)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            fullhands = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equip && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !fullhands) PickUp();
        if (equip && Input.GetKeyDown(KeyCode.Q)) Drop();
        if (equip && transform.localPosition.y < 0.50)
        {
            transform.Translate(0, 2f*Time.deltaTime, 0);
        }
        if (equip && transform.localPosition.y < 0.65 && transform.localPosition.y > 0.50)
        {
            transform.Translate(0, 0.8f * Time.deltaTime, 0);
        }
    }
    private void PickUp()
    {
        transform.SetParent(boxconteiner);
        
        transform.localPosition = Vector3.zero;
        

        transform.localRotation = Quaternion.Euler(Vector3.zero);



        equip = true;
        fullhands = true;

        rb.isKinematic = true;
        coll.isTrigger = true;
    }
    private void Drop()
    {
        transform.SetParent(null);


        equip = false;
        fullhands = false;

        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;
        rb.AddForce(fpscam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpscam.up * dropUpwardForce, ForceMode.Impulse);
    }
}
