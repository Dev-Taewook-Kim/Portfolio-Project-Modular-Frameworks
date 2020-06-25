using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomMath
{
    public static Vector2Int GetIndexOf(int index, int blockWidth)
    {
        var x = index % blockWidth;
        var y = index / blockWidth;

        return new Vector2Int(x, y);
    }

    public static int GetIndexOf(Vector2Int index, int blockWidth)
    {
        return (index.y * blockWidth) + index.x;
    }

    private static Vector3 GetWorldPositionOf(int index, int blockWidth, int blockHeight, float cellDiameter)
    {
        return GetWorldPositionOf(GetIndexOf(index, blockWidth), blockWidth, blockHeight, cellDiameter);
    }

    private static Vector3 GetWorldPositionOf(Vector2Int index, int blockWidth, int blockHeight, float cellDiameter)
    {
        var xCoord = (index.x - Mathf.Floor(blockWidth * 0.5f)) * cellDiameter;
        var yCoord = (index.y - Mathf.Floor(blockHeight * 0.5f)) * cellDiameter;

        return new Vector3(xCoord, yCoord);
    }

    public static bool IsInRange(Vector2Int index, int blockWidth, int blockHeight)
    {
        return (index.x >= 0 && index.x < blockWidth) && (index.y >= 0 && index.y < blockHeight);
        //return (index.x < 0 || index.x >= blockWidth) || (index.y < 0 || index.y >= blockHeight);
    }
}