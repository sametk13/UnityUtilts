using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    Rigidbody[] ragdolbodies;
    Collider[] ragdolColliders;
    Collider mainCollider;

    private void Start()
    {
        ragdolbodies = GetComponentsInChildren<Rigidbody>();
        ragdolColliders = GetComponentsInChildren<Collider>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        mainCollider = GetComponent<Collider>();
        ToggleRagdoll(false);
    }

    public void Die(Vector3 playerDirection, float forcePower)
    {
        ToggleRagdoll(true);
        rb.AddForce(playerDirection * 50f * forcePower, ForceMode.Impulse);
    }
    public void ToggleRagdoll(bool state)
    {
        if (state == true)
        {
            animator.enabled = !state;
        }

        for (int i = 0; i < ragdolbodies.Length; i++)
        {
            ragdolbodies[i].isKinematic = !state;
        }

        for (int i = 0; i < ragdolColliders.Length; i++)
        {
            ragdolColliders[i].enabled = state;
        }
        mainCollider.enabled = true;
    }
}
