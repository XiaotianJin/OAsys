using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class GridLayoutConfig : MonoBehaviour
{
    #region Para
    private int _columns;
    private int _rows;
    public string TxtPath;
    public GameObject Item;

    private List<GameObject> _items;
    private float _width;
    private float _height;
    private Vector2 _cellSize;
    private JsonData _tableData;
    #endregion

    // Use this for initialization
    void Start ()
    {
		Initialize();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    #region InternalCall

    private void Initialize()
    {
        _columns = 0;
        _rows = 0;
        _items = new List<GameObject>();
        _width = gameObject.GetComponent<RectTransform>().sizeDelta.x;
        _height = gameObject.GetComponent<RectTransform>().sizeDelta.y;
        _tableData = JsonMapper.ToObject(File.ReadAllText(TxtPath));
        if (_tableData.Count == 0)
        {
            Debug.Log("文件内没有json数据！");
            return;
        }
        foreach (JsonData eachData in _tableData)
        {
            foreach (KeyValuePair<string, JsonData> eachPair in eachData)
            {
                GameObject item = Instantiate(Item, transform);
                item.name = eachPair.Value.ToString();
                item.GetComponent<Text>().text = eachPair.Value.ToString();
                _items.Add(item);
                _columns++;
            }
            _rows++;
        }
        _columns = _columns / _rows;
        _cellSize = new Vector2(_width / _columns, gameObject.GetComponent<GridLayoutGroup>().cellSize.y);
        gameObject.GetComponent<GridLayoutGroup>().cellSize = _cellSize;
    }

    #endregion
}
