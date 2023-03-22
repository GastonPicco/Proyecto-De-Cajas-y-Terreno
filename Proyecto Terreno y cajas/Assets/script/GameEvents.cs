using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        if (current != null && current != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            current = this;
        }
     
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("salir");
            SceneManager.LoadScene("menujuego");
        }
    }

    public UnityEvent DamageEvent = new UnityEvent();
}
