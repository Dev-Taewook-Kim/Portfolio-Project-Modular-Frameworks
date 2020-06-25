using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnter2DBehaviours : ModularBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        behaviours?.Invoke();
    }
}
