using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GestorControl : MonoBehaviour
{
    public GameObject paperPrefab;
    private GameObject paper;
    public bool changePaper;
    public int counterMission;

    private void Start()
    {
        changePaper = false;
        counterMission = 0;
    }

    private void Update()
    {
        if (changePaper)
        {
            newPaper();
        }
    }

    private void newPaper()
    {
        GameObject oldPaper = GameObject.FindGameObjectWithTag("Paper");
        if (oldPaper != null)
        {
            Destroy(oldPaper);
        }
        paper = Instantiate(paperPrefab);
        counterMission++;
        PaperControl paperControl = paper.GetComponent<PaperControl>();
        if (paperControl != null) 
        {
            switch (counterMission)
            {
                // No se si empezar en uno o no, se supone que uno es el primero, y depende de que este primero la creamos con este gestor o no
                // Si suponemos que el primero no hace falta crear, ya este en la escena, pues hay que empezar en dos, o poner el segundo mision
                // del documento en case 1
                case 1:
                    //No se que son text1 y text2, pero supongo que uno de los texts es la mision recibida y la otra solucion es la solucion
                    paperControl.texto1 = "";
                    paperControl.solucion = "";
                    break;
                case 2:
                    paperControl.texto1 = "";
                    paperControl.solucion = "";
                    break;
                case 3:
                    paperControl.texto1 = "";
                    paperControl.solucion = "";
                    break;
                case 4:
                    paperControl.texto1 = "";
                    paperControl.solucion = "";
                    break;
                case 5:
                    paperControl.texto1 = "";
                    paperControl.solucion = "";
                    break;
                case 6:
                    paperControl.texto1 = "";
                    paperControl.solucion = "";
                    break;
                case 7:
                    paperControl.texto1 = "";
                    paperControl.solucion = "";
                    break;
                default:
                    paperControl.texto1 = "";
                    paperControl.solucion = "";
                    break;
            }
        }
        changePaper = false;
    }
}
