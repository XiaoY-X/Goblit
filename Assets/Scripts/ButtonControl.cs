using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class ButtonControl : MonoBehaviour
{
    public TextMeshProUGUI morseCode;
    private float timePress;
    private float timeBetweenPress;
    private int nLetters;
    private bool telegraphOn;
    private bool pushButton;
    private string morseAux;
    void Start()
    {
        timePress = 0;
        timeBetweenPress = 0;
        nLetters = 0;
        telegraphOn = false;
        pushButton = false;
        morseAux = "";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

        if (Input.GetMouseButton(0) && pushButton)
        {
            timePress += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0) && pushButton)
        {
            //Debug.Log("press: " + timePress);
            if (timePress > 1)
            {
                morseAux = morseCode.text;
                morseAux += "-";
                morseCode.text = morseAux;
            }
            else
            {
                morseAux = morseCode.text;
                morseAux += ".";
                morseCode.text = morseAux;
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
            if (timeBetweenPress > 8) 
            {
                morseCode.text += "/";
                timePress = 0;
                timeBetweenPress = 0;
                nLetters++;
            }
        }// Habra que poner telegraphOn en false cuando termine con la ultima letra del paper
    }
}
