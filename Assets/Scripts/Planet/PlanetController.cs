using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlanetController : MonoBehaviour
{
    
    private void Awake()
    {
        DelegatesHandler.GameOver += DeactivateCollider;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "meteor")
        {
            DelegatesHandler.SharedInstance.DecreaseHealth();
        }
    }

    void HidePlanet()
    {
        gameObject.SetActive(false);
    }

    void DeactivateCollider()
    {
        var collider = GetComponent<SphereCollider>();
        collider.enabled = false;
    }
}
