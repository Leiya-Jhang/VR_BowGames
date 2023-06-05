using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticSystem : MonoBehaviour
{
    public XRBaseController leftController;
    public XRBaseController rightController;

    public float defaultAmplitude = 0.2f;
    public float defaultDuration = 0.5f;

    [ContextMenu("Send Haptics Test")]
    public void SendHaptics()
    {
        leftController.SendHapticImpulse(defaultAmplitude, defaultDuration);
        rightController.SendHapticImpulse(defaultAmplitude, defaultDuration);
    }
}
