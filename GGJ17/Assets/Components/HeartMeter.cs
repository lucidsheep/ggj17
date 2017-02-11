using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartMeter : MonoBehaviour
{
	public GameObject fullHeart;
	public GameObject emptyHeart;
	public GameObject ship;

	public List<GameObject> allHearts;

	Hull shipHull;
	// Use this for initialization
	void Start ()
	{
		shipHull = ship.GetComponent<Hull>();
		allHearts = new List<GameObject>();
        genHearts();
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (allHearts.Count < shipHull.maxHP)
            genHearts();
		for(int i = 0; i < shipHull.maxHP; i++)
		{
			allHearts[i].SetActive(shipHull.GetHP() - 1 >= i);
		}
	}

    void genHearts()
    {
        foreach(GameObject g in allHearts)
        {
            Destroy(g);
        }
        allHearts = new List<GameObject>();
        var currentX = 0f;
        for (int i = 0; i < shipHull.maxHP; i++)
        {
            Vector3 pos = new Vector3(currentX, 0f, 0f);
            GameObject newEmpty = (GameObject)Instantiate(emptyHeart);
            newEmpty.transform.parent = this.transform;
            newEmpty.transform.localPosition = pos;

            GameObject newFull = (GameObject)Instantiate(fullHeart);
            newFull.transform.parent = this.transform;
            newFull.transform.localPosition = pos;
            allHearts.Add(newFull);

            currentX += 1.5f;
        }
    }
}

