using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnter2DBehaviours : ModularBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        behaviours.Invoke();
    }
}
