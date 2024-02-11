using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelegraphControl : MonoBehaviour
{
    private bool success;
    GameObject button;
    ButtonControl buttonControl;
    GameObject gestor;
    GestorControl gestorControl;
    void Start()
    {
        success = false;
        button = GameObject.Find("Button");
        buttonControl = button.GetComponent<ButtonControl>();
        gestor = GameObject.Find("Gestor");
        gestorControl = gestor.GetComponent<GestorControl>();
    }

    void Update()
    {
        GameObject paper = GameObject.FindGameObjectWithTag("Paper");
        PaperControl paperControl = paper.GetComponent<PaperControl>();
        if (buttonControl.traduccion.text == paperControl.solucion || paperControl.solucion == null) 
        {
            success = true;
        }
        gestorControl.changePaper = true;
        if (gestorControl.changePaper) 
        {
            switch (gestorControl.counterMission)
            {
                case 1:
                    if (success)
                    {
                        //Mensaje de Exito
                    }
                    else
                    {
                        //Mensaje de Fallo
                    }
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:

                    break;
                default:

                    break;
            }
        }
        success = false;
    }
}
