using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneDetectionController : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;

    void Start()
    {
        DelegatesHandler.GameStart += DisableAllPlanes;
    }

    void DisableAllPlanes()
    {
        foreach (var plane in arPlaneManager.trackables)
        plane.gameObject.SetActive(false);
    }

}
