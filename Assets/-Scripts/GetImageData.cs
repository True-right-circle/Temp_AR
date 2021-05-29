using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GetImageData : MonoBehaviour
{
    public Texture2D sourceTex;
    Texture2D destTex;
    public LineRenderer lr;
    List<Vector3> points;

    private void Awake()
    {
        points = new List<Vector3>();
        //sourceTex.isReadable = true;

    }

    Texture2D duplicateTexture(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }

    void Start()
    {
        Texture2D Readenable = duplicateTexture(sourceTex);
        for (int i = 0; i < Readenable.width; ++i)
        {
            for (int j = 0; j < Readenable.height; j++)
            {
                Color pixel = Readenable.GetPixel(i, j);
                if(!(pixel.r+pixel.g+pixel.b==3) && (pixel.r + pixel.g + pixel.b)<=0.5f)
                {
                    points.Add(new Vector3(i, j, 0));
                }
            }
        }
    }

}
