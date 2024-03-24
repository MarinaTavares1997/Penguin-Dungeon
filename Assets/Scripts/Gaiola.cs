using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaiola : MonoBehaviour
{
    public GameObject gaiola;

    public Botao botao;

    // Start is called before the first frame update
    void Start()
    {
        botao = GameObject.Find("Botão").GetComponent<Botao>();
    }

    // Update is called once per frame
    void Update()
    {
        if (botao.botao)
           {
               gaiola.SetActive(false);
           }
           else
           {
               gaiola.SetActive(true);
           }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
       {
           if (botao.botao)
           {
               gaiola.SetActive(false);
           }
           else
           {
               gaiola.SetActive(true);
           }
       }
    }
}
