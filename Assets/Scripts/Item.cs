using UnityEngine;
using UnityEngine.Events;
public class Item : Interactable
{
    public enum ItemType {Staic, Consumables}
    public string itemName;
    public string descriptionText;
    public ItemType type;
    public UnityEvent consumeEvent;
    public ParticleSystem pickUpParticle;
    public GameObject ui_CraftWindow;

    public override void Interact()
    {
        FindObjectOfType<InventorySystem>().PickUp(gameObject);
        gameObject.SetActive(false);
    }
}
