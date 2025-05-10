using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    public GameObject text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Friend")
        {
            text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Friend")
        {
            text.SetActive(false);
        }
    }
}
    
