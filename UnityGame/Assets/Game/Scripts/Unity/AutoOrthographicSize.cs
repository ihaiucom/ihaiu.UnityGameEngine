using UnityEngine;
using System.Collections;

namespace Games
{
    [RequireComponent(typeof(Camera))]
    public class AutoOrthographicSize : MonoBehaviour 
    {
    	public enum Mode
    	{
    		ExpandWidth,
    		ExpandHeight,
    		ExpandAll,
    		ShrinkAll,

    	}

        [HideInInspector]
    	public Camera mcamera;
    	/** 屏幕的纵横比 */
    	private float aspect;
    	private float devAspect;

    	public float devWidth = 9.6f;
    	public float devHeight = 6.4f;
    	public Mode mode;
    	public float scale = 1f;

    	void Start () 
    	{
    		mcamera = GetComponent<Camera>();
    		
    		devAspect = devWidth / devHeight;
    	}

    	void Update () 
    	{
    		aspect = mcamera.aspect;

    		if(mode == Mode.ExpandWidth)
    		{
    			mcamera.orthographicSize =scale * devWidth / (2f * aspect);
    		}
    		else if(mode == Mode.ExpandHeight)
    		{
    			mcamera.orthographicSize = scale * devHeight / 2F;
    		}
    		else if(mode == Mode.ExpandAll)
    		{
    			if(devAspect <= aspect)
    			{
    				mcamera.orthographicSize = scale * devHeight / 2F;
    			}
    			else
    			{
    				mcamera.orthographicSize = scale * devWidth / (2f * aspect);
    			}
    		}
    		else if(mode == Mode.ShrinkAll)
    		{
    			if(devAspect >= aspect)
    			{
    				mcamera.orthographicSize = scale * devHeight / 2F;
    			}
    			else
    			{
    				mcamera.orthographicSize = scale * devWidth / (2f * aspect);
    			}
    		}


    	}
    }
}