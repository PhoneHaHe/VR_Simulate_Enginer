using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OffsetGrabtable : XRGrabInteractable
{
    // Start is called before the first frame update
    private Vector3 intialAttachLocalPos = Vector3.zero;
    private Quaternion intialAttachLocalRot = Quaternion.identity;

    [System.Obsolete]
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {

        base.OnSelectEntered(interactor);
        StoreInteractor(interactor);
        MatchAttachmentPoint(interactor);
    }

    private void StoreInteractor(XRBaseInteractor interactor)
    {

        intialAttachLocalPos = interactor.attachTransform.transform.localPosition;
        intialAttachLocalRot = interactor.attachTransform.transform.localRotation;

    }

    private void MatchAttachmentPoint(XRBaseInteractor interactor)
    {

        bool hasAttach = attachTransform != null;
        interactor.attachTransform.position = hasAttach ? attachTransform.position : transform.position;
        interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;

    }

    [System.Obsolete]
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        ResetAttachmentPoint(interactor);
        ClearInteractor(interactor);

    }

    private void ResetAttachmentPoint(XRBaseInteractor interactor)
    {

        interactor.attachTransform.transform.localPosition = intialAttachLocalPos;
        interactor.attachTransform.transform.localRotation = intialAttachLocalRot;
    }
    private void ClearInteractor(XRBaseInteractor interactor)
    {
        intialAttachLocalPos = Vector3.zero;
        intialAttachLocalRot = Quaternion.identity;
    }

}

