using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class meta : MonoBehaviour
{
    bool caja1,caja2,caja3;
    public float timer;
    public GameObject prefab;
    public bool turnontimer;
    // Start is called before the first frame update
    void Start()
    {
        caja1 = false;
        caja2 = false;
        caja3 = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (turnontimer)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 1)
        {
            Debug.Log("win");
            SceneManager.LoadScene("win");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "caja1")
        {
            Debug.Log("la caja1 esta en el lugar");
            caja1 = true;
            comprobar();
        }
        if (other.gameObject.tag == "caja2")
        {
            Debug.Log("la caja2 esta en el lugar");
            caja2 = true;
            comprobar();
        }
        if (other.gameObject.tag == "caja3")
        {
            Debug.Log("la caja3 esta en el lugar");
            caja3 = true;
            comprobar();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "caja1")
        {
            Debug.Log("la caja1 ya no esta en el lugar");
            caja1 = false;
        }
        if (other.gameObject.tag == "caja2")
        {
            Debug.Log("la caja2 ya no esta en el lugar");
            caja2 = false;
        }
        if (other.gameObject.tag == "caja3")
        {
            Debug.Log("la caja3 ya no esta en el lugar");
            caja3 = false;
        }

    }
    public void comprobar()
    {
        if(caja1 && caja2 && caja3)
        {
            Debug.Log("todas las cajas estan en el lugar");
            turnontimer = true;
            
            Instantiate(prefab, transform.position, Quaternion.identity);
            



        }
        else
        {
            Debug.Log("todavia faltan cajas");
        }
    }

}
