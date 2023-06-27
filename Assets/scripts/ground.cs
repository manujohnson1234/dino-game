using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    // Start is called before the first frame update
    private MeshRenderer meshrenderer;

    private void Awake()
    {
        meshrenderer = GetComponent<MeshRenderer> ();
    }

    private void Update()
    {
        float speed = gamemanager.Instance.gameSpeed / transform.localScale.x;
        meshrenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
