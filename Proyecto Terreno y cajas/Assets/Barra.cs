using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra : MonoBehaviour
{
    private Image Vida;
    public float vidaactual;
    public float vidamaxima;
    Player player;
     
    public void Start()
    {
        Vida = GetComponent<Image>();
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        vidaactual = player.vida;
        Vida.fillAmount = vidaactual / vidamaxima;
    }
}
