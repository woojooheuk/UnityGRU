using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController2 : MonoBehaviour
{
    public GameObject roomToSpawn; // 프리펩 할당 변수
    public float distanceFromCamera = 10f; // 메인 카메라로부터의 거리
    private GameObject spawnedPrefab; // 생성된 프리펩 추적 변수
    public Vector3 defaultScale = Vector3.one;
    public InputField widthInputField;
    public InputField heightInputField;
    public Text buttonText;

    private bool isPrefabSpawned = false; // 생성된 프리펩 상태 

    void Start()
    {

    }

    void Update()
    {

    }

    // 버튼 클릭 이벤트 
    public void SpawnRoom()
    {
        // 기존에 생성된 프리펩이 있다면 제거 
        if (spawnedPrefab != null)
        {
            RemovePrefab();
        }

        else
        {
            UpdateScaleFromInputField();
            Debug.Log("Scale: " + defaultScale);

            // 프리펩 생성하고 메인 카메라의 위치로 이동 
            spawnedPrefab = Instantiate(roomToSpawn, transform.position, Quaternion.identity);

            // 프리펩의 크기 조절 
            spawnedPrefab.transform.localScale = defaultScale;

            // 메인 카메라 위치 가져오기 
            Camera mainCamera = Camera.main;

            // 메인 카메라의 위치로 이동 
            spawnedPrefab.transform.position = mainCamera.transform.position + mainCamera.transform.forward * distanceFromCamera;
        }

        if (buttonText != null)
        {
            buttonText.text = (isPrefabSpawned) ? "직사각형" : "지우기";
        }

        isPrefabSpawned = !isPrefabSpawned;
    }

    public void RemovePrefab()
    {
        // 기존에 생성된 프리펩이 있다면 제거 
        if (spawnedPrefab != null)
        {
            Destroy(spawnedPrefab);
            spawnedPrefab = null; // 생성된 프리펩 변수 초기화 
        }
    }

    public void UpdateScaleFromInputField()
    {
        if (widthInputField != null && !string.IsNullOrEmpty(widthInputField.text) &&
        heightInputField != null && !string.IsNullOrEmpty(heightInputField.text))
        {
            float width, height;

            if (float.TryParse(widthInputField.text, out width) && float.TryParse(heightInputField.text, out height))
            {
                defaultScale = new Vector3(width, defaultScale.y, height);
            }

        }
    }
}
