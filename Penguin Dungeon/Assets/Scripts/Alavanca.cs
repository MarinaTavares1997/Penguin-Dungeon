using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavanca : MonoBehaviour
{
    public bool alavanca;
    public float tempo;
    public float tempototal;
    public GameObject armadilha;

    // Update is called once per frame
    void Update()
    {
        tempototal -= 1 * Time.deltaTime;

        if(tempo <= 0)
        {
            armadilha.SetActive(false);
        }
        else
        {
            armadilha.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            alavanca = true;
            tempo = tempototal;
        }
    }
}
