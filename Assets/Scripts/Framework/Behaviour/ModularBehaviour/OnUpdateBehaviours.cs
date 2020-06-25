using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUpdateBehaviours : ModularBehaviour
{
    private void Update()
    {
        behaviours?.Invoke();
    }
}
