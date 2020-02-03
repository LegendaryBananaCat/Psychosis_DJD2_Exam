using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDraw : MonoBehaviour
{
    public GameObject brush;
    public float brushSize = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(Ray, out hit))
            {
                var go = Instantiate(brush, hit.point + hit.collider.gameObject.transform.up * 0.01f, Quaternion.identity, transform);
                go.transform.localScale = Vector3.one * brushSize;
                go.transform.forward = hit.collider.gameObject.transform.up;
            }
        }

    }

    public void Save()
    {
        Debug.Log("Saved");
    }
}
