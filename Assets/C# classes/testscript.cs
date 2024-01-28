using CodeMonkey.Utils;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class tests : MonoBehaviour
{
    // Start is called before the first frame update
    private GridBehaviour grid;
    [SerializeField] private Color _baseColor, _colorTwo, _colorThree;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public int height;
    public int width;
    public float cellSize;
    public Vector3 originPos;
    private bool editable;


    void Start()
    {

        grid = new GridBehaviour(height, width, cellSize, originPos);//object is null probably because of the missing GameObject in the Grid Manager class (configure the sprite so it can be used to fill the spots on the grid)
        editable = true;
    }
    private void Update()
    {
        if (editable == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                int x, y;
                Vector3 mousePos = UtilsClass.GetMouseWorldPosition();
                grid.GetXY(mousePos, out x, out y);

                grid.SetValue(mousePos, grid.GetValue(x, y) + 1);

                if (grid.GetValue(mousePos) == 3)
                {
                   Debug.Log("draw grid");
                   drawColour();
                }
                
            }

            if (Input.GetMouseButtonDown(1))
            {

                Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
            }
        }

       
    }
    private void drawColour()
    {
        editable = false;
        for (int i = 0; i < grid.GetInts().GetLength(0); i++)
        {
            string a = "";
            for (int j = 0; j < grid.GetInts().GetLength(1); j++)
            {
                _spriteRenderer.transform.localScale = new Vector2(cellSize, cellSize);
                _spriteRenderer.color = _baseColor;
                
                if (grid.GetValue(i, j) == 0)
                {
                    //_spriteRenderer.color = new Color(0, 0, 0);
                    //Debug.Log("no colour assesed" + i + " " + j);
                }else if (grid.GetValue(i, j) == 1)
                {
                    Debug.Log("Color1");
                    _spriteRenderer.color = _colorTwo;
                }else if (grid.GetValue(i, j) == 2 || grid.GetValue(i, j) ==3)
                {
                    Debug.Log("Color2");
                    _spriteRenderer.color = _colorThree;
                }
                Instantiate(_spriteRenderer, grid.GetWorldPosition(i, j) + (new Vector3(cellSize, cellSize) * 0.5f), transform.rotation);
                a = a + " " + grid.GetValue(i, j);
            }
            Debug.Log(a + "\n");
        }
    }


}
