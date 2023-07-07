using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Armadilha : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{name} Triggered");
        if(collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
