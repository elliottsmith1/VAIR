using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
	public Vector3[] nodes;
    public GameObject segments;

    public int indexNum;

    private Vector2 startPos = Vector2.zero;
    private Vector3 initialStep = Vector3.zero;

	public bool IsInitialised = false;

    void Start ()
    {       
		
    }

	public void InitialiseNodeArray()
	{
		Debug.Log (nodes.Length);
		IsInitialised = true;
	}

	public void SetIndexNum(int _indexNum)
	{
		indexNum = _indexNum;
	}
	
    public void SetRoute(Vector3 _node0Pos, Vector3 _node1Pos, Vector3 _node2Pos, Vector3 _nodeNPos)
    {     
		
		nodes[0] = _node0Pos;
		nodes[1] = _node1Pos;
		nodes[2] = _node2Pos;
		nodes[3] = _nodeNPos;
    }

    public Vector3 GetPoint(float t)
    {
       //
		int i;
        if (t >= 1f)
            {
                t = 1f;
                i = nodes.Length - 4;
            }
            else 
            {
                t = Mathf.Clamp01(t) * CurveCount;
                i = (int)t;
                t -= i;
                i *= 3;
            }
		//return transform.TransformPoint(Bezier.GetPoint(nodes[i], nodes[i + 1], nodes[i + 2], nodes[i + 3], t));
		return Bezier.GetPoint(nodes[i], nodes[i + 1], nodes[i + 2], nodes[i + 3], t);
    }

	/// <summary>
	/// Adds 3 nodes to the current curve
	/// </summary>
    public void AddCurve()
    {
        Vector3 node = nodes[nodes.Length - 1];
        System.Array.Resize(ref nodes, nodes.Length + 3);
        node.y += 1f;
        nodes[nodes.Length - 3] = node;
        node.y += 1f;
        nodes[nodes.Length - 2] = node;
        node.y += 1f;
        nodes[nodes.Length - 1] = node;
    }


    public int CurveCount
    {
        get
        {
            return (nodes.Length - 1) / 3;
        }
    }

    public Vector3 GetDirection(float t)
    {
        return GetVelocity(t).normalized;
    }

    //returns magnitude of direction
    public Vector3 GetVelocity(float t)
    {
        int i;
        if (t >= 1f)
        {
            t = 0.5f;
            i = nodes.Length - 4;
        }
        else
        {
            t = Mathf.Clamp01(t) * CurveCount;
            i = (int)t;
            t -= i;
            i *= 3;
        }
		return transform.TransformPoint(Bezier.GetFirstDerivative(
            nodes[i], nodes[i + 1], nodes[i + 2], nodes[i + 3], t)) - transform.position;
    }

    public Vector3 GetNormal3D(float t, Vector3 up)
    {
        Vector3 tng = GetDirection(t);
        Vector3 binormal = Vector3.Cross(up, tng).normalized;
        return Vector3.Cross(tng, binormal);
    }

    public Quaternion GetOrientation3D(float t, Vector3 up)
    {
        Vector3 tng = GetDirection(t);
        Vector3 nrm = GetNormal3D(t, up);
        return Quaternion.LookRotation(tng, nrm);
    }

}
