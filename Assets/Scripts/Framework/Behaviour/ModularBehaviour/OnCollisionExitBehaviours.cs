using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionExitBehaviours : ModularBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        behaviours?.Invoke();
    }
}
