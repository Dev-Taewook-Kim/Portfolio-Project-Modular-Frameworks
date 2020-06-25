using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartBehaviours : ModularBehaviour
{
    private void Start()
    {
        behaviours.Invoke();
    }
}
