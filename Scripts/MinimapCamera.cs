using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinimapCamera : MonoBehaviour
{

    public static MinimapCamera Camera;
    public Transform Target;

    Transform m_CameraTransform;

    void Awake()
    {
        if (Camera != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Camera = this;

        PhotonNetwork.automaticallySyncScene = true;
        SceneManager.sceneLoaded += this.OnLoadCallback; //回傳新版的載入場景,舊版刪除這行

    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        if (Target == null)
        {
            return;
        }

        transform.position = Target.transform.position;  //攝影機跟著人物移動
    }

    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode) //新版的載入場景
    {

    }
}
