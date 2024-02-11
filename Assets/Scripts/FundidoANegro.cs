using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class FundidoANegro : MonoBehaviour
{
    public Boolean gameEnded;
    public TextMeshProUGUI titulo;
    public TextMeshProUGUI texto;
    public int soldados;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        gameEnded = false;
        soldados = 20;
        timer = 0.0f;





    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
           {
            AudioListener.pause = true;
            AudioListener.volume = 0;

            // TODO: Eliminar objetos

            /*
            foreach (UnityEngine.Object go in GameObject.FindObjectsByType(typeof(MonoBehaviour), FindObjectsSortMode.None))
            {
                print("dd");
                if (go != this && go.name != "Camera" && go.name != "EventSystem")
                {
                    print(go.name);
                    Destroy(go);
                }
            }
            */

            if (soldados > 0)
            {
                titulo.text = "¡Victoria!";
                texto.text = "Tras esta dura batalla, " + soldados + " soldados vuelven a casa gracias a tu servicio.";
            }
            else
            {
                titulo.text = "¡Derrota!";
                texto.text = "El pelotón ha sido aniquilado.";
            }

            timer += Time.deltaTime;
            if (timer > 20.0f)
            {
                SceneManager.LoadScene("Start");


            }



        }

    }
}
