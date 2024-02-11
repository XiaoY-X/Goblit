using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaperControl : MonoBehaviour
{
    private bool paperIsCatch;
    private Vector2 paperOriginalPos;
    private Vector2 offset;
    private bool onTelegraph;
    public AudioSource paperAudioSourse;
    public TextMeshProUGUI textoGUI1;
    public TextMeshProUGUI textoGUI2;
    public string texto1;
    public string texto2;
    public string solucion;

    private void Start()
    {
        paperIsCatch = false;
        paperOriginalPos = transform.position;
        onTelegraph = false;
        paperAudioSourse = GetComponent<AudioSource>();
        textoGUI1.text = texto1;
        textoGUI2.text = texto2;


        
    }
    private void Update()
    {
        // Para testing solo
        GameObject.Find("Button").GetComponent<ButtonControl>().currentSolution = solucion;


        if (Input.GetMouseButtonDown(0))
        {
            paperOriginalPos = transform.position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            offset = paperOriginalPos - mousePos;

            if (hit.collider != null && hit.collider.gameObject.tag == "Paper")
                //Recordatorio, hacerlo comparando con tags
            {
                paperAudioSourse.Play();
                paperIsCatch = true;
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        if (paperIsCatch)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos + offset;
            if (Input.GetMouseButtonUp(0))
            {
                paperAudioSourse.Play();
                paperIsCatch = false;
                transform.GetChild(0).gameObject.SetActive(false);
                if (onTelegraph)
                {
                    transform.position = paperOriginalPos;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Telegraph")
        {
            onTelegraph = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Telegraph")
        {
            onTelegraph = false;
        }
    }
}
