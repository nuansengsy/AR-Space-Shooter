using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ReferencePointsPlacer : MonoBehaviour
{
    [SerializeField] private ARReferencePointManager arReferencePointManager;
    private List<ARReferencePoint> referencePoints = new List<ARReferencePoint>();
    public GameObject refencePointsPool;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CreateReferencePoint(Pose pose, Transform parentObject)
    {
        ARReferencePoint referencePoint = arReferencePointManager.AddReferencePoint(pose);
        if (referencePoint == null)
        {
            return null;
        }
        else
        {
            referencePoints.Add(referencePoint);
            referencePoint.gameObject.transform.SetParent(parentObject);
            return referencePoint.gameObject;

        }
    }
}
