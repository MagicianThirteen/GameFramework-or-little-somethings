using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// mono控制器
/// </summary>
public class MonoController : MonoBehaviour
{
    public event UnityAction UpdateEvents;

    private void Update()
    {
        if (UpdateEvents != null)
        {
            UpdateEvents();
        }
    }

    public void AddUpdateEventsListener(UnityAction fun)
    {
        UpdateEvents += fun;
    }

    public void RemoveUpdateEventsListener(UnityAction fun)
    {
        UpdateEvents -= fun;
    }
}
