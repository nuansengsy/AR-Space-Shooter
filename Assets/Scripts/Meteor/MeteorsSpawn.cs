using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MeteorsSpawn : MonoBehaviour
{
    public ARReferencePointManager arReferencePointManager;
    private Vector3 center;
    public float sphereRadius;
    public GameObject meteorPrefab;
    private bool canSpawnmeteors;

    void Start()
    {
        center = transform.position;
        canSpawnmeteors = true;
        StartCoroutine(SpawnMeteors());
    }

    Vector3 RandomPointOnSphere()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(0.5f, 1f);
        float z = Random.Range(-1f, 1f);

        Vector3 pos = center + new Vector3(x, y, z).normalized * sphereRadius;
        return pos;
    }

    public IEnumerator SpawnMeteors()
    {

        while (canSpawnmeteors)
        {

            Pose pose;
            pose.position = RandomPointOnSphere();
            pose.rotation = Quaternion.identity;
            ARReferencePoint meteorReferencePoint = arReferencePointManager.AddReferencePoint(pose);

            GameObject meteor = Instantiate(meteorPrefab, pose.position, Quaternion.identity);
            meteor.transform.SetParent(meteorReferencePoint.gameObject.transform);
            meteor.transform.localPosition = new Vector3(0, 0, 0);
            meteor.transform.LookAt(center);
            yield return new WaitForSeconds(3f);
        }
    }
}
