using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperControl : MonoBehaviour
{
    private bool paper;
    private Vector2 paperOriginalPos;
    private bool onTelegraph;

    private void Start()
    {
        paper = false;
        paperOriginalPos = transform.position;
        onTelegraph = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            paperOriginalPos = transform.position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider.gameObject.name == "Paper")
            {
                paper = true;
            }
        }

        if (paper)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            paper = false;
            if (onTelegraph)
            {
                transform.position = paperOriginalPos;
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
