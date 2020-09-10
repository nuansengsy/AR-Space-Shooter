using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlace : MonoBehaviour
{
    [SerializeField] private ARRaycastManager arRaycastManager;
    [SerializeField] private ARReferencePointManager arReferencePointManager;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private List<ARReferencePoint> referencePoints = new List<ARReferencePoint>();

    private bool placementIsPoseValid;
    private Pose placementIndicatorPose;
    [SerializeField] private GameObject placementIndicator;
    [SerializeField] private GameObject planetEarth;
    private bool planetPlaced;
    public Button startButton;

    void Awake()
    {
        DelegatesHandler.GameStart += PlacePlanet;
        arRaycastManager = GetComponent<ARRaycastManager>();
        arReferencePointManager = GetComponent<ARReferencePointManager>();
        planetPlaced = false;
        placementIndicator.SetActive(false);
        startButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!planetPlaced)
        {
            UpdatePlacementPose();
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        if (arRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon))
        {
            placementIsPoseValid = true;
            placementIndicatorPose = hits[0].pose;
            placementIndicator.SetActive(true);
            placementIndicator.transform.position = placementIndicatorPose.position;
            startButton.gameObject.SetActive(true);
        }
        else
        {
            placementIsPoseValid = false;
            placementIndicator.SetActive(false);
            startButton.gameObject.SetActive(false);
        }
    }

    private void PlacePlanet()
    {
        if (placementIsPoseValid)
        {
            Pose planetPose = placementIndicatorPose;
            planetPose.position.y += 0.8f;
            ARReferencePoint planetReferencePoint = arReferencePointManager.AddReferencePoint(planetPose);

            if (planetReferencePoint == null)
            {
                string errorEntry = "There was an error creating a reference point\n";
                Debug.Log(errorEntry);
            }
            else
            {
                planetEarth.transform.SetParent(planetReferencePoint.gameObject.transform);
                planetEarth.transform.localPosition = new Vector3(0, 0, 0);
                planetEarth.GetComponent<Planet_Explosion_Fast>().enabled = true;
                planetEarth.GetComponent<MeteorsSpawn>().enabled = true;
                planetEarth.GetComponent<PlanetController>().enabled = true;
                referencePoints.Add(planetReferencePoint);
                planetPlaced = true;
                placementIndicator.SetActive(false);
            }
        }

        
    }


}
