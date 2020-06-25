using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableBehaviours : ModularBehaviour
{
    private void OnEnable()
    {
        behaviours?.Invoke();
    }
}
