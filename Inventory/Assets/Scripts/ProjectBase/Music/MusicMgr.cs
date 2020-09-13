using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 音效控制模块
/// </summary>
public class MusicMgr : BaseManager<MusicMgr>
{
    //播放背景音乐的组件，背景音乐一般唯一。
    private AudioSource bkMusic = null;
    //背景音乐声音的大小
    private float bkValue = 1;

    //播放音效容器，因为音效是一个游戏物体，上面挂载了很多的audiosource
    private GameObject soundObj = null;
    private List<AudioSource> soundList = new List<AudioSource>();
    //音效音量
    private float soundValue = 1;

    public MusicMgr()
    {
        MonoMgr.GetInstance().AddUpdateEventsListener(CheckSoundsUpdate);
    }

    //不是必要循环的音乐可以移除，所以要再update中不断检测。
    void CheckSoundsUpdate()
    {
        //倒着移除是为了不破坏迭代器
        for(int i = soundList.Count - 1; i >= 0; --i)
        {
            if (!soundList[i].isPlaying)//不是正在播放
            {
               
                GameObject.Destroy(soundList[i]);
                soundList.RemoveAt(i);

            }
        }
    }


    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="name"></param>
    public void PlayBKMusic(string name)
    {
        //如果没有，先生成背景音乐的组件
        if (bkMusic == null)
        {
            GameObject obj = new GameObject("BKMusic");
            bkMusic = obj.AddComponent<AudioSource>();
        }
        //异步加载背景音乐资源,并播放（因为背景音通常比较大）
        ResMgr.GetInstance().LoadResAsync<AudioClip>("Music/BK/" + name, (clip) => {
            bkMusic.clip = clip;
            bkMusic.volume = bkValue;//设置背景音乐音量大小
            bkMusic.loop = true;//背景音乐一般是循环的
            bkMusic.Play();
        });
    }

   

    /// <summary>
    /// 暂停背景音乐，如果是后面再播放的话，是从之前暂停的部分再播放的不是从头播放
    /// </summary>
    public void PauseBKMusic()
    {
        if (bkMusic == null)
        {
            return;
        }
        bkMusic.Pause(); 
    }

    /// <summary>
    /// 停止播放背景音乐，如果后面再播放的话，是从头播放
    /// </summary>
    public void StopBKMusic()
    {
        if (bkMusic == null)
        {
            return;
        }
        bkMusic.Stop();
    }

    /// <summary>
    /// 改变背景音乐，音量大小
    /// </summary>
    /// <param name="v"></param>
    public void ChangeBKValue(float v)
    {
        if (bkMusic == null)
        {
            return;
        }
        bkValue = v;
        bkMusic.volume = bkValue;
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="name">音效路径</param>
    /// <param name="callBack">为了方便外部知道是哪个audiosource组件，以供外部操作比如停止某个音效</param>
    public void PlaySound(string name,bool isLoop,UnityAction<AudioSource> callBack=null)
    {
        //创建游戏物体用来承载音效
        if (soundObj == null)
        {
            soundObj = new GameObject("Sounds");
        }
        
        //异步加载音效音乐资源,并播放,这里的文件夹可以根据需要细分
        ResMgr.GetInstance().LoadResAsync<AudioClip>("Music/Sounds/" + name, (clip) => {
            //给游戏物体添加aduiosource组件
            AudioSource source = soundObj.AddComponent<AudioSource>();
            source.clip = clip;
            source.loop = isLoop;//是否循环播放音效
            source.volume = soundValue;//设置背景音乐音量大小
            source.Play();
            //添加进音效容器list
            soundList.Add(source);
            //给外部调用source
            if (callBack != null)
            {
                callBack(source);
            }
            
        });
    }

    /// <summary>
    /// 停止音效
    /// </summary>
    /// 因为音效都是通过AudioSource组件管理的，所以可以用这个作为参数                                                                                      
    public void StopSound(AudioSource source)
    {
        if (soundList.Contains(source))
        {
            //不用了就移除，停止播放，然后销毁
            soundList.Remove(source);
            source.Stop();
            GameObject.Destroy(source);
        }
    }

    /// <summary>
    /// 改变所有音效音量
    /// </summary>
    /// <param name="value"></param>
    public void ChangeSoundValue(float value)
    {
        soundValue = value;
        for(int i = 0; i < soundList.Count; i++)
        {
            soundList[i].volume = soundValue;
        }
    }
}
