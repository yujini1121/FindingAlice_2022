using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager SM;

    [SerializeField] float _bgmSoundValue;
    float _effectSoundValue;

    bool _bgmSoundMute = false;
    bool _effectSoundMute = false;

    public float bgmSoundValue
    {
        get { return _bgmSoundValue; }
        set { _bgmSoundValue = value; }
    }    
    
    public float effectSoundValue
    {
        get { return _effectSoundValue; }
        set { _effectSoundValue = value; }
    }    
    
    public bool bgmSoundMute
    {
        get { return _bgmSoundMute; }
        set { _bgmSoundMute = value; }
    }    
    
    public bool effectSoundMute
    {
        get { return _effectSoundMute; }
        set { _effectSoundMute = value; }
    }

    private void Awake()
    {
        if (SM == null) SM = this;
        else if (SM != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        bgmSoundValue = 1f;
        effectSoundValue = 1f;
        bgmSoundMute = false;
        effectSoundMute = false;
    }

    void Update()
    {

    }

    public void BgmMute(bool mute)
    {
        if (_bgmSoundMute)
        {
            _bgmSoundMute = false;
            return;
        }
        
        _bgmSoundMute = true;
    }

    public void EffectMute(bool mute)
    {
        if (_effectSoundMute)
        {
            _effectSoundMute = false;
            return;
        }

        _effectSoundMute = true;
    }
}
