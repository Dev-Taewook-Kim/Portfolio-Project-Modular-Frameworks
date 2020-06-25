using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurveGenerator
{
    public static Vector2 LinearCurve(Vector2 a, Vector2 b, float t) => a + (b - a) * t;

    public static Vector2 QuadraticCurve(Vector2 a, Vector2 b, Vector2 c, float t)
    {
        var p0 = LinearCurve(a, b, t);
        var p1 = LinearCurve(b, c, t);

        return LinearCurve(p0, p1, t);
    }

    public static Vector2 CubicCurve(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t)
    {
        var p0 = QuadraticCurve(a, b, c, t);
        var p1 = QuadraticCurve(b, c, d, t);

        return LinearCurve(p0, p1, t);
    }

    public static Vector2[] LinearCurve(Vector2 a, Vector2 b, int segmentCount)
    {
        var p = new Vector2[segmentCount + 2];

        for (int i = 0; i < p.Length; i++)
        {
            var t = Mathf.InverseLerp(0, segmentCount + 1, i);
            p[i] = LinearCurve(a, b, t);
        }

        return p;
    }

    public static Vector2[] QuadraticCurve(Vector2 a, Vector2 b, Vector2 c, int segmentCount)
    {
        var p = new Vector2[segmentCount + 2];

        for (int i = 0; i < p.Length; i++)
        {
            var t = Mathf.InverseLerp(0, segmentCount + 1, i);

            p[i] = QuadraticCurve(a, b, c, t);
        }

        return p;
    }

    public static Vector2[] CubicCurve(Vector2 a, Vector2 b, Vector2 c, Vector2 d, int segmentCount)
    {
        var p = new Vector2[segmentCount + 2];

        for (int i = 0; i < p.Length; i++)
        {
            var t = Mathf.InverseLerp(0, segmentCount + 1, i);

            p[i] = CubicCurve(a, b, c, d, t);
        }

        return p;
    }

    public static Vector3 LinearCurve(Vector3 a, Vector3 b, float t) => a + (b - a) * t;

    public static Vector3 QuadraticCurve(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        var p0 = LinearCurve(a, b, t);
        var p1 = LinearCurve(b, c, t);

        return LinearCurve(p0, p1, t);
    }

    public static Vector3 CubicCurve(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        var p0 = QuadraticCurve(a, b, c, t);
        var p1 = QuadraticCurve(b, c, d, t);

        return LinearCurve(p0, p1, t);
    }

    public static Vector3[] LinearCurve(Vector3 a, Vector3 b, int segmentCount)
    {
        var p = new Vector3[segmentCount + 2];

        for (int i = 0; i < p.Length; i++)
        {
            var t = Mathf.InverseLerp(0, segmentCount + 1, i);
            p[i] = LinearCurve(a, b, t);
        }

        return p;
    }

    public static Vector3[] QuadraticCurve(Vector3 a, Vector3 b, Vector3 c, int segmentCount)
    {
        var p = new Vector3[segmentCount + 2];

        for (int i = 0; i < p.Length; i++)
        {
            var t = Mathf.InverseLerp(0, segmentCount + 1, i);

            p[i] = QuadraticCurve(a, b, c, t);
        }

        return p;
    }

    public static Vector3[] CubicCurve(Vector3 a, Vector3 b, Vector3 c, Vector3 d, int segmentCount)
    {
        var p = new Vector3[segmentCount + 2];

        for (int i = 0; i < p.Length; i++)
        {
            var t = Mathf.InverseLerp(0, segmentCount + 1, i);

            p[i] = CubicCurve(a, b, c, d, t);
        }

        return p;
    }
}
