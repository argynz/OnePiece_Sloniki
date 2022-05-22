public class Openable : Interactable
{
    private bool isOpen;
    public override void Interact()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            // open some panel
            // e.g. inventory, bench
        }
        else
        {
            // close panel
        }

    }
}
