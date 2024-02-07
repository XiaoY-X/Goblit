using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperControl : MonoBehaviour
{
    private bool paperIsCatch;
    private Vector2 paperOriginalPos;
    private bool onTelegraph;
    public AudioSource paperAudioSourse;

    private void Start()
    {
        paperIsCatch = false;
        paperOriginalPos = transform.position;
        onTelegraph = false;
        paperAudioSourse = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            paperOriginalPos = transform.position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.name == "Paper")
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
            transform.position = mousePos;
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
