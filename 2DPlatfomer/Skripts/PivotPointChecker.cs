using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotPointChecker : MonoBehaviour
{
    public bool IsReached { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PivotPoint>(out PivotPoint pivotPoint))
            IsReached = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PivotPoint>(out PivotPoint pivotPoint))
            IsReached = false;
    }
}
