using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    private string[] textosTutorial;
    private int currentText;
    public TextMeshProUGUI tutorialText;
    public Boolean botonesDisponibles;

    // Start is called before the first frame update
    void Start()
    {
        textosTutorial = new string[4];
        textosTutorial[0] = "Buenos días soldado,\n\nBienvenido a su nuevo puesto en la unidad de comunicaciones Hermes-42, " +
            "su nueva tarea a partir de este mismo instante es recibir mensajes y enviarlos por el telégrafo al equipo de avanzadilla " +
            "Panther-UPT...";
        textosTutorial[1] = "Le hemos dejado una nota en el escritorio donde iremos actualizando su deber, y también se le ha" +
            "proporcionado un libro con instrucciones básicas de protocolo...";
        textosTutorial[2] = "Este atento a mensajes enemigos soldado, si recibe alguno, transmita solo \"arc\".\n" +
            "Una última cosa, el equipo no dispone de señalizadores de posición o bengalas...";
        textosTutorial[3] = "La vida de estos 20 soldados dependen de un solo botón, su misión es esencial para ganar la guerra. " +
            "Cada error tendrá devastadoras consecuencias y el tiempo es crucial. ¡No nos defraude!\n\nGeneral Griveous";

        currentText = 0;

        try
        {
            tutorialText.text = textosTutorial[currentText];
        }
        catch (System.Exception)
        {
        }
        
        botonesDisponibles = false;
    }

    // Update is called once per frame
    void Update()
    {


        
        
        if (Input.GetMouseButtonDown(0))
        {


            if (currentText == textosTutorial.Length - 1)
            {
                GameObject tele = GameObject.FindGameObjectWithTag("Telegraph");
                TelegraphControl teleControl = tele.GetComponent<TelegraphControl>();
                teleControl.empiezaJuego = true;
                botonesDisponibles = true;



                GetComponent<Renderer>().enabled = false;
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                //Destroy(gameObject);
            }
            else
            {
                currentText++;
                try
                {
                    tutorialText.text = textosTutorial[currentText];
                }
                catch (System.Exception)
                {
                }
                 
            }


        }




    }
}
