using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    private string[] textosTutorial;
    private int currentText;
    public TextMeshProUGUI tutorialText;

    // Start is called before the first frame update
    void Start()
    {
        textosTutorial = new string[3];
        textosTutorial[0] = "Texto 1";
        textosTutorial[1] = "Texto 2";
        textosTutorial[2] = "Texto 3";

        currentText = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        tutorialText.text = "adas"; //textosTutorial[currentText];

        if (Input.GetMouseButtonDown(0))
        {
            print("click");
            if (currentText == textosTutorial.Length - 1)
            {
                Destroy(gameObject);
            }
            else
            {
                currentText++;
                tutorialText.text = textosTutorial[currentText];    
            }


        }




    }
}
