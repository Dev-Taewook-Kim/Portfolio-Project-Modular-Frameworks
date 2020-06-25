using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionStayBehaviours : ModularBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        behaviours?.Invoke();
    }
}
