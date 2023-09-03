using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public bool _isMoveEnable;


    public float distanceThreshold = .10f;
    public event System.Action Grounded;
    const float OriginOffset = .001f;
    Vector3 RaycastOrigin => transform.position + Vector3.up * OriginOffset;
    float RaycastDistance => distanceThreshold + OriginOffset;

    private void Update()
    {
        _isMoveEnable = Physics.Raycast(RaycastOrigin, Vector3.down, distanceThreshold * 2);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a line in the Editor to show whether we are touching the ground.
        Debug.DrawLine(RaycastOrigin, RaycastOrigin + Vector3.down * RaycastDistance, _isMoveEnable ? Color.white : Color.red);
    }
}