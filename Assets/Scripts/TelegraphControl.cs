using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
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

    public Boolean solucionCorrecta;
    public int hombres;
    public GameObject negro;
    public Boolean empiezaJuego;

    private GameObject tutorial;
    private TutorialController tutorialControl;
    void Start()
    {
        success = false;
        button = GameObject.Find("Button");
        buttonControl = button.GetComponent<ButtonControl>();
        gestor = GameObject.Find("Gestor");
        gestorControl = gestor.GetComponent<GestorControl>();

        
        reloj.volume = 0.0f;
        missionTime = 0.0f;
        oneSecond = 0.0f;
        solucionCorrecta = false;
        hombres = 20;
        negro.SetActive(false);
        empiezaJuego = false;

        tutorial = GameObject.FindGameObjectWithTag("Tutorial");
        tutorialControl = tutorial.GetComponent<TutorialController>();
    }

    void Update()
    {
        missionTime += Time.deltaTime;
        oneSecond += Time.deltaTime;

        if (empiezaJuego)
        {
            reloj.Play();
            reloj.volume = 0.0f;
            missionTime = 0.0f;
            empiezaJuego = false;
        }

        if (oneSecond > 1)
        {
            // print("One second has passed (volume " + reloj.volume + ")");
            reloj.volume += 0.01f;
            oneSecond = 0.0f;
        }

        GameObject paper = GameObject.FindGameObjectWithTag("Paper");
        PaperControl paperControl = paper.GetComponent<PaperControl>();

        // solucionCorrecta es para cheat
        if (Traductor.translate(buttonControl.totalText).Trim() == paperControl.solucion + " arc" || solucionCorrecta)  // || paperControl.solucion == null
        {
            success = true;
            gestorControl.changePaper = true;
            buttonControl.totalText = "";
            reloj.Play();
            reloj.volume = 0.0f;
            missionTime = 0.0f;



            solucionCorrecta = false;
        }
        else if (Traductor.translate(buttonControl.totalText).Trim().EndsWith("arc") || missionTime > 100) // Fallas la mision 
        {
            success = false;
            gestorControl.changePaper = true;
            buttonControl.totalText = "";
            reloj.Play();
            reloj.volume = 0.0f;
            missionTime = 0.0f;
        }
        
        if (gestorControl.changePaper)
        {
            switch (gestorControl.counterMission)
            {
                case 1:
                    if (success)
                    {
                        gestorControl.texto1 = "Reporte previo:\nConexión exitosa";
                    }
                    else
                    {
                        gestorControl.texto1 = "Reporte previo:\nError en la conexión";
                        hombres -= 0;
                    }
                    break;
                case 2:
                    if (success)
                    {
                        gestorControl.texto1 = "Reporte previo:\nAvance realizado con éxito";
                    }
                    else
                    {
                        gestorControl.texto1 = "Reporte previo:\nHemos perdido 3 hombres";
                        hombres -= 3;
                    }
                    break;
                case 3:
                    if (success)
                    {
                        gestorControl.texto1 = "Reporte previo:\nLos cazas no han detectado a la fuerza de ataque aliada";
                    }
                    else
                    {
                        gestorControl.texto1 = "Reporte previo:\nHemos perdido 8 hombres";
                        hombres -= 8;
                    }
                    break;
                case 4:
                    if (success)
                    {
                        gestorControl.texto1 = "Reporte previo:\nAsalto realizado con éxito";
                    }
                    else
                    {
                        gestorControl.texto1 = "Reporte previo:\nHemos perdido 6 hombres";
                        hombres -= 6;
                    }
                    break;
                case 5:
                    if (success)
                    {
                        gestorControl.texto1 = "Reporte previo:\nHemos conseguido despistar a los francotiradores";
                    }
                    else
                    {
                        gestorControl.texto1 = "Reporte previo:\nHemos perdido 4 hombres";
                        hombres -= 4;
                    }
                    break;
                case 6:
                    if (success)
                    {
                        gestorControl.texto1 = "Reporte previo:\nAvance realizado con éxito";
                    }
                    else
                    {
                        gestorControl.texto1 = "Reporte previo:\nHemos perdido 3 hombres";
                        hombres -= 3;
                    }
                    break;
                case 7: // Trampa
                    if (success)
                    {
                        gestorControl.texto1 = "Reporte previo:\nEra una trampa enemiga, hemos perdido 10 hombres";
                        hombres -= 10;
                    }
                    else
                    {
                        gestorControl.texto1 = "Reporte previo:\nTrampa detectada con éxito";
                    }
                    break;
                case 8:
                    if (success)
                    {
                        gestorControl.texto1 = "Reporte previo:\nLas tropas están a salvo";
                    }
                    else
                    {
                        gestorControl.texto1 = "Reporte previo:\nHemos perdido 3 hombres";
                        hombres -= 3;
                    }
                    break;
                case 9:
                    if (success)
                    {
                        gestorControl.texto1 = "Reporte previo:\nAsalto realizado con éxito";
                    }
                    else
                    {
                        gestorControl.texto1 = "Reporte previo:\nHemos perdido 4 hombres";
                        hombres -= 4;
                    }
                    break;
                case 10:

                    negro.SetActive(true);
                    negro.GetComponent<FundidoANegro>().gameEnded = true;
                    negro.GetComponent<FundidoANegro>().soldados = hombres;

                    tutorialControl.botonesDisponibles = true;
                    break;
                default:

                    break;
            }
        }
        success = false;
    }
}
