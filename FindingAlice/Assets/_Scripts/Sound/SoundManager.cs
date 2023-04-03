using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
	public static SoundManager SM;

	[SerializeField] SerializableDictionary<int, AudioClip> BGM_Dic = new SerializableDictionary<int, AudioClip>();
	[SerializeField] SerializableDictionary<int, AudioClip> SFX_Dic = new SerializableDictionary<int, AudioClip>();

	[SerializeField] float _bgmSoundValue;
	[SerializeField] float _effectSoundValue;

	[SerializeField] bool _bgmSoundMute = false;
	[SerializeField] bool _effectSoundMute = false;

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
		bgmSoundValue = DataController.Instance.gameData.bgmValue;
		effectSoundValue = DataController.Instance.gameData.effectValue;
		bgmSoundMute = DataController.Instance.gameData.bgmMute;
		effectSoundMute = DataController.Instance.gameData.effectMute;

		bgmSlider.value = bgmSoundValue;
		effectSlider.value = effectSoundValue;
	}

	[SerializeField] Slider bgmSlider;
	[SerializeField] Slider effectSlider;

	private void Update()
	{
		if (bgmSlider != null)
		{
			if (bgmSlider.isActiveAndEnabled)
			{
				bgmSoundValue = bgmSlider.value;
				bgmSlider.value = Mathf.Round(bgmSoundValue * 4) / 4;
			}
		}
		else if (SceneManager.GetActiveScene().name == "SelectChapterScene"
			&& GameObject.Find("Option").transform.GetChild(0).gameObject.activeSelf == true)
		{
			bgmSlider = GameObject.Find("BgmSlider").GetComponent<Slider>();
		}
		if (effectSlider != null)
		{
			if (effectSlider.isActiveAndEnabled)
			{
				effectSoundValue = effectSlider.value;
				effectSlider.value = Mathf.Round(effectSoundValue * 4) / 4;
			}
		}
		else if (SceneManager.GetActiveScene().name == "SelectChapterScene"
			&& GameObject.Find("Option").transform.GetChild(0).gameObject.activeSelf == true)
		{
			effectSlider = GameObject.Find("SeSlider").GetComponent<Slider>();
		}

		DataController.Instance._gameData.bgmValue = bgmSoundValue;
		DataController.Instance._gameData.effectValue = effectSoundValue;
		DataController.Instance._gameData.bgmMute = bgmSoundMute;
		DataController.Instance._gameData.effectMute = effectSoundMute;
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


	public AudioClip GetBGM(int key)
	{
		AudioClip v;
		BGM_Dic.TryGetValue(key, out v);
		return v;
	}

	public AudioClip GetSFX(int key)
	{
		AudioClip v;
		SFX_Dic.TryGetValue(key, out v);
		return v;
	}

#if false
    private void OnApplicationQuit()
    {
        DataController.Instance.gameData.effectValue = effectSoundValue;
        DataController.Instance.gameData.bgmValue = bgmSoundValue;
        DataController.Instance.gameData.effectMute = effectSoundMute;
        DataController.Instance.gameData.bgmMute = bgmSoundMute;
    }
#endif
}
