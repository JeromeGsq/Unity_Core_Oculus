using UnityEngine;
using System.Collections;
using UnityEditor;

public class AnchorGizmo : MonoBehaviour
{
    [SerializeField]
    private string text;

    [SerializeField]
    private int fontSize = 140;

    [SerializeField]
    private Color textColor = Color.white;

    public e_AnchorType AnchorType = e_AnchorType.Sphere;
    public float SizeGizmo = 0.02f;
    public Vector3 SizeRectangleGizmo;
    public Color ColorGizmo = Color.white;

    [Space(20)]

    public bool ArrowDirection;
    public float SizeArrow = 0.2f;

    private GUIStyle style;

    void OnDrawGizmos()
    {
        Gizmos.color = ColorGizmo;
        switch (AnchorType)
        {
            case e_AnchorType.Cube:
                Gizmos.DrawCube(transform.position, new Vector3(SizeGizmo, SizeGizmo, SizeGizmo));
                break;

            case e_AnchorType.Rectangle:
                Gizmos.DrawCube(transform.position, new Vector3(SizeRectangleGizmo.x, SizeRectangleGizmo.y, SizeRectangleGizmo.z));
                break;

            case e_AnchorType.Sphere:
                Gizmos.DrawSphere(transform.position, SizeGizmo);
                break;

            case e_AnchorType.Cone:
                DebugExtension.DrawCone(transform.position - transform.forward * SizeRectangleGizmo.x, transform.forward * 2 * SizeRectangleGizmo.y, ColorGizmo, SizeRectangleGizmo.z * 100);
                break;

            case e_AnchorType.ConeUp:
                DebugExtension.DrawCone(transform.position + transform.up * SizeRectangleGizmo.x, -transform.up * 2 * SizeRectangleGizmo.y, ColorGizmo, SizeRectangleGizmo.z * 100);
                break;

            case e_AnchorType.ConeRight:
                DebugExtension.DrawCone(transform.position + transform.right * SizeRectangleGizmo.x, -transform.right * 2 * SizeRectangleGizmo.y, ColorGizmo, SizeRectangleGizmo.z * 100);
                break;

            case e_AnchorType.BoxCollider:
                var collider = this.GetComponent<BoxCollider2D>();
                if (collider == null)
                {
                    collider = this.GetComponentInChildren<BoxCollider2D>();
                }
                Gizmos.DrawCube(transform.position, new Vector3(collider.size.x, collider.size.y, 1));
                break;
        }

#if UNITY_EDITOR
        style = new GUIStyle();
        style.normal.textColor = this.textColor;
        style.fontSize = Mathf.FloorToInt(fontSize / SceneView.currentDrawingSceneView.camera.orthographicSize);
        style.alignment = TextAnchor.MiddleCenter;

        if (string.IsNullOrEmpty(this.text))
        {
            Handles.Label(transform.position + Vector3.up * 0.2f + Vector3.up * this.SizeGizmo - (Vector3.right * (this.text.Length * 0.05f)) / 2, this.text, style);
        }
#endif

        if (ArrowDirection)
        {
            Gizmos.color = ColorGizmo;
            Gizmos.DrawLine(transform.position, (transform.position - transform.forward * SizeArrow));
            Gizmos.DrawLine((transform.position - transform.forward * SizeArrow), transform.position - (transform.right * SizeArrow / 2));
            Gizmos.DrawLine((transform.position - transform.forward * SizeArrow), transform.position + (transform.right * SizeArrow / 2));
        }
    }
}

public enum e_AnchorType
{
    Cube,
    Rectangle,
    Sphere,
    Cone,
    ConeUp,
    ConeRight,
    BoxCollider,
}
