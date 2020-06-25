using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShapeGenerator
{
    public static Vector3[] GenerateShape2D(int segmentCount, float radius)
    {
        var points = new Vector3[segmentCount];

        var spacing = 360f / segmentCount;

        for (int i = 0; i < points.Length; i++)
        {
            var x = Mathf.Cos(Mathf.Deg2Rad * (i * spacing)) * radius;
            var y = Mathf.Sin(Mathf.Deg2Rad * (i * spacing)) * radius;

            points[i] = new Vector3(x, y);
        }

        return points;
    }

    public static Mesh GenerateShapeMesh2D(int segmentCount, float radius)
    {
        var points = GenerateShape2D(segmentCount, radius);

        var vertices = new Vector3[segmentCount + 1];

        var triangles = new int[segmentCount * 3];

        var uvs = new Vector2[segmentCount + 1];

        var triangleIdx = 0;

        var mesh = new Mesh();

        for (int i = 0; i < vertices.Length; i++)
        {
            //Vertices
            if(i == 0)
            {
                vertices[i] = Vector2.zero;
                continue;
            }

            vertices[i] = points[i - 1];

            //UVs
            uvs[i] = vertices[i];

            //Triangles
            if(i == vertices.Length - 1)
            {
                triangles[triangleIdx] = i;
                triangles[triangleIdx + 1] = 0;
                triangles[triangleIdx + 2] = 1;
            }
            else
            {
                triangles[triangleIdx] = i;
                triangles[triangleIdx + 1] = 0;
                triangles[triangleIdx + 2] = i + 1;

            }

            triangleIdx += 3;
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateBounds();

        return mesh;
    }

    public static Mesh GenerateShapeMesh2D(int segmentCount, float radius, float width)
    {
        var points = GenerateShape2D(segmentCount, radius);

        var vertices = new Vector3[segmentCount * 2];

        var uvs = new Vector2[segmentCount * 2];

        var triangles = new int[segmentCount * 2 * 3];

        var mesh = new Mesh();

        var vrtIdx = 0;
        var triIdx = 0;

        for (int i = 0; i < points.Length; i++)
        {
            vertices[vrtIdx + 1] = points[i];
            vertices[vrtIdx] = points[i] - points[i].normalized * width;

            uvs[i] = vertices[vrtIdx];
            uvs[i + 1] = vertices[vrtIdx + 1];

            if (i == points.Length - 1)
            {
                triangles[triIdx] = vrtIdx;
                triangles[triIdx + 1] = 0;
                triangles[triIdx + 2] = vrtIdx + 1;

                triangles[triIdx + 3] = vrtIdx + 1;
                triangles[triIdx + 4] = 0;
                triangles[triIdx + 5] = 1;
            }
            else
            {
                triangles[triIdx] = vrtIdx;
                triangles[triIdx + 1] = vrtIdx + 2;
                triangles[triIdx + 2] = vrtIdx + 1;

                triangles[triIdx + 3] = vrtIdx + 1;
                triangles[triIdx + 4] = vrtIdx + 2;
                triangles[triIdx + 5] = vrtIdx + 3;
            }

            vrtIdx += 2;
            triIdx += 6;
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();

        return mesh;
    }
}

