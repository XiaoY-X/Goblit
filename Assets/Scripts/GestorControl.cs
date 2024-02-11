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
    public string texto1;

    private void Start()
    {
        changePaper = false;
        counterMission = 1;
        NewPaper();
        texto1 = "";


    }

    private void Update()
    {
        if (changePaper)
        {
            changePaper = false;
            counterMission++;
            NewPaper();
        }
    }

    private void NewPaper()
    {
        GameObject oldPaper = GameObject.FindGameObjectWithTag("Paper");
        if (oldPaper != null)
        {
            Destroy(oldPaper);
        }
        paper = Instantiate(paperPrefab);
        if (oldPaper != null)
        {
            paper.transform.position = oldPaper.transform.position;
        }
        PaperControl paperControl = paper.GetComponent<PaperControl>();
        if (paperControl != null) 
        {
            paperControl.texto1 = texto1;
            switch (counterMission)
            {
                // No se si empezar en uno o no, se supone que uno es el primero, y depende de que este primero la creamos con este gestor o no
                // Si suponemos que el primero no hace falta crear, ya este en la escena, pues hay que empezar en dos, o poner el segundo mision
                // del documento en case 1
                case 1:
                    //No se que son text1 y text2, pero supongo que uno de los texts es la mision recibida y la otra solucion es la solucion
                    paperControl.texto2 = "Misión 1:\nComenzamos el asalto\n\nMensaje a transcribir:\n\"Luz verde\"";
                    paperControl.solucion = "luz verde";
                    break;
                case 2:
                    paperControl.texto2 = "Misión 2:\nVienen soldados enemigos por el norte\n\nMensaje a transcribir:\n\"Avanzar S\"";
                    paperControl.solucion = "avanzar s";
                    break;
                case 3:
                    paperControl.texto2 = "Misión 3:\nSe han avistado cazas enemigos sobrevolando la zona\n\nMensaje a transcribir:\n\"No avancen\"";
                    paperControl.solucion = "no avancen";
                    break;
                case 4:
                    paperControl.texto2 = "Misión 4:\nLa base enemiga se encuentra al norte\n\nMensaje a transcribir:\n\"Asaltar N\"";
                    paperControl.solucion = "asaltar n";
                    break;
                case 5:
                    paperControl.texto2 = "Misión 5:\nLos francotiradores enemigos están en posición\n\nMensaje a transcribir:\n\"A cubierto\"";
                    paperControl.solucion = "a cubierto";
                    break;
                case 6:
                    paperControl.texto2 = "Misión 6:\nViene la artilleria enemiga por el este\n\nMensaje a transcribir:\n\"Avanzar O\"";
                    paperControl.solucion = "avanzar o";
                    break;
                case 7: // Mensaje trampa
                    paperControl.texto2 = "Misión 7:\nUna fuerza hostil demasiado numerosa viene en el frente derecho, disparen la bengala para poder reorganizar el ataque\n\nMensaje a transcribir:\n\"Bengala\"";
                    paperControl.solucion = "bengala";
                    break;
                case 8:
                    paperControl.texto2 = "Misión 8:\nNos superan en número\n\nMensaje a transcribir:\n\"Retirada\"";
                    paperControl.solucion = "retirada";
                    break;
                case 9:
                    paperControl.texto2 = "Misión 9:\nLa base enemiga se encuentra al este\n\nMensaje a transcribir:\n\"Asaltar E\"";
                    paperControl.solucion = "asaltar e";
                    break;
                case 10:


                    
                    paperControl.texto2 = "Misión final:\nLa bandera del pelotón ha sido colocada en la base enemiga, la victoria es nuestra\n\nMensaje a transcribir:\n\"Victoria\"";
                    paperControl.solucion = "victoria";
                    break;
                default:
                    paperControl.texto2 = "";
                    paperControl.solucion = "";
                    break;
            }
        }
        
    }
}
