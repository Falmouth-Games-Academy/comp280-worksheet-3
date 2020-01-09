using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//We need a mesh filter for this example
[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
public class GenerateGeometry : MonoBehaviour
{
    Vector3[] verticess;
    Vector3[] normalss;
    Mesh epicMesh;

    // Start is called before the first frame update
    void OnEnable()
    {
        epicMesh = CreateCube();
    }

    void ManipulateMesh(float waveHeight, float waveSpeed, float distortionAmount)
    {
        verticess = epicMesh.vertices;
        normalss = epicMesh.normals;

        for (var i = 0; i < verticess.Length; ++i)
        {
            verticess[i] += waveHeight * normalss[i] * Mathf.Sin((Time.time * waveSpeed) + (-i * distortionAmount));
        }

        epicMesh.vertices = verticess;
    }

    Mesh CreateCube()
    {
        //Create a new Mesh
        Mesh mesh = new Mesh();
        mesh.name = "GeneratedMesh";

        //Grab the mesh filter and assign the newly created mesh
        GetComponent<MeshFilter>().mesh = mesh;

        //Create vertices, we must have these
        Vector3[] vertices =
        {
            //FRONT
            //Top
            new Vector3(-1, 1, -1),
            new Vector3(1, 1, -1),
            //Bottom
            new Vector3(-1, -1, -1),
            new Vector3(1, -1, -1),

            //BACK
            //Bottom
            new Vector3(1, -1, 1),
            new Vector3(-1, -1, 1),
            //Top
            new Vector3(1, 1, 1),
            new Vector3(-1, 1, 1)
        };

        //Normals and other elements are options but will be required
        //for lighting and texturing to work 
        Vector3[] normals =
        {
            new Vector3(-0.3f, 0.3f, -0.3f),
            new Vector3(0.3f, 0.3f, -0.3f),

            new Vector3(-0.3f, -0.3f, -0.3f),
            new Vector3(0.3f, -0.3f, -0.3f),

            new Vector3(0.3f, -0.3f, 0.3f),
            new Vector3(-0.3f, -0.3f, 0.3f),

            new Vector3(0.3f, 0.3f, 0.3f),
            new Vector3(-0.3f, 0.3f, 0.3f),
        };

        //Indices, called triangles in Unity, these are indices into the Vertex array above
        int[] triangles =
        {
            //Front
            0, 1, 2,
            3, 2, 1,

            //Bottom
            4, 2, 3,
            5, 2, 4,

            //Top
            1, 0, 6,
            6, 0, 7,

            //Right
            1, 6, 3,
            3, 6, 4,

            //Back
            6, 7, 4,
            4, 7, 5,

            //Left
            7, 0, 2,
            2, 5, 7
        };

        //Assign all the values in the mesh
        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.triangles = triangles;

        return mesh;
    }

    void CreatePlane()
    {
        //Create a new Mesh
        Mesh mesh = new Mesh();
        mesh.name = "GeneratedMesh";

        //Grab the mesh filter and assign the newly created mesh
        GetComponent<MeshFilter>().mesh = mesh;

        //Create vertices, we must have these
        Vector3[] vertices =
        {
            new Vector3(-1.0f,-1.0f,0.0f),
            new Vector3(1.0f,-1.0f,0.0f),
            new Vector3(1.0f,1.0f,0.0f),
            new Vector3(-1.0f,1.0f,0.0f)
        };

        //Normals and other elements are options but will be required
        //for lighting and texturing to work 
        Vector3[] normals =
        {
            Vector3.back,Vector3.back,Vector3.back,Vector3.back
        };

        //Indices, called triangles in Unity, these are indices into the Vertex array above
        int[] triangles =            
        { 
            3, 2, 0,
            2, 1, 0 
        };

        //Assign all the values in the mesh
        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.triangles = triangles;

    }
}
