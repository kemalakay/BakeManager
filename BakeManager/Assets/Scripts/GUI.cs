using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    #region Singleton

    private static GUI m_Instance;

    public static GUI instance
    {
        get
        {
            return m_Instance;
        }
    }

    void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this.GetComponent<GUI>();

            DontDestroyOnLoad(gameObject);
        }
    }

    #endregion


    public Button btnLoadScene;
    public Image imgLoading;
    
}
