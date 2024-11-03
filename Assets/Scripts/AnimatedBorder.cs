using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedBorder : MonoBehaviour
{
    private RectTransform bordersquareTransform;

    private Vector3 StartPos, Pos1, Pos2, Pos3, Pos4, Pos5, Pos6, Pos7;

    [SerializeField] private float speed = 0.5f;

    private Vector3[] positions;

    private int currentTargetIndex = 0;

    private float travelTime;
    private float journeyStartTime;
    private Vector3 originalPos;

    void Start()
    {
        bordersquareTransform = GetComponent<RectTransform>();
        string objectTag = gameObject.tag;

        // Assign positions based on the tag
        if (objectTag == "topright")
        {
            StartPos = new Vector3(1825f, 1000f, 0f);
            Pos1 = new Vector3(1825f, 0f, 0f);
            Pos2 = new Vector3(1825f, -1000f, 0f);
            Pos3 = new Vector3(0f, -1000f, 0f);
            Pos4 = new Vector3(-1825f, -1000f, 0f);
            Pos5 = new Vector3(-1825f, 0f, 0f);
            Pos6 = new Vector3(-1825f, 1000f, 0f);
            Pos7 = new Vector3(0f, 1000f, 0f);
        }
        else if (objectTag == "middleright")
        {
            StartPos = new Vector3(1825f, 0f, 0f);
            Pos1 = new Vector3(1825f, -1000f, 0f);
            Pos2 = new Vector3(0f, -1000f, 0f);
            Pos3 = new Vector3(-1825f, -1000f, 0f);
            Pos4 = new Vector3(-1825f, 0f, 0f);
            Pos5 = new Vector3(-1825f, 1000f, 0f);
            Pos6 = new Vector3(0f, 1000f, 0f);
            Pos7 = new Vector3(1825f, 1000f, 0f);
        }
        else if (objectTag == "bottomright")
        {
            StartPos = new Vector3(1825f, -1000f, 0f);
            Pos1 = new Vector3(0f, -1000f, 0f);
            Pos2 = new Vector3(-1825f, -1000f, 0f);
            Pos3 = new Vector3(-1825f, 0f, 0f);
            Pos4 = new Vector3(-1825f, 1000f, 0f);
            Pos5 = new Vector3(0f, 1000f, 0f);
            Pos6 = new Vector3(1825f, 1000f, 0f);
            Pos7 = new Vector3(1825f, 0f, 0f);
        }
        else if (objectTag == "bottommiddle")
        {
            StartPos = new Vector3(0f, -1000f, 0f);
            Pos1 = new Vector3(-1825f, -1000f, 0f);
            Pos2 = new Vector3(-1825f, 0f, 0f);
            Pos3 = new Vector3(-1825f, 1000f, 0f);
            Pos4 = new Vector3(0f, 1000f, 0f);
            Pos5 = new Vector3(1825f, 1000f, 0f);
            Pos6 = new Vector3(1825f, 0f, 0f);
            Pos7 = new Vector3(1825f, -1000f, 0f);
        }
        else if (objectTag == "bottomleft")
        {
            StartPos = new Vector3(-1825f, -1000f, 0f);
            Pos1 = new Vector3(-1825f, 0f, 0f);
            Pos2 = new Vector3(-1825f, 1000f, 0f);
            Pos3 = new Vector3(0f, 1000f, 0f);
            Pos4 = new Vector3(1825f, 1000f, 0f);
            Pos5 = new Vector3(1825f, 0f, 0f);
            Pos6 = new Vector3(1825f, -1000f, 0f);
            Pos7 = new Vector3(0f, -1000f, 0f);
        }
        else if (objectTag == "leftmiddle")
        {
            StartPos = new Vector3(-1825f, 0f, 0f);
            Pos1 = new Vector3(-1825f, 1000f, 0f);
            Pos2 = new Vector3(0f, 1000f, 0f);
            Pos3 = new Vector3(1825f, 1000f, 0f);
            Pos4 = new Vector3(1825f, 0f, 0f);
            Pos5 = new Vector3(1825f, -1000f, 0f);
            Pos6 = new Vector3(0f, -1000f, 0f);
            Pos7 = new Vector3(-1825f, -1000f, 0f);
        }
        else if (objectTag == "topleft")
        {
            StartPos = new Vector3(-1825f, 1000f, 0f);
            Pos1 = new Vector3(0f, 1000f, 0f);
            Pos2 = new Vector3(1825f, 1000f, 0f);
            Pos3 = new Vector3(1825f, 0f, 0f);
            Pos4 = new Vector3(1825f, -1000f, 0f);
            Pos5 = new Vector3(0f, -1000f, 0f);
            Pos6 = new Vector3(-1825f, -1000f, 0f);
            Pos7 = new Vector3(-1825f, 0f, 0f);
        }
        else if (objectTag == "topmiddle")
        {
            StartPos = new Vector3(0f, 1000f, 0f);
            Pos1 = new Vector3(1825f, 1000f, 0f);
            Pos2 = new Vector3(1825f, 0f, 0f);
            Pos3 = new Vector3(1825f, -1000f, 0f);
            Pos4 = new Vector3(0f, -1000f, 0f);
            Pos5 = new Vector3(-1825f, -1000f, 0f);
            Pos6 = new Vector3(-1825f, 0f, 0f);
            Pos7 = new Vector3(-1825f, 1000f, 0f);
        }

        positions = new Vector3[] { StartPos, Pos1, Pos2, Pos3, Pos4, Pos5, Pos6, Pos7 };
        bordersquareTransform.anchoredPosition = StartPos;

        NextMovement();
    }

    void Update()
    {
        float t = (Time.time - journeyStartTime) / travelTime;
        t = Mathf.Clamp01(t);
        bordersquareTransform.anchoredPosition = Vector3.Lerp(originalPos, positions[currentTargetIndex], t);

        if (t >= 1.0f)
        {
            NextMovement();
        }
    }

    private void NextMovement()
    {
        originalPos = bordersquareTransform.anchoredPosition;
        currentTargetIndex = (currentTargetIndex + 1) % positions.Length;
        float distance = Vector3.Distance(originalPos, positions[currentTargetIndex]);
        travelTime = distance / speed;
        journeyStartTime = Time.time;
    }
}


