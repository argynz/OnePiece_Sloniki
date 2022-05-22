using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Interactable : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;    
    }

    public abstract void Interact();

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<PlayerController>().OpenInteractableIcon();
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<PlayerController>().CloseInteractableIcon();
    }
}
