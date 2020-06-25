using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyBehaviours : ModularBehaviour
{
    private void OnDestroy()
    {
        behaviours?.Invoke();
    }
}
