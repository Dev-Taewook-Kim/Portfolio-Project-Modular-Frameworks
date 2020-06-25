using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomArray<T> : IEnumerable, IEnumerator
{
    private protected T[] data = null;

    private protected int position = -1;

    private protected int dep = 0;

    private protected int row = 0;

    private protected int col = 0;

    public T this[int i]
    {// [col]
        get { return data[i]; }
        set { data[i] = value; }
    }

    public T this[int j, int i]
    {// [row, col]
        get { return data[GetIndexOf(j, i)]; }
        set { data[GetIndexOf(j, i)] = value; }
    }

    public T this[int k, int j, int i]
    {// [dep, row, col]
        get { return data[GetIndexOf(k, j, i)]; }
        set { data[GetIndexOf(k, j, i)] = value; }
    }

    private protected CustomArray() { }

    public CustomArray(int col) : this(1, col) { }

    public CustomArray(int row, int col) : this(1, row, col) { }

    public CustomArray(int dep, int row, int col)
    {
        this.dep = dep;
        this.row = row;
        this.col = col;

        this.data = new T[dep * row * col];
    }

    public object Current => data[position];

    public IEnumerator GetEnumerator() => this;

    public bool MoveNext() => ++position < data.Length;

    public void Reset() => position = 0;

    public int Length => dep * row * col;

    public int GetLength(int i)
    {
        var length = -1;

        if (i == 0)
            length = dep;
        else if (i == 1)
            length = row;
        else if (i == 2)
            length = col;

        return length;
    }

    private protected int GetIndexOf(int j, int i)
    {
        return (j * col) + i;
    }

    private protected int GetIndexOf(int k, int j, int i)
    {
        return (k * dep * col) + (j * col) + i;
    }

    private protected Vector3Int GetIndexOf(int i)
    {
        return new Vector3Int(i % dep, i / (row * dep), (i / dep) % row);
    }

    public void DestroyAll()
    {
        if (!typeof(T).IsSubclassOf(typeof(UnityEngine.Object)))
        {
            Debug.LogError($"Type {typeof(T).FullName} is not Driven by {typeof(UnityEngine.Object).FullName}");
            Debug.LogError($"Type {typeof(T).FullName} can not be destroied");

            return;
        }

        for (int i = 0; i < Length; i++)
        {
            var go = data[i] as UnityEngine.Object;
            data[i] = default;
            UnityEngine.Object.Destroy(go,1f);
        }
    }

    public void ForEachAction(Action<T> action)
    {
        for (int i = 0; i < Length; i++)
        {
            action(data[i]);
        }
    }
}
