using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promMessege;
    internal string promptMessage;

    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {

    }
}
