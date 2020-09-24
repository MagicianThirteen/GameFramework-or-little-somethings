using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSort : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        int[] arr = { 2, 8, 9, 10, 4, 5, 6, 7 };
        int n = arr.Length;
        merge_sort(arr, n);
        for(int i = 0; i < arr.Length; i++)
        {
            Debug.Log(arr[i]);
        }
        
    }

    /// <summary>
    /// 归并排序的总入口
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="n"></param>
    void merge_sort(int[] arr,int n)
    {
        int[] tempArr = new int[n];
        msort(arr, tempArr, 0, n - 1);
    }

    /// <summary>
    /// 归并排序
    /// </summary>
    /// <param name="arr">数组</param>
    /// <param name="tempArr">临时存储的排好了序的数组</param>
    /// <param name="left">指向数组的左边，即开头</param>
    /// <param name="right">指向数组的右边，即结尾</param>
    void msort(int[] arr,int[] tempArr,int left,int right)
    {
        if (left < right)//一直到只有一个元素时停止划分
        {
            //找中间点划分
            int mid = (left + right) / 2;
            //递归划分左半区域
            msort(arr, tempArr, left, mid);
            //递归划分右半区域
            msort(arr, tempArr, mid + 1, right);
            //合并已经排序的部分
            merge(arr, tempArr, left, mid, right);

        }
    }

    /// <summary>
    /// 合并排序
    /// </summary>
    /// <param name="arr">要排序的数组</param>
    /// <param name="tempArr">临时存储的数组</param>
    /// <param name="left">要排序的左半部分</param>
    /// <param name="mid">中间点</param>
    /// <param name="right">要排序的右半部分</param>
    void merge(int[] arr,int[] tempArr,int left,int mid,int right)
    {
        //标记左半区的第一个未排序元素
        int l_pos = left;
        //标记右半区第一个未排序元素
        int r_pos = mid + 1;
        //临时数组的元素下标
        int pos = left;

        //合并
        while (l_pos <= mid && r_pos <= right)
        {
            //如果左半区第一个元素更小就把左半区第一个元素放入
            //临时的数组中，如果右半区的更小，就放入右半区的第一个元素
            //然后更小的那个半区的指针l_pos往后挪
            if (arr[l_pos] < arr[r_pos])
            {
                tempArr[pos] = arr[l_pos];
                pos++;
                l_pos++;
            }
            else
            {
                tempArr[pos] = arr[r_pos];
                pos++;
                r_pos++;
            }
        }

        //如果左半区还有剩
        while (l_pos <= mid)
        {
            tempArr[pos] = arr[l_pos];
            pos++;
            l_pos++;
        }
        //如果右半区还有剩
        while (r_pos <= right)
        {
            tempArr[pos] = arr[r_pos];
            pos++;
            r_pos++;
        }

        //把临时数组拷贝到之前的数组
        while (left <= right)
        {
            arr[left] = tempArr[left];
            left++;
        }
    }
    
}
