using UnityEngine;

namespace Ivory.Interaction
{
    public interface IInteractable
    {
        float InteractDistance { get; }
        KeyCode InteractionKeyCode { get; }
        void Interact(GameObject go);
    }
}
