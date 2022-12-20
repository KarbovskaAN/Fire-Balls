using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletText : MonoBehaviour
{
    public GameObject Text;

    private void Update()
    {
        DestroyText();
    }

    private void DestroyText()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(Text);
        }
    }
}
