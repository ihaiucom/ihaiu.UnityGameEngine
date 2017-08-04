﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TwinkleImageColor : MonoBehaviour
{
	public Image image;
	public Color a;
	public Color b;



	public float 	time = 1;
	public int 		count = 2;
	public bool		overIsHide = false;

	private Coroutine coroutiner;
	private float 	_time = 0;
	private float 	_rate = 0;
	private int 	_countHalf = 0;
	private bool 	_isPlaying;
	private bool 	_isback = false;


	void OnEnable()
	{
        if (image != null)
        {
            Play();
        }
	}

	void OnDisable()
	{
		if(coroutiner != null)
		{
			StopCoroutine(coroutiner);
			coroutiner = null;
			_isPlaying = false;
            image.color = a;
		}
	}


	public void Play()
	{
		_isPlaying = true;
		_countHalf = 0;
		_time = 0;
		_isback = false;
        image.color= a;
		if(coroutiner != null) StopCoroutine(coroutiner);
		coroutiner = StartCoroutine(OnPlay());
	}

	IEnumerator OnPlay()
	{
		while(_isPlaying)
		{
			_time += Time.deltaTime;
			_rate = _time / time;

			if(_isback)
			{
				image.color = Color.Lerp(a, b, _rate);
			}
			else
			{
				image.color = Color.Lerp(b, a, _rate);
			}

			if(_rate >= 1)
			{
				_time = 0;
				_isback = !_isback;
				_countHalf ++;
				if(count != -1)
				{
					if(_countHalf >= count)
					{
						_isPlaying = false;
						break;
					}
				}
			}

			yield return new WaitForEndOfFrame();
		}

		if(overIsHide)
		{
			gameObject.SetActive(false);
		}
	}
}