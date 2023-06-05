using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Fusion;

public class VR_Movement : NetworkBehaviour
{
    [SerializeField] private InputActionProperty buttonY;
    [SerializeField] private InputActionProperty buttonX;
    [SerializeField] private InputActionProperty triggerAction;
    [SerializeField] private NetworkCharacterControllerPrototype networkCharacterControllerPrototype = null;


    // Update is called once per frame
    void Update()
    {
        // Debug.Log(targetForward.rotation);
        // if (transform.position.y<0.5f)
        // {
        //     Vector3 resetPos = new Vector3(transform.position.x, 0.5f, transform.position.z);
        //     transform.position = resetPos;
        // }
        // if (transform.position.y>0.5f)
        // {
        //     Vector3 resetPos = new Vector3(transform.position.x, 0.5f, transform.position.z);
        //     transform.position = resetPos;
        // }
        // if (triggerAction.action.IsPressed())
        // {
        //      transform.position += transform.forward*Runner.DeltaTime;
        // }
        //
        // if (buttonY.action.IsPressed())
        // {
        //     transform.Rotate(0,1,0);
        // }
        //
        // if (buttonX.action.IsPressed())
        // {
        //     transform.Rotate(0,-1,0);
        // }
       
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out InputData data))
        {
            Vector3 moveVector3 = data.movementInput.normalized;
            networkCharacterControllerPrototype.Move(moveVector3 * Runner.DeltaTime * 0.5f);

        }
    }
}
