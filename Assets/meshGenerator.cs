using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using org.mariuszgromada.math.mxparser;

[RequireComponent(typeof(MeshFilter))]
public class meshGenerator : MonoBehaviour
{
    Mesh mesh; //final mesh of the object
    Vector3[] vertices; //array of three dimensonal points in vector space
    int[] triangles; //arrray of 3 points, forming a triangle, of the vertices
    int xSize = 20; //size of the x axis
    int ySize = 20; //size of the y axis
    int axesSize = 30; //length of the axis
    string object_name = "Graph_Gen"; //name of the parent object
    bool draw_giz = true; //will draw gizmos
    bool draw_graph = true; //will draw graph

    string equation = "sqrt(x^2+y^2 + 1)"; //the equation of the custom graph
    bool drawnegz = true; 
    /*Preset Graphs

    -hyperparab1sheet
    -cone
    -xyplane
    -saddle
    -wave
    -dome

    */
    string preset = "wave";

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        drawAxis();
        CreateShape();
        updateMesh();
    }

    //--------------------------------------------------------------------------------------------------------------------  
    void drawAxis()
    {
        create_cylinder("x");
        create_cylinder("y");
        create_cylinder("z");
    }
    public float wave(int x, int y)
    {   
        return (float) (x*x* Math.Sin(y));
    }
    public float dome(int x, int y)
    {
        return (float) (-1*(x*x) - (y*y));
    }
    public float saddle(int x, int y)
    {
        return (float) x*x-y*y;
    }
    public float cone(int x,int y)
    {
        if( x <= 0)
            x++;
        if( y <= 0)
            y++;
        return (float) Math.Sqrt(x*x + y*y);
    }

    public float hyperbolicParaboloidOneSheet(int x,int y)
    {
        return (float) Math.Sqrt((x*x)/9 + (y*y)/25 );
    }

    public float xyplane(int x,int y)
    {
        return (float) x+y;
    }

    
    public float calcZ(int x,int y)
    {
        
        if(preset == "")
            print("Drawing: Custom");
        else
            print("Drawing: " + preset);

        if(preset == "hyperparab1sheet")
        {
            return hyperbolicParaboloidOneSheet(x,y);
        }
        else if(preset == "cone")
        {
            return cone(x,y);
        }
        else if(preset == "xyplane")
        {
            return xyplane(x,y);
        }
        else if(preset == "dome")
        {
            return dome(x,y);
        }
        else if(preset == "wave")
        {
            return wave(x,y);
        }
        else
        {
            Function F = new Function("F(x,y) = " +  equation);
            string strX = "x = " + x.ToString();
            string strY = "y = " + y.ToString();
            Argument xvar = new Argument(strX);
            Argument yvar = new Argument(strY);
            Expression ans = new Expression("F(x,y)",F,xvar,yvar);
            
            return (float) ans.calculate();
        }
        return hyperbolicParaboloidOneSheet(x,y);
    }

    public bool isvalidpreset()
    {
        if(preset == "xyplane")
            return false;
        else if(preset == "cone")
            return false;
        else if(preset == "hyperparab1sheet")
            return true;
        else if(preset == "saddle")
            return true;
        else if(preset == "wave")
            return true;
        else if(preset == "dome")
            return true;
        else if(preset == "") //custom
        {
            if(equation.IndexOf("sqrt") != -1 || equation.IndexOf("log") != -1)
                return false;
        }
        else
            return true;
        return true;
    }

    void CreateShape()
    {
        vertices = new Vector3[ ((xSize + 1) * (ySize + 1))];
        var vertices_counter = 0;

        if(isvalidpreset())
            drawnegz = true;
        else
            drawnegz = false;
        //positive x , y positive z
        if(gameObject.name == object_name + "1")
        {
            for(int y = 0; y<=ySize; y++)
            {
                for(int x = 0; x<=xSize; x++)
                {
                    float z = calcZ(x,y);
                    vertices[vertices_counter] = new Vector3(x, y, z);
                    vertices_counter++;
                }
            }
        }
        //positive x , y negative z
        else if(gameObject.name == object_name + "2" && drawnegz)
        {
            for(int y = 0; y<=ySize; y++)
            {
                for(int x = 0; x<=xSize; x++)
                {
                    float z = calcZ(x,y);
                    vertices[vertices_counter] = new Vector3(x, y, -z);
                    vertices_counter++;
                }
            }
        }
        else if(gameObject.name == object_name + "3")
        {
            //negative x positive y positive z
            for(int y = 0; y<=ySize; y++)
            {
                for(int x = -xSize; x<=0; x++)
                {
                    float z = calcZ(x,y);
                    vertices[vertices_counter] = new Vector3(x, y, z);
                    vertices_counter++;
                }
            }
        }
        else if(gameObject.name == object_name + "4" && drawnegz)
        {
            //negative x positive y negative z
            for(int y = 0; y<=ySize; y++)
            {
                for(int x = -xSize; x<=0; x++)
                {
                    float z = calcZ(x,y);
                    vertices[vertices_counter] = new Vector3(x, y, -z);
                    vertices_counter++;
                }
            }
        }
        else if(gameObject.name == object_name + "5")
        {
            //negative x , y positive z
            for(int y = -ySize; y<=0; y++)
            {
                for(int x = -xSize; x<=0; x++)
                {
                    float z = calcZ(x,y);
                    vertices[vertices_counter] = new Vector3(x, y, z);
                    vertices_counter++;
                }
            }
        }
        else if(gameObject.name == object_name + "6" && drawnegz)
        {
            //negative x , y negative z
            for(int y = -ySize; y<=0; y++)
            {
                for(int x = -xSize; x<=0; x++)
                {
                    float z = calcZ(x,y);
                    vertices[vertices_counter] = new Vector3(x, y, -z);
                    vertices_counter++;
                }
            }
        }
        else if(gameObject.name == object_name + "7")
        {
            //positive x , negative y, positive z
            for(int y = -ySize; y<=0; y++)
            {
                for(int x = 0; x<=xSize; x++)
                {
                    float z = calcZ(x,y);
                    vertices[vertices_counter] = new Vector3(x, y, z);
                    vertices_counter++;
                }
            }
        }
        else if(gameObject.name == object_name + "8" && drawnegz)
        {
            //positive x , negative y negative z
            for(int y = -ySize; y<=0; y++)
            {
                for(int x = 0; x<=xSize; x++)
                {
                    float z = calcZ(x,y);
                    vertices[vertices_counter] = new Vector3(x, y, -z);
                    vertices_counter++;
                }
            }
        }

        //draws graph--------------------------------------------------------------------------------------------------
        triangles = new int[(xSize*ySize*6)];
        int vert = 0;
        int tris = 0;    
        if(draw_graph)
        {
            for(int y = 0; y<ySize; y++)
            {
                for(int x = 0; x<xSize; x++)
                {
                    triangles[tris + 0] = vert + 0;
                    triangles[tris + 1] = vert + xSize + 1;
                    triangles[tris + 2] = vert + 1;
                    triangles[tris + 3] = vert + 1;
                    triangles[tris + 4] = vert + xSize + 1;
                    triangles[tris + 5] = vert + xSize + 2;

                    vert++;
                    tris+=6;
                }
                vert++;
            }
        }
    }

    void updateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    private void OnDrawGizmos() {

        if(draw_giz)
        {
            if(vertices == null)
                return;
            
            for(int i = 0; i<vertices.Length; i++)
            {
                Gizmos.DrawSphere(vertices[i], .1f);
            }
        }

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Vector3 center = new Vector3(0,0,0);
        Vector3 yAxisVector = new Vector3(0,50,0);

        Gizmos.color = Color.green;
        //Gizmos.DrawCube(center, new Vector3(1, 50, 1)); //z plane
        Gizmos.color = Color.red;
        //Gizmos.DrawCube(center, new Vector3(50, 1, 1)); //x plane
        Gizmos.color = Color.blue;
        //Gizmos.DrawCube(center, new Vector3(1, 1, 50)); //y plane
    }

    public void create_cylinder(string axe) {
    
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cylinder.transform.position = new Vector3(0, 0, 0);
        
        float linethickness = (float)0.3;
        if(axe == "x")
        {
            cylinder.GetComponent<Renderer>().material.color = new Color (255,0,0,1);
            cylinder.transform.localScale = new Vector3(axesSize*2, linethickness, linethickness);
        }
        else if(axe == "y")
        {
            cylinder.GetComponent<Renderer>().material.color = new Color (0,255,0,1);
            cylinder.transform.localScale = new Vector3(linethickness, axesSize*2, linethickness);
        }
        else if(axe == "z")
        {
            cylinder.GetComponent<Renderer>().material.color = new Color (0,0,255,1);
            cylinder.transform.localScale = new Vector3(linethickness, linethickness ,axesSize*2);
        }
    }


}
