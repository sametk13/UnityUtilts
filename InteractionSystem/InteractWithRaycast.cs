using Ivory.Interaction;
using UnityEngine;

public class InteractWithRaycast : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] LayerMask ignoreLayers;
    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        ignoreLayers = ~ignoreLayers;
        if (Physics.Raycast(ray, out hit, 100f, ignoreLayers))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            hit.collider.TryGetComponent(out IInteractable interactable);
            if (interactable != null && hit.distance < interactable.InteractDistance &&
            Input.GetKeyDown(interactable.InteractionKeyCode))
            {
                Debug.Log("Interacted with " + hit.collider.name);
                interactable.Interact(gameObject);
            }
        }
    }
}