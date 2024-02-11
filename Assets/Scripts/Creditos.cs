using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Creditos : MonoBehaviour
{
    public void SetCreditos() 
    {
        Transform hijoCredito = GameObject.Find("Canvas").transform.Find("Credito");
        if (hijoCredito != null)
        {
            GameObject credito = hijoCredito.gameObject;
            credito.SetActive(true);
        }

        Transform hijoCerrarCredito = GameObject.Find("Canvas").transform.Find("CerrarCredito");
        if (hijoCerrarCredito != null)
        {
            GameObject cerrarCredito = hijoCerrarCredito.gameObject;
            cerrarCredito.SetActive(true);
        }

        Transform hijoButtonStart = GameObject.Find("Canvas").transform.Find("ButtonStart");
        if (hijoButtonStart != null)
        {
            GameObject start = hijoButtonStart.gameObject;
            start.SetActive(false);
        }

        Transform hijoButtonQuit = GameObject.Find("Canvas").transform.Find("ButtonQuit");
        if (hijoButtonQuit != null)
        {
            GameObject quit = hijoButtonQuit.gameObject;
            quit.SetActive(false);
        }
        Transform hijoButtonCredito = GameObject.Find("Canvas").transform.Find("ButtonCredito");
        if (hijoButtonCredito != null)
        {
            GameObject credito = hijoButtonCredito.gameObject;
            credito.SetActive(false);
        }
    }
}
