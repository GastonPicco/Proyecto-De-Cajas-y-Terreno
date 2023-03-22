using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float vida = 100;
    public float daño = 40;
    public float timer;
    public GameObject prefab;

    private void OnEnable()
    {
        GameEvents.current.DamageEvent.AddListener(Damage);
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (vida <= 0)
        {
            timer += Time.deltaTime;
            Instantiate(prefab, transform.position, Quaternion.identity);

            if(timer > 1)
            {
                SceneManager.LoadScene("menujuego");
            }
            
        }
    }
    private void Damage()
    {
        Debug.Log("golpe");
        vida -= daño;
    }
}
