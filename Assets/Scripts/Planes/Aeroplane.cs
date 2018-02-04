using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aeroplane : MonoBehaviour
{
    public int indexNum;

    private BezierCurve[] trajectories;

    public BezierCurve trajectory;

	public void SetIndexNum(int _indexNum)
	{
		indexNum = _indexNum;
	}

	public int getIndexNum()
	{
		return indexNum; 
	}
    

    public Vector2 GetXY()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }
}
