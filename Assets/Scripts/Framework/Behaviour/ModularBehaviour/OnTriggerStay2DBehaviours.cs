using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerStay2DBehaviours : ModularBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        behaviours?.Invoke();
    }
}
