using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Static : MonoBehaviour {

    public Texture2D[] frames;
    public int fps = 60;

    private void Start()
    {

        GetComponent<RawImage>().texture = frames[0];

    }

    private void Update()
    {

        int index = (int)(Time.time * fps) % frames.Length;
        GetComponent<RawImage>().texture = frames[index];

    }

}
