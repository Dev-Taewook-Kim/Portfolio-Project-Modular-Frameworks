using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerExitBehaviours : ModularBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        behaviours?.Invoke();
    }
}
