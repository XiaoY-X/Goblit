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

    // Start is called before the first frame update
    void Start()
    {
        textosTutorial = new string[4];
        textosTutorial[0] = "Buenos días soldado,\n\nBienvenido a su nuevo puesto en la unidad de comunicaciones Hermes-42, su nueva tarea a partir de este mismo instante es recibir mensajes y enviarlos por el telégrafo al equipo de avanzadilla Panther-UPT...";
        textosTutorial[1] = "Este atento a mensajes enemigos soldado, si recibe alguno transmita solo \"arc\"...";
        textosTutorial[2] = "Una última cosa, el equipo no dispone de señalizadores de posición o bengalas...";
        textosTutorial[3] = "La vida de estos 20 soldados está en sus manos soldado, su misión es esencial para ganar la guerra. Cada error tendrá devastadoras consecuencias y el tiempo es crucial. ¡No nos defraude!\n\nGeneral Griveous";

        currentText = 0;

        try
        {
            tutorialText.text = textosTutorial[currentText];
        }
        catch (System.Exception)
        {
        }
        
    }

    // Update is called once per frame
    void Update()
    {


        
        
        if (Input.GetMouseButtonDown(0))
        {
            if (currentText == textosTutorial.Length - 1)
            {
                Destroy(gameObject);
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
