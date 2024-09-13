using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BowlingBallInteraction : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    private XRBaseInteractor currentInteractor;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(OnActivated);
        grabInteractable.deactivated.AddListener(OnDeactivated);
    }

    private void OnActivated(ActivateEventArgs args)
    {
        currentInteractor = args.interactor;
        // Grab the object
        currentInteractor.StartInteraction(grabInteractable);
    }

    private void OnDeactivated(DeactivateEventArgs args)
    {
        // Release the object
        currentInteractor.EndInteraction(grabInteractable);
        currentInteractor = null;
    }

    private void Update()
    {
        // Move the object with the interactor
        if (currentInteractor != null)
        {
            transform.position = currentInteractor.transform.position;
        }
    }
}