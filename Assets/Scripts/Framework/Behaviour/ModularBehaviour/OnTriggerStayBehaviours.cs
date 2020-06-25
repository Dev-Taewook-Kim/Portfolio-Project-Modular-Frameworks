using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerStayBehaviours : ModularBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        behaviours?.Invoke();
    }
}
