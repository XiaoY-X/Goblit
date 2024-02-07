using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookControl : MonoBehaviour
{
    private bool bookIsCatch;
    private Vector2 bookOriginalPos;
    private Vector2 mouseOriginalPos;
    private Vector2 mouseBookDiff;
    private bool onTelegraph;

    public int current;

    //public AudioSource paperAudioSourse;

    private void Start()
    {
        bookIsCatch = false;
        bookOriginalPos = transform.position;

        mouseBookDiff.x = mouseBookDiff.y = 0;
        onTelegraph = false;
        //paperAudioSourse = GetComponent<AudioSource>();


        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        current = 0;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bookOriginalPos = transform.position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseOriginalPos = mousePos;
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            mouseBookDiff = bookOriginalPos - mousePos;

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
            transform.position = mousePos + mouseBookDiff;

            if (Input.GetMouseButtonUp(0))
            {
                bookIsCatch = false;
                if (mouseOriginalPos == mousePos) // Click
                {
                    print("CLICK");

                    transform.GetChild(current).gameObject.SetActive(true);
                }
                else // End of Drag
                {
                    print("END OF DRAG");

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
        current = (current + 1) % transform.childCount;
    }
}
