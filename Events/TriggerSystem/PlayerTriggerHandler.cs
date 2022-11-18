using UnityEngine;

public class PlayerTriggerHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(transform.name + " entered " + other.name, transform);
        ITriggerEnter triggerEnter = other.GetComponent<ITriggerEnter>();
        if (triggerEnter != null)
        {
            triggerEnter.ITriggerEnter(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        ITriggerStay triggerStay = other.GetComponent<ITriggerStay>();
        if (triggerStay != null)
        {
            triggerStay.OnTriggerStay(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ITriggerExit triggerExit = other.GetComponent<ITriggerExit>();
        if (triggerExit != null)
        {
            triggerExit.OnTriggerExit(other.gameObject);
        }
    }
}