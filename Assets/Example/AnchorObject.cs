using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorObject : MonoBehaviour
{
    [SerializeField] AnchorEdge m_AnchorEdge;
    [SerializeField] RectTransform m_Rect;
    [SerializeField] Vector2 m_Offset;
    float m_Distance;
    
    public void SetLocalPointRefToObject()
    {        
        Vector2 _screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        _ = RectTransformUtility.ScreenPointToLocalPointInRectangle(m_Rect, _screenPoint, null, out Vector2 localPoint);
        if (m_AnchorEdge == AnchorEdge.Left)
        {
            m_Offset = new Vector2(m_Rect.rect.width / 2 * -1, m_Rect.rect.height / 2) - localPoint;
        }
        else if (m_AnchorEdge == AnchorEdge.Right)
        {
            m_Offset = new Vector2(m_Rect.rect.width / 2, m_Rect.rect.height / 2) - localPoint;
        }
    }
    void Start()
    {        
        m_Distance = Camera.main.transform.InverseTransformPoint(transform.position).z;
    }
    Vector2 localRectPoint;
    private void Update()
    {
        if (m_Rect != null)
        {
            if (m_AnchorEdge == AnchorEdge.Left)
            {
                localRectPoint = new Vector2(m_Rect.rect.width / 2 * -1, m_Rect.rect.height / 2) - m_Offset;
            }
            else
            {
                localRectPoint = new Vector2(m_Rect.rect.width / 2, m_Rect.rect.height / 2) - m_Offset;
            }

            Vector3 worldPosition = m_Rect.TransformPoint(localRectPoint);
            Vector3 screenPoint = RectTransformUtility.WorldToScreenPoint(null, worldPosition);

            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, m_Distance));
        }
    }
}
public enum AnchorEdge
{
    Left, Right
}
