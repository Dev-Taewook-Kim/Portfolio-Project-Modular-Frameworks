using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFixedUpdateBehaviours : ModularBehaviour
{
    private void FixedUpdate()
    {
        behaviours.Invoke();
    }
}
