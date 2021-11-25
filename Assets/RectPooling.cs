using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectPooling : MonoBehaviour
{
    //[SerializeField] private int size = 2;
    [SerializeField] private int poolSize = 3;

    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject parentContent;

    public List<GameObject> poolList = new List<GameObject>();
    //private string[] newColors = {"red","blue", "yellow", "pink", "green"};

    private ScrollRect scrollRect;
 

    private void Awake() {
        scrollRect = GetComponent<ScrollRect>();
        
    }

    private void Start() {
        for(int i=0; i<poolSize; i++) {
            GameObject newObj = Instantiate(prefab, parentContent.transform);
            newObj.name = newObj.name.Replace("(Clone)", " " + i.ToString());
            byte a = (byte)Random.Range(0, 255);
            byte b = (byte)Random.Range(0, 255);
            byte c = (byte)Random.Range(0, 255);
            byte d = (byte)Random.Range(0, 255);
            newObj.GetComponent<Image>().color = new Color32(a,b,c,b);
            poolList.Add(newObj);
        }
    }

    private void Update() {
        

    }
}
