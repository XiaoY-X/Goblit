using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonControl : MonoBehaviour
{
    public TextMeshProUGUI morseCode;
    private float time;
    private int nLetters;
    private bool telegraphOn;
    void Start()
    {
        time = 0;
        nLetters = 0;
        telegraphOn = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider.gameObject.name == "Button")
            {
                Debug.Log("hit");
                telegraphOn = true;

                if (Input.GetMouseButtonUp(0) && time < 2)
                {
                    morseCode.text += ".";
                    time = 0;
                    nLetters++;
                }

                if (Input.GetMouseButtonUp(0) && time > 2)
                {
                    morseCode.text += "-";
                    time = 0;
                    nLetters++;
                }
            }
        }

        if (telegraphOn) 
        {
            time++;
            if (time > 7) 
            {
                morseCode.text += "/";
                time = 0;
                nLetters++;
            }
        }// Habra que poner telegraphOn en false cuando termine con la ultima letra

        if (nLetters == 9) 
        {
            morseCode.text = morseCode.text.Substring(1);
        }
    }
}
