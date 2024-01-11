using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
    public GameObject scrollView;
    private bool isScrollViewOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        // 시작시 ScrollView 비활성화 
        if (scrollView != null)
        {
            scrollView.SetActive(false);
        }
    }

    public void ToggleScrollView()
    {
        // 버튼 클릭시에 Scroll View 활성화 또는 비활성화 
        if (scrollView != null)
        {
            isScrollViewOpen = !isScrollViewOpen;
            scrollView.SetActive(!scrollView.activeSelf);
        }
    }
}
