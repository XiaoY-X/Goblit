using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class ButtonControl : MonoBehaviour
{
    public TextMeshProUGUI morseCode;
    public TextMeshProUGUI traduccion;

    float holdTime = 0.2f;
    float spaceWaitTime = 2.5f;

    private int wordSeparator;
    private float timePress;
    private float timeBetweenPress;
    private int nLetters;
    private bool telegraphOn;
    private bool pushButton;
    private string morseAux;
    private string totalText;
    private float cursorInd = 0;
    public float timeCursorFlicker;

    public string currentSolution;
    void Start()
    {
        timePress = 0;
        timeBetweenPress = 0;
        nLetters = 0;
        telegraphOn = false;
        pushButton = false;
        morseAux = "";
        totalText = "";

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Button");
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0, layerMask);

            if (hit.collider != null && hit.collider.gameObject.name == "Button")
            {
                pushButton = true;
                telegraphOn = true;
            }// Recordatorio: comparar con tags

            
        }
        
        if ((Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space)) && pushButton)
        {
            timePress += Time.deltaTime;
        }

        if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space)) && pushButton)
        {
            //Debug.Log("press: " + timePress);
            if (timePress > holdTime)
            {
                morseAux = morseCode.text;
                morseAux += "-";
                totalText += "-";
                morseCode.text = morseAux;
                wordSeparator = 0;
            }
            else
            {
                morseAux = morseCode.text;
                morseAux += ".";
                totalText += ".";
                morseCode.text = morseAux;
                wordSeparator = 0;
            }
            timePress = 0;
            timeBetweenPress = 0;
            nLetters++;
            pushButton = false;
        }

        //Debug.Log(nLetters);
        if (nLetters == 11)
        {
            StringBuilder sb = new StringBuilder(morseCode.text);
            sb.Remove(0, 1);
            morseCode.text = sb.ToString();
            nLetters = 10;
        }

        if (telegraphOn) 
        {
            timeBetweenPress += Time.deltaTime;
            if (timeBetweenPress > spaceWaitTime && wordSeparator < 2 && !Input.GetMouseButton(0)) 
            {
                morseCode.text += "/";
                totalText += "/";

                timePress = 0;
                timeBetweenPress = 0;
                nLetters++;
                wordSeparator++;
            }
        }// Habra que poner telegraphOn en false cuando termine con la ultima letra del paper

        string aux = Traductor.translate(totalText);
        if (aux == "") totalText = "";
        traduccion.text = aux;
        if (aux.EndsWith(" "))
        {
            traduccion.text = traduccion.text.Remove(aux.Length - 1);

            if (cursorInd > timeCursorFlicker * 2)
            {
                cursorInd = 0;
            }
            else if (cursorInd < timeCursorFlicker)
            {
                traduccion.text += "|";
            }
            /*
            else if (cursorInd < timeCursorFlicker * 2)
            {
                //print("No barra");
            }
            */
            cursorInd += Time.deltaTime;


        }

        if (aux.EndsWith(" arc "))
        {
            print("Fin de la transmision");

            if (aux == currentSolution + " arc ")
            {
                print("Solucion correcta");




            }


            
            




        }

    }
}
