using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDisableBehaviours : ModularBehaviour
{
    private void OnDisable()
    {
        behaviours?.Invoke();
    }
}
