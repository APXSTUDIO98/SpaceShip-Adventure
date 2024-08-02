using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private MeshRenderer mesh;
    public float speed;
    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }
  

    // Update is called once per frame
    void Update()
    {
        mesh.material.mainTextureOffset += new Vector2(0, speed + Time.deltaTime);
    }
}
