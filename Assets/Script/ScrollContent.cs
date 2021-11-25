using UnityEngine;

public class ScrollContent : MonoBehaviour {

    private RectTransform rectTransform;

    private RectTransform[] rtChildren;

    private float width, height;

    private float childWidth, childHeight;

    [SerializeField]
    private float itemSpacing;

    [SerializeField]
    private float horizontalMargin, verticalMargin;

    [SerializeField]
    private bool horizontal, vertical;



    public bool Vertical { get { return vertical; } }
    public float ChildHeight { get { return childHeight; } }
    public float ItemSpacing { get { return itemSpacing; } }
    public float Height { get { return height; } }
    public float ChildWidth { get { return childWidth; } }
    public bool Horizontal { get { return horizontal; } }

    public float Width { get { return width; } }

    private void Start() {
        rectTransform = GetComponent<RectTransform>();

        rtChildren = new RectTransform[rectTransform.childCount];

        Debug.Log("child  "+ rtChildren.Length);

        for(int i=0; i< rectTransform.childCount; i++) {
            rtChildren[i] = (RectTransform) rectTransform.GetChild(i);
        }
        width = rectTransform.rect.width - (2 * horizontalMargin);
        height = rectTransform.rect.height - (2 * verticalMargin);

        childWidth = rtChildren[0].rect.width;
        childHeight = rtChildren[0].rect.height;
        
        InitializeContentVertical();
    }

    private void InitializeContentVertical() {
        float originY = 0 - (height * 0.5f);
        float posOffset = childHeight * 0.5f;
        for (int i = 0; i < rtChildren.Length; i++) {
            Vector2 childPos = rtChildren[i].localPosition;
            childPos.y = originY + posOffset + i * (childHeight + itemSpacing);
            rtChildren[i].localPosition = childPos;
        }
    }
}
