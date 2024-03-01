using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCube3D : MonoBehaviour
{
    private LineRenderer cubeLines;
    private Vector3 centerCube = new();
    private Vector3[] vertices = new Vector3[]
    {
        new Vector3(-0.5f, -0.5f, -0.5f), // Vertex 0
        new Vector3(0.5f, -0.5f, -0.5f),  // Vertex 1
        new Vector3(0.5f, -0.5f, 0.5f),   // Vertex 2
        new Vector3(-0.5f, -0.5f, 0.5f),  // Vertex 3
        new Vector3(-0.5f, 0.5f, -0.5f),  // Vertex 4
        new Vector3(0.5f, 0.5f, -0.5f),   // Vertex 5
        new Vector3(0.5f, 0.5f, 0.5f),    // Vertex 6
        new Vector3(-0.5f, 0.5f, 0.5f)    // Vertex 7
    };

    private void Start()
    {
        cubeLines = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        OriginalVertices();
        PositionCube();
        RotationCube();
        DrawCube();
    }

    private void OriginalVertices()
    {
        vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, -0.5f), // Vertex 0
            new Vector3(0.5f, -0.5f, -0.5f),  // Vertex 1
            new Vector3(0.5f, -0.5f, 0.5f),   // Vertex 2
            new Vector3(-0.5f, -0.5f, 0.5f),  // Vertex 3
            new Vector3(-0.5f, 0.5f, -0.5f),  // Vertex 4
            new Vector3(0.5f, 0.5f, -0.5f),   // Vertex 5
            new Vector3(0.5f, 0.5f, 0.5f),    // Vertex 6
            new Vector3(-0.5f, 0.5f, 0.5f)    // Vertex 7
        };
    }

    private void DrawCube()
    {
        // vertex on linerederer
        cubeLines.positionCount = vertices.Length;
        cubeLines.SetPositions(vertices);

        // define lines that conect vertex 
        int[] lineIndexs = new int[]
        {
            0,1,1,2,2,3,3,0, // base rectangle
            4,5,5,6,6,7,7,4, // upper face
            0,4,1,5,2,6,3,7 // vertical lines
        };

        // draw lines
        cubeLines.positionCount = lineIndexs.Length;
        for( int i = 0; i < lineIndexs.Length; i++ )
        {
            cubeLines.SetPosition(i, vertices[lineIndexs[i]]);
        }
    }

    private void PositionCube()
    {
        // center the cube
        centerCube = transform.position;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] += centerCube;
        }
    }

    private void RotationCube()
    {
        // rotate the cube
        for(int i = 0;i < vertices.Length; i++)
        {
            vertices[i] = QuaternionManager.instance.RotateQuaterion(vertices[i]);
        }
    }
}
