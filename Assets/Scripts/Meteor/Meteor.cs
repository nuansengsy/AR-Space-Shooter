using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Meteor : MonoBehaviour
{
    public float movementSpeed;
    public GameObject explosionEffect;
    public Renderer rend;

    public ARReferencePointManager arReferencePointManager;

    private void Awake()
    {
        arReferencePointManager = FindObjectsOfType<ARReferencePointManager>()[0];

    }
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "planet")
        {
            rend.enabled = false;
            explosionEffect.SetActive(true);
            explosionEffect.transform.localRotation = Quaternion.Euler(-90f,0f,0f);
            movementSpeed = 0f;
            StartCoroutine(DestoryAfterTime());
        }
    }

    public IEnumerator DestoryAfterTime()
    {
        yield return new WaitForSeconds(3);
        ARReferencePoint rp;
        rp = gameObject.transform.parent.gameObject.GetComponent<ARReferencePoint>();
        arReferencePointManager.RemoveReferencePoint(rp);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
