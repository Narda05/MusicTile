using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarGeneration : MonoBehaviour
{
    public GameObject[] barPrefabs; 
    public RectTransform panelMusic; //Generate bars in the panel
    public int maxBars = 6; 
    public float barSpacing = 10f;

    public RectTransform transformRef;

    List<GameObject> bars = new List<GameObject>();

    void Start()
    {
        GenerateBars();
    }

    public void GenerateBars()
    {
        Debug.Log("Function called!");
        float panelHeight = panelMusic.rect.height; 
        float barHeight = barPrefabs[0].GetComponent<RectTransform>().rect.height; 
        int numBars = Mathf.FloorToInt(panelHeight / (barHeight + barSpacing)); // How many bars can fit in the panel

        numBars = maxBars;

        for (int i = 0; i < numBars; i++)
        {
            GameObject randomBarPrefab = barPrefabs[Random.Range(0, barPrefabs.Length)];

            GameObject newBar = Instantiate(randomBarPrefab, transformRef);
            newBar.transform.localPosition = new Vector3(0, i * (barHeight + barSpacing), 0);

            bars.Add(newBar);
        }

        foreach (GameObject bar in bars)
        {
            bar.transform.position = new Vector3(bar.transform.position.x, bar.transform.position.y + 100, bar.transform.position.z);
        }
    }
}