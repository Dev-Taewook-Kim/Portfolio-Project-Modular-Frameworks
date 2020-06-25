using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionExit2DBehaviours : ModularBehaviour
{
    private void OnCollisionExit2D(Collision2D collision)
    {
        behaviours?.Invoke();
    }
}
