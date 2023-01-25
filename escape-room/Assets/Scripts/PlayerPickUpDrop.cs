using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask ;
    [SerializeField] private Transform objectGrabPointTransform; 

    // Update is called once per frame
    private ObjectGrabbable objectGrabbable;
   private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(objectGrabbable==null){
                //not carrying an object, try to grab
            float pickUpDistance = 2f;
           if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask)){
            Debug.Log(raycastHit.transform);
            if (raycastHit.transform.TryGetComponent(out objectGrabbable)){
                objectGrabbable.Grab(objectGrabPointTransform);
                Debug.Log(objectGrabbable);
            }
            }
            }else{
                //currently carrying something,drop
                objectGrabbable.Drop();
                objectGrabbable=null;
            }
        }
    }
}

