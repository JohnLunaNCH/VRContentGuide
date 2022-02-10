#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class ComfortCameraGizmo : MonoBehaviour
{
    public float distance = 1;

    public float upperMaxPitch = 1.33f;
    public float upperMidPitch = 0.32f;
    public float lowerMidPitch = -0.17f;
    public float lowerMaxPitch = -0.5f;

    public float maxYaw = 0.95f;
    public float midYaw = 0.515f;

    public float minFontSize = 0.0232f;
    public float maxFontSize = 0.0604f;

    [Range (0.01f, 1f)]
    public float step = 0.01f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Handles.Label(//transform.position + 
            transform.TransformPoint(
                new Vector3(0, (distance * 0.1f) + distance * Mathf.Sin(upperMidPitch),distance * Mathf.Cos(upperMidPitch))
                ), 
            "Comfortable");
        DrawFrustum(midYaw * -1f, lowerMidPitch, midYaw, upperMidPitch);

        Gizmos.color = Color.red;
        Handles.Label(//transform.position +
            transform.TransformPoint(
                new Vector3(0, (distance * 0.1f) + distance * Mathf.Sin(upperMaxPitch), distance * Mathf.Cos(upperMidPitch))
                ),
            "Maximum");
        
        DrawFrustum(maxYaw * -1f, lowerMaxPitch, maxYaw, upperMaxPitch);

        DrawFontGuide(1f);
        DrawFontGuide(distance);
    }

    void DrawFontGuide (float distance)
    {
        float minFontHalf = minFontSize * distance * 0.5f;
        float maxFontHalf = maxFontSize * distance * 0.5f;
        Vector3 forwardPos = 
            //transform.position + 
            (Vector3.forward * distance)
            ;
        Gizmos.color = Color.red;
        DrawSquare(minFontHalf, forwardPos, this.transform);
        Gizmos.color = Color.blue;
        DrawSquare(maxFontHalf, forwardPos, this.transform);
    }

    private static void DrawSquare(float fontHalf, Vector3 forwardPos, Transform t)
    {
        Gizmos.DrawLine(
            t.TransformPoint(
            forwardPos + new Vector3(-fontHalf, fontHalf, 0f)
            )
            ,
            t.TransformPoint(
            forwardPos + new Vector3(fontHalf, fontHalf, 0f)
            )
            );
        Gizmos.DrawLine(
            t.TransformPoint(
            forwardPos + new Vector3(fontHalf, fontHalf, 0f)
            )
            ,
            t.TransformPoint(
            forwardPos + new Vector3(fontHalf, -fontHalf, 0f)
            )
            );
        Gizmos.DrawLine(
            t.TransformPoint(
            forwardPos + new Vector3(fontHalf, -fontHalf, 0f)
            )
            ,
            t.TransformPoint(
            forwardPos + new Vector3(-fontHalf, -fontHalf, 0f)
            )
            );
        Gizmos.DrawLine(
            t.TransformPoint(
            forwardPos + new Vector3(-fontHalf, -fontHalf, 0f)
            )
            ,
            t.TransformPoint(
            forwardPos + new Vector3(-fontHalf, fontHalf, 0f)
            )
            );
    }

    void DrawFrustum(float lowerX, float lowerY, float upperX, float upperY)
    {
        float x = lowerX;
        float y = upperY;
        float lastx;
        float lasty;
        while (x < upperX)
        {
            lastx = x;
            lasty = y;
            x += step;
            x = (x > upperX) ? upperX : x;
            Gizmos.DrawLine(
                transform.TransformPoint(
                //transform.position +
                    new Vector3(distance * Mathf.Sin(lastx), distance * Mathf.Sin(lasty), Mathf.Cos(lastx) * distance)
                    )
                    ,
                transform.TransformPoint(
                //transform.position +
                    new Vector3(distance * Mathf.Sin(x), distance * Mathf.Sin(y), Mathf.Cos(x) * distance))
                )
                ;
        }

        Gizmos.DrawLine(transform.position,
            transform.TransformPoint(
            //transform.position +
            new Vector3(distance * Mathf.Sin(x), distance * Mathf.Sin(y), Mathf.Cos(x) * distance))
            )
            ;

        while (y > lowerY)
        {
            lastx = x;
            lasty = y;
            y -= step;
            y = (y < lowerY) ? lowerY : y;
            Gizmos.DrawLine(
                transform.TransformPoint(
                //transform.position +
                    new Vector3(distance * Mathf.Sin(lastx), distance * Mathf.Sin(lasty), Mathf.Cos(lastx) * distance)
                    )
                    ,
                transform.TransformPoint(
                //transform.position +
                    new Vector3(distance * Mathf.Sin(x), distance * Mathf.Sin(y), Mathf.Cos(x) * distance))
                )
                ;
        }
        Gizmos.DrawLine(transform.position,
            transform.TransformPoint(
            //transform.position +
            new Vector3(distance * Mathf.Sin(x), distance * Mathf.Sin(y), Mathf.Cos(x) * distance))
            )
            ;

        while (x > lowerX)
        {
            lastx = x;
            lasty = y;
            x -= step;
            x = (x < lowerX) ? lowerX : x;
            Gizmos.DrawLine(
                transform.TransformPoint(
                //transform.position +
                    new Vector3(distance * Mathf.Sin(lastx), distance * Mathf.Sin(lasty), Mathf.Cos(lastx) * distance)
                    )
                    ,
                transform.TransformPoint(
                //transform.position +
                    new Vector3(distance * Mathf.Sin(x), distance * Mathf.Sin(y), Mathf.Cos(x) * distance))
                )
                ;
        }
        Gizmos.DrawLine(transform.position,
            transform.TransformPoint(
            //transform.position +
            new Vector3(distance * Mathf.Sin(x), distance * Mathf.Sin(y), Mathf.Cos(x) * distance))
            )
            ;

        while (y < upperY)
        {
            lastx = x;
            lasty = y;
            y += step;
            y = (y > upperY) ? upperY : y;
            Gizmos.DrawLine(
                transform.TransformPoint(
                //transform.position +
                    new Vector3(distance * Mathf.Sin(lastx), distance * Mathf.Sin(lasty), Mathf.Cos(lastx) * distance)
                    )
                    ,
                transform.TransformPoint(
                //transform.position +
                    new Vector3(distance * Mathf.Sin(x), distance * Mathf.Sin(y), Mathf.Cos(x) * distance))
                )
                ;
        }

        Gizmos.DrawLine(transform.position,
            transform.TransformPoint(
            //transform.position +
            new Vector3(distance * Mathf.Sin(x), distance * Mathf.Sin(y), Mathf.Cos(x) * distance))
            )
            ;
    }
}
#endif