using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{

    [ExecuteInEditMode]
    [Range(-3.0f, 3.0f)]
    public float distortion = 0;

    [Range(0, 3)]
    public float scale = 0;

    //public Vector2 center = new Vector2(0.3f, 0.6f);

    //[Range(0.0f, 360.0f)]
    //public float angle = 20.0f;

    public Material material;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {

       // Matrix4x4 rotationMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, angle), Vector3.one);

        //material.SetMatrix("_RotationMatrix", rotationMatrix);
        //material.SetVector("_CenterRadius", new Vector4(center.x, center.y, radius.x, radius.y));

        material.SetFloat("_distortion", distortion);
        material.SetFloat("_scale", scale);

        Graphics.Blit(source, destination, material);

    }

}
