using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterBehaviours : ModularBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        behaviours?.Invoke();
    }
}
