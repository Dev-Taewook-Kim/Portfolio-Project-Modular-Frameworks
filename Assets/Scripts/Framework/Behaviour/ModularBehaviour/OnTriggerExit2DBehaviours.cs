using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerExit2DBehaviours : ModularBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        behaviours?.Invoke();
    }
}
