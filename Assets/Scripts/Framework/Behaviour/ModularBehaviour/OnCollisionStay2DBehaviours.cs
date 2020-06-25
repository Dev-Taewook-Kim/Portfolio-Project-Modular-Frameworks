using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionStay2DBehaviours : ModularBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        behaviours?.Invoke();
    }
}
