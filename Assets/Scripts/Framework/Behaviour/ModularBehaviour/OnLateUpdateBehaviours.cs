using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLateUpdateBehaviours : ModularBehaviour
{
    private void LateUpdate()
    {
        behaviours?.Invoke();
    }
}
