using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundyZone : MonoBehaviour
{
    public Collider boundaryCollider;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Destroyable"))
        {
            Score.score--;
            Destroy(other.gameObject);
        }
    }
}
