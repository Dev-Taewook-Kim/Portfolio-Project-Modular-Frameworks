using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent()]
public abstract class ModularBehaviour : MonoBehaviour
{
    [SerializeField] protected UnityEvent behaviours;
}
