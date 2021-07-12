using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private bool _isEmpty = true;

    public bool IsEmpty => _isEmpty;

    private void OnTriggerStay2D(Collider2D collision)
    {
        _isEmpty = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isEmpty = true;
    }
}
