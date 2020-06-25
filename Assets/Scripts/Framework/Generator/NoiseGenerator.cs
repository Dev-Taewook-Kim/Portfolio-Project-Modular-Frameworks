using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NoiseGenerator
{
    public static float[,] GeneratePerlinNoiseValues2D(int resolution, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset = default)
    {
        var noiseValues = new float[resolution, resolution];

        if (scale <= 0) scale = 0.0001f;

        if (octaves < 1) octaves = 1;

        System.Random prng = new System.Random(seed);

        var octaveOffsets = new Vector2[octaves];

        for (int i = 0; i < octaveOffsets.Length; i++)
        {
            var offsetX = prng.Next(-100000, 100000) + offset.x;
            var offsetY = prng.Next(-100000, 100000) + offset.y;

            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        var maxNoiseValue = float.MinValue;

        var minNoiseValue = float.MaxValue;

        var halfResolution = resolution * 0.5f;

        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {
                var amplitude = 1f;

                var frequency = 1f;

                var noiseValue = 0f;

                for (int i = 0; i < octaves; i++)
                {
                    var positionX = (x - halfResolution + octaveOffsets[i].x) / scale * frequency;

                    var positionY = (y - halfResolution + octaveOffsets[i].y) / scale * frequency;

                    var perlinValue = Mathf.PerlinNoise(positionX, positionY) * 2 - 1;

                    noiseValue += perlinValue * amplitude;

                    amplitude *= persistance;

                    frequency *= lacunarity;
                }

                if (noiseValue > maxNoiseValue)
                    maxNoiseValue = noiseValue;
                else if (noiseValue < minNoiseValue)
                    minNoiseValue = noiseValue;

                noiseValues[x, y] = noiseValue;
            }
        }

        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {
                noiseValues[x, y] = Mathf.InverseLerp(minNoiseValue, maxNoiseValue, noiseValues[x, y]);
            }
        }

        return noiseValues;
    }
}
