using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterBehaviours : ModularBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        behaviours?.Invoke();
    }
}
