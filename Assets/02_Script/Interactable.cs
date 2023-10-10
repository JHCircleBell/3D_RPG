using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] public float radius = 3f;

    private bool isFocus = false;
    private Transform player;

    public Transform interactionTransform;

    private bool hasInteracted = false;


    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);

            if(distance <= radius)
            {
                // Debug.Log("상호작용중입니다.");

                Interact();
                hasInteracted = true;
            }
        }
    }
    // >> ontrigger 수정

    public virtual void Interact()
    {
        // Debug.Log("상호작용 대상 " + transform.name);
    }


    private void OnDrawGizmosSelected()
    {
        if(interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
}
