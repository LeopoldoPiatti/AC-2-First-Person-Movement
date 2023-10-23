using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour {


    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private ObjectGrabbable objectGrabbable;
    public float pickUpdistance;

    private void Update() {
        if (Input.GetMouseButton(1))
        {
            if (objectGrabbable == null) {
                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, pickUpdistance, pickUpLayerMask)) {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable)) {
                        objectGrabbable.Grab(objectGrabPointTransform);
                    }
                }
            } else {
                // Currently carrying something, drop
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }
}