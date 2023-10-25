using UnityEngine;
using System.Collections;

public class Chec : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() == null)
            return;

        if (GetComponent<Animator>() != null)
            GetComponent<Animator>().SetBool("finish", true);
        Destroy(this);
    }
}
