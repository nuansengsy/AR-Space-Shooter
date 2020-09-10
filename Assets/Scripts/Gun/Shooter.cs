using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    public GraphicRaycaster m_Raycaster;
    public EventSystem m_EventSystem;

    public ParticleSystem rightTracer;
    public ParticleSystem leftTracer;
    public GameObject impactEffect;
    private float damage = 10f;
    public float fireRate;
    private bool isFiring;

    void Update()
    {
        if (!isFiring && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject())
        {
            isFiring = true;
            StartCoroutine(ProcessFire());
        }

        if (isFiring && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && !EventSystem.current.IsPointerOverGameObject())
        {
            isFiring = false;
            rightTracer.Stop();
            leftTracer.Stop();
            StopCoroutine(ProcessFire());
        }
    }

    private IEnumerator ProcessFire()
    {
        rightTracer.Play();
        leftTracer.Play();
        while (isFiring)
        {
            FireOnce();
            yield return new WaitForSeconds(fireRate);
        }

    }

    public void FireOnce()
    {
        RaycastHit hit;
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }

        }
    }
}
