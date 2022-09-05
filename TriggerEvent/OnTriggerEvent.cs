using UnityEngine;
using UnityEngine.Events;

namespace SKUttils
{
    public class OnTriggerEvent : MonoBehaviour
    {
        [SerializeField] string tag;

        [SerializeField] UnityEvent onEnter;
        [SerializeField] UnityEvent<GameObject> onEnterGameObject;

        [SerializeField] UnityEvent onStay;
        [SerializeField] UnityEvent<GameObject> onStayGameObject;

        [SerializeField] UnityEvent onExit;
        [SerializeField] UnityEvent<GameObject> onExitGameObject;

        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag(tag))
            {
                onEnter?.Invoke();
                onEnterGameObject?.Invoke(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(tag))
            {
                onExit?.Invoke();
                onExitGameObject?.Invoke(other.gameObject);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(tag))
            {
                onStay?.Invoke();
                onStayGameObject?.Invoke(other.gameObject);
            }
        }
    }
}
