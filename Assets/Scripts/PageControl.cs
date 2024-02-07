using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageControl : MonoBehaviour
{
    //public AudioSource paperAudioSourse;
    private GameObject[] pages;
    private int current;

    private void Start()
    {

        print("PAPER INITITATED | CURRENT ");

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            print("clickedd");
            if (hit.collider != null && hit.collider.gameObject.tag == "Page") // Se clickea en la pagina
            {
                print("Inside page");

                int currentPage = transform.GetComponentInParent<BookControl>().getCurrent();
                transform.GetComponentInParent<BookControl>().incCurrent();

                int newPage = transform.GetComponentInParent<BookControl>().getCurrent();

                transform.parent.GetChild(newPage).gameObject.SetActive(true);
                transform.parent.GetChild(currentPage).gameObject.SetActive(false);
            }
            else // Se clickea fuera
            {
                print("Outside page");
                int currentPage = transform.GetComponentInParent<BookControl>().getCurrent();
                transform.parent.GetChild(currentPage).gameObject.SetActive(false);
            }
        }
    }

}
