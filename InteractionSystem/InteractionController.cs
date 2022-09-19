using UnityEngine;
using UnityEngine.Events;

namespace SKUtils.Interaction
{
    public class InteractionController : MonoBehaviour
    {
        public UnityEvent OnInteractableEnter;
        public UnityEvent OnInteractableExit;
        public UnityEvent<GameObject> OnInteracted;

        Iinteractable currentInteractable;
        GameObject interactableObject;

        private void OnTriggerEnter(Collider other)
        {
            currentInteractable = other.GetComponent<Iinteractable>();
            if (currentInteractable != null)
            {
                OnInteractableEnter?.Invoke();
                interactableObject = other.gameObject;
                // open interactable prompt code...
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Iinteractable interactable = other.GetComponent<Iinteractable>();
            if (currentInteractable == interactable)
            {
                OnInteractableExit?.Invoke();
                interactableObject = null;
                currentInteractable = null;
            }
        }

        private void Update()
        {
            if (currentInteractable != null && Input.GetKeyDown(currentInteractable.InteractionKeyCode))
            {
                OnInteracted?.Invoke(interactableObject);
                currentInteractable.Interact(interactableObject);
            }
        }
    }
}