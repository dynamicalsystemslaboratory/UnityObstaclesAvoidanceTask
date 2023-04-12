using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraDistortion : MonoBehaviour
{
    public Material material;
    [Header("开关")]
    public bool toggle = true;
    [Header("坐标范围0-1")]
    public Vector2 point = new Vector2(0.5f,0.5f);
    [Header("半径范围0-1")]
    public float radius = 0.1f;
    [Header("横轴扭曲幅度增加")]
    public float xAdd = 0.05f;
    [Header("纵轴扭曲幅度]增加")]
    public float yAdd = 0.03f;
    [Header("扭曲长度增加")]
    public float radiusA = 0.03f;
    [Header("凸起范围")]
    public float upvalue = 1f;

    private void Awake()
    {
        if(material==null)
        {
            material = Resources.Load<Material>("Material/distortionMaterial") as Material;
        }
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
        if(Screen.height> Screen.width)
        {
            material.SetFloat("_Ratio", Screen.height / Screen.width);
        }
        else
        {
            material.SetFloat("_Ratio", Screen.width / Screen.height);
        }
        
        material.SetFloat("radius", radius);
        material.SetFloat("xAdd", xAdd);
        material.SetFloat("xAdd", xAdd);
        material.SetFloat("yAdd", yAdd);
        material.SetFloat("yAdd", yAdd);
        material.SetFloat("radiusA", radiusA);
        material.SetFloat("upvalue", upvalue);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
    {
        if(toggle)
        {
            Graphics.Blit(sourceTexture, destTexture, material);
        }
        else
        {
            Graphics.Blit(sourceTexture, destTexture);
        }
        
    }
}
