using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppUtil {
    static Vector3 vec3 = Vector3.zero;
    public static Vector3 PolarToVec(float _r, float _theta)
    {
        vec3.x = _r * Mathf.Cos(_theta * Mathf.Deg2Rad);
        vec3.y = _r * Mathf.Sin(_theta * Mathf.Deg2Rad);
        return vec3;
    }

    public static Vector3 CalculateCatmullRom(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float tt = t * t;
        float ttt = tt * t;

        vec3 = 2 * p1;
        vec3 += (-p0 + p2) * t;
        vec3 += (2 * p0 - 5 * p1 + 4 * p2 - p3) * tt;
        vec3 += (-p0 + 3 * p1 - 3 * p2 + p3) * ttt;
        return vec3 * 0.5f;
    }

    public static Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        vec3 = uuu * p0;
        vec3 += 3 * uu * t * p1;
        vec3 += 3 * u * tt * p2;
        vec3 += ttt * p3;
        return vec3;
    }
}
