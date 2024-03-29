using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookControl : MonoBehaviour
{
    private bool bookIsCatch;
    private Vector2 bookOriginalPos;
    private Vector2 mouseOriginalPos;
    private Vector2 offset;
    public bool onTelegraph;

    public int current;
    public GameObject closeButton;
    //public AudioSource paperAudioSourse;

    private GameObject tutorial;
    private TutorialController tutorialControl;

    private void Start()
    {
        bookIsCatch = false;
        bookOriginalPos = transform.position;

        offset = new Vector2(0,0);
        onTelegraph = false;
        //paperAudioSourse = GetComponent<AudioSource>();


        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        current = 0;

        tutorial = GameObject.FindGameObjectWithTag("Tutorial");
        tutorialControl = tutorial.GetComponent<TutorialController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && tutorialControl.botonesDisponibles)
        {
            bookOriginalPos = transform.position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseOriginalPos = mousePos;
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            offset = bookOriginalPos - mousePos;

            if (hit.collider != null && hit.collider.gameObject.name == "Book")
                //Recordatorio, hacerlo comparando con tags
            {
                //paperAudioSourse.Play();
                bookIsCatch = true;
            }
        }

        if (bookIsCatch)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos + offset;

            if (Input.GetMouseButtonUp(0) && tutorialControl.botonesDisponibles)
            {
                bookIsCatch = false;
                if (mouseOriginalPos == mousePos) // Click
                {
                    transform.GetChild(current).gameObject.SetActive(true);
                    closeButton.SetActive(true);
                    
                }
                else // End of Drag
                {
                    if (onTelegraph)
                    {
                        transform.position = bookOriginalPos;
                    }
                    //paperAudioSourse.Play();
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

    public int getCurrent()
    {
        return current;
    }

    public void incCurrent()
    {
        current = (current + 1) % (transform.childCount - 1);
    }
}
