using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PageControl : MonoBehaviour
{
    //public AudioSource paperAudioSourse;
    private Boolean bookIsCatch;
    private Vector2 bookOriginalPos;
    private Vector2 mouseOriginalPos;
    private Vector2 offset;

    private void Start()
    {
        bookIsCatch = false;
        bookOriginalPos = transform.parent.transform.position;

        offset = new Vector2(0, 0);

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            bookOriginalPos = transform.parent.transform.position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseOriginalPos = mousePos;
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            offset = bookOriginalPos - mousePos;

            if (hit.collider != null && hit.collider.gameObject.name == "CloseButton") // Se clickea en "cerrar"
            {
                int currentPage = transform.GetComponentInParent<BookControl>().getCurrent();
                transform.parent.GetChild(currentPage).gameObject.SetActive(false);
                transform.parent.GetComponent<BookControl>().closeButton.SetActive(false);
            }
            else if (hit.collider != null && hit.collider.gameObject.tag == "Page")
            {
                //paperAudioSourse.Play();
                bookIsCatch = true;
            }

        }

        if (bookIsCatch)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.parent.transform.position = mousePos + offset;

            if (Input.GetMouseButtonUp(0))
            {
                bookIsCatch = false;
                if (mouseOriginalPos == mousePos) // Click
                {
                    int currentPage = transform.GetComponentInParent<BookControl>().getCurrent();
                    transform.GetComponentInParent<BookControl>().incCurrent();

                    int newPage = transform.GetComponentInParent<BookControl>().getCurrent();

                    transform.parent.GetChild(newPage).gameObject.SetActive(true);
                    transform.parent.GetChild(currentPage).gameObject.SetActive(false);
                }
                else // End of Drag
                {
                    if (transform.parent.GetComponent<BookControl>().onTelegraph)
                    {
                        transform.parent.transform.position = bookOriginalPos;
                    }
                    //paperAudioSourse.Play();
                }

            }



        }

    }

}
