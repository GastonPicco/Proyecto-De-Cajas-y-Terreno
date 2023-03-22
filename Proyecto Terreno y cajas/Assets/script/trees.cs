using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trees : MonoBehaviour
{
    public Rigidbody rb;
    public bool falled;
    public float speed;
    public bool falling;
    public bool neverFalled;
    // Start is called before the first frame update
    void Start()
    {
        rb.isKinematic = true;
        falled = false;
        neverFalled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!neverFalled)
        {
            if (speed > 0.1f)
            {
                falling = true;
            }
            if (falled)
            {
                speed = rb.velocity.magnitude;
               // Debug.Log(speed);
            }
            if (falling && speed <= 0.1)
            {
                falled = false;
                falling = false;
                neverFalled = true;
            }
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Fall();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && falling)
        {
            Hit();
        }
    }
    private void Fall()
    {
        rb.isKinematic = false;
        falled = true;
    }
    private void Hit()
    {
        Debug.Log("Hit!!");
        GameEvents.current.DamageEvent.Invoke();
    }
    
}
