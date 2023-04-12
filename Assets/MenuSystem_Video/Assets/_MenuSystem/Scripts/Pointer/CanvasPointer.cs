using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasPointer : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem = null;
    [SerializeField] private StandaloneInputModule inputModule = null;

    [SerializeField] protected float defaultLength = 3.0f;

    private LineRenderer lineRenderer = null;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateLength();
    }

    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, GetEnd());
    }

    private Vector3 GetEnd()
    {
        // Canvas distance
        float distance = GetCanvasDistance();
        Vector3 endPosition = CalculatetEnd(defaultLength);

        // Based on distance
        if (distance != 0.0f)
            endPosition = CalculatetEnd(distance);

        return endPosition;
    }

    private float GetCanvasDistance()
    {
        // Get data
        PointerEventData eventData = new PointerEventData(eventSystem);
        eventData.position = inputModule.inputOverride.mousePosition;

        // Raycast using data
        List<RaycastResult> results = new List<RaycastResult>();
        eventSystem.RaycastAll(eventData, results);

        // Get closest 
        RaycastResult closestResult = FindFirstRaycast(results);
        float distance = closestResult.distance;

        // Clamp and return
        distance = Mathf.Clamp(distance, 0.0f, defaultLength);
        return distance;
    }

    private RaycastResult FindFirstRaycast(List<RaycastResult> results)
    {
        foreach (RaycastResult result in results)
        {
            if (!result.gameObject)
                continue;

            return result;
        }

        return new RaycastResult();
    }

    protected Vector3 CalculatetEnd(float length)
    {
        return transform.position + (transform.forward * length);
    }
}
