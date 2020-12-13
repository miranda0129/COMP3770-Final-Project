using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    void OnTriggerEnter(Collider col) {

        Destroy(gameObject);
    }
}
