using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarCredito : MonoBehaviour
{
    public void CerrarCreditos() {
        GameObject creditos = GameObject.Find("Credito");
        creditos.SetActive(false);
        GameObject cerrar = GameObject.Find("CerrarCredito");
        cerrar.SetActive(false);

        Transform hijoButtonStart = GameObject.Find("Canvas").transform.Find("ButtonStart");
        if (hijoButtonStart != null)
        {
            GameObject start = hijoButtonStart.gameObject;
            start.SetActive(true);
        }

        Transform hijoButtonQuit = GameObject.Find("Canvas").transform.Find("ButtonQuit");
        if (hijoButtonQuit != null)
        {
            GameObject quit = hijoButtonQuit.gameObject;
            quit.SetActive(true);
        }
        Transform hijoButtonCredito = GameObject.Find("Canvas").transform.Find("ButtonCredito");
        if (hijoButtonCredito != null)
        {
            GameObject credito = hijoButtonCredito.gameObject;
            credito.SetActive(true);
        }
    }
}
