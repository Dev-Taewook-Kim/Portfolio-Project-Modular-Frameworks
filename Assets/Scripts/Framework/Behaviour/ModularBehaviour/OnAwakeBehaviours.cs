using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAwakeBehaviours : ModularBehaviour
{
    private void Awake()
    {
        behaviours?.Invoke();
    }
}
