using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 拖拽物体，挂到游戏物体上测试
/// </summary>
public class TestDrag : MonoBehaviour
{
 

    private Vector3 screenPos;
    private Vector3 offset;
    void OnMouseDown()
    {
        screenPos = Camera.main.WorldToScreenPoint(transform.position);//获取物体的屏幕坐标     
        offset = screenPos - Input.mousePosition;//获取物体与鼠标在屏幕上的偏移量
        Debug.Log("物体世界坐标：" + transform.position);
        Debug.Log("物体的屏幕坐标：" + screenPos);
        Debug.Log("鼠标点击坐标：" + Input.mousePosition);
        Debug.Log("offset: " + offset);
    }
    void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + offset);//将拖拽后的物体屏幕坐标还原为世界坐标
        Debug.Log("物体世界坐标：" + transform.position);
        Debug.Log("鼠标点击坐标：" + Input.mousePosition);
        Debug.Log("offset: " + offset);
    }
}
