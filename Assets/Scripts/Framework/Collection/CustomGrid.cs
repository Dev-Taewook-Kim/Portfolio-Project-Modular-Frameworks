using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrid<T> : CustomArray<T>
{
    //Center of Grid
    protected private Vector3 center;

    //Bounds of Grid
    protected private Vector3 bounds;

    //Extends of Grid 
    //Always half of Bounds
    protected private Vector3 extends;

    //Diameter of Grid Cell
    protected private float diameter;

    private protected CustomGrid() { }

    public CustomGrid(int col, Vector3 center, float diameter) : this(1, col, center, diameter) { }

    public CustomGrid(int row, int col, Vector3 center, float diameter) : this(1, row, col, center, diameter) { }

    public CustomGrid(int dep, int row, int col, Vector3 center, float diameter) : base(dep, row, col)
    {
        this.center = center;
        this.diameter = diameter;

        bounds.x = row * diameter;
        bounds.y = col * diameter;
        bounds.z = dep * diameter;

        extends = bounds * 0.5f;
    }

    private protected int GetIndexOf(Vector2 position)
    {
        var percentX = Mathf.Clamp01((position.x + extends.x) / bounds.x);
        var percentY = Mathf.Clamp01((position.y + extends.y) / bounds.y);

        var x = Mathf.RoundToInt((row - 1) * percentX);
        var y = Mathf.RoundToInt((col - 1) * percentY);

        return GetIndexOf(x, y);
    }

    private protected int GetIndexOf(Vector3 position)
    {
        var percentX = Mathf.Clamp01((position.x + extends.x) / bounds.x);
        var percentY = Mathf.Clamp01((position.y + extends.y) / bounds.y);
        var percentZ = Mathf.Clamp01((position.z + extends.z) / bounds.z);

        var x = Mathf.RoundToInt((row - 1) * percentX);
        var y = Mathf.RoundToInt((col - 1) * percentY);
        var z = Mathf.RoundToInt((dep - 1) * percentZ);

        return GetIndexOf(x, y, z);
    }

    private protected Vector3 GetWorldPosition(int i)
    {
        var index = GetIndexOf(i);

        return GetWorldPosition(index.x, index.y, index.z);
    }

    private protected Vector3 GetWorldPosition(int x, int y, int z)
    {
        var localPositionX = (x - (int)(col * 0.5f)) * diameter;
        var localPositionY = (y - (int)(row * 0.5f)) * diameter;
        var localPositionZ = (z - (int)(dep * 0.5f)) * diameter;

        var worldPosition = new Vector3(localPositionX, localPositionY, localPositionZ) + center;

        return worldPosition;
    }

    //GetLocalPosition()
}
