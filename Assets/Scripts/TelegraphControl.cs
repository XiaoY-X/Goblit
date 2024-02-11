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
    public AudioSource reloj;
    public float missionTime;
    public float oneSecond;
    void Start()
    {
        success = false;
        button = GameObject.Find("Button");
        buttonControl = button.GetComponent<ButtonControl>();
        gestor = GameObject.Find("Gestor");
        gestorControl = gestor.GetComponent<GestorControl>();

        reloj.Play();
        reloj.volume = 0.0f;
        missionTime = 0.0f;
        oneSecond = 0.0f;
    }

    void Update()
    {
        missionTime += Time.deltaTime;
        oneSecond += Time.deltaTime;

        if (oneSecond > 1)
        {
            // print("One second has passed (volume " + reloj.volume + ")");
            reloj.volume += 0.01f;
            oneSecond = 0.0f;
        }

        GameObject paper = GameObject.FindGameObjectWithTag("Paper");
        PaperControl paperControl = paper.GetComponent<PaperControl>();

        if (Traductor.translate(buttonControl.totalText).Trim() == paperControl.solucion + " arc")  // || paperControl.solucion == null
        {
            success = true;
            gestorControl.changePaper = true;
            buttonControl.totalText = "";
            reloj.Play();
            reloj.volume = 0.0f;
            missionTime = 0.0f;
        }
        
        if (success)
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
