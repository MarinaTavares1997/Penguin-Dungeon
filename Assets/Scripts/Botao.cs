using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour
{
    public bool botao;
    public float tempo;
    public float tempototal;
    public GameObject blocos1;
    public GameObject blocos2;

    // Update is called once per frame
    void Update()
    {
        tempototal -= 1 * Time.deltaTime;

        if(tempo <= 0)
        {
            blocos1.SetActive(false);
            blocos2.SetActive(true);
        }
        else
        {
            blocos1.SetActive(true);
            blocos2.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            botao = true;
            tempo = tempototal;
        }
    }
}
