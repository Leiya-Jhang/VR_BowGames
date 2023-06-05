using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public struct InputData : INetworkInput
{
    public Vector3 movementInput;
    public float rotate;
}
