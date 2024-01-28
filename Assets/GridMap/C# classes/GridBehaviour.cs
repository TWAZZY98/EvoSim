using CodeMonkey.Utils;
using Unity.VisualScripting;
using UnityEngine;



public class GridBehaviour
{
    //variables 
    private int height;
    private int width;
    private float cellSize;
    private Vector3 originPostion;
    private int[,] GridArr;
    private TextMesh[,] debugTextArr;
    

    //constructor
    public GridBehaviour(int height, int width, float cellSize, Vector3 originPostion)
    {
        this.height = height;
        this.width = width;
        this.cellSize = cellSize;
        this.originPostion = originPostion;
        //creating the array
        GridArr = new int[width,height];
        debugTextArr = new TextMesh[width,height];
        //debug shows that the array is created
        //array treverse
        //" monkey balls" -gavin 2023

        for (int i = 0; i < GridArr.GetLength(0); i = i +1)
        {
            for (int j = 0; j < GridArr.GetLength(1); j = j + 1)
            {
                debugTextArr[i, j] = UtilsClass.CreateWorldText(GridArr[i, j].ToString(), null, GetWorldPosition(i, j) + new Vector3(cellSize, cellSize) * 0.5f, 20, Color.black, TextAnchor.MiddleCenter);
                //Debug.Log(i + " " + j);

                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1), Color.black, 100f);//debug
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i + 1, j), Color.black, 100f);//debug
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width,height), Color.black, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.black, 100f);

    }
    public void DestroyText()
    {
        for (int i = 0; i < GridArr.GetLength(0); i++)
        {
            for (int j = 0; j < GridArr.GetLength(1); j++)
            {
                debugTextArr[i, j].fontSize = 0;
            }
        }
    }

    public float GetCellSize()
    {
        return cellSize;
    }
    public Vector3 GetOriginPos()
    {
        return originPostion;
    }

    //this function gets the location for each cell
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPostion;
    }
    public int[,] GetInts()
    {

        return GridArr;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        //gives the cell array position based location
        x = Mathf.FloorToInt((worldPosition - originPostion).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPostion).y / cellSize);
    }

    public void SetValue(int x, int y, int value)
    {
        //sets value at grid plus the debug grid gets changed
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            GridArr[x, y] = value;
            debugTextArr[x, y].text = GridArr[x, y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return GridArr[x, y];
        }
        else { return -1; }

    }
    public int GetValue(Vector3 worldPostion)
    {
        int x, y;
        GetXY(worldPostion, out x, out y);
        return GetValue(x, y);

    }

}
