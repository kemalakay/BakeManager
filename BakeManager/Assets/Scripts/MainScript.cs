using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
	static readonly int numScenes = 7;
	public string[] sceneNames = new string[ numScenes ];
	public Button[] loadButtons = new Button[ numScenes ];
	public Button[] unLoadButtons = new Button[ numScenes ];
	public Button[] setActiveButtons = new Button[ numScenes ];

	UnityEngine.SceneManagement.Scene[] scenes = new UnityEngine.SceneManagement.Scene[ numScenes ];

	void Awake()
	{
		for( int buttonIndex = 0; buttonIndex < loadButtons.Length; ++buttonIndex )
		{
			if( loadButtons[ buttonIndex ] == null )
			{
				continue;
			}
			int buttonIndexCopy = buttonIndex;
			loadButtons[ buttonIndex ].onClick.AddListener( () =>
			{
				LoadScene( buttonIndexCopy );
			} );
		}

		for( int buttonIndex = 0; buttonIndex < unLoadButtons.Length; ++buttonIndex )
		{
			if( unLoadButtons[ buttonIndex ] == null )
			{
				continue;
			}
			int buttonIndexCopy = buttonIndex;
			unLoadButtons[ buttonIndex ].onClick.AddListener( () =>
			{
				UnloadScene( buttonIndexCopy );
			} );
		}

		for( int buttonIndex = 0; buttonIndex < setActiveButtons.Length; ++buttonIndex )
		{
			if( setActiveButtons[ buttonIndex ] == null )
			{
				continue;
			}
			int buttonIndexCopy = buttonIndex;
			setActiveButtons[ buttonIndex ].onClick.AddListener( () =>
			{
				SetActiveScene( buttonIndexCopy );
			} );
		}
	}

	void LoadScene( int index )
	{
		if( !scenes[ index ].IsValid() || !scenes[ index ].isLoaded )
		{
			StartCoroutine( LoadSceneCoroutine( index ) );
		}
	}

	IEnumerator LoadSceneCoroutine( int index )
	{
		var op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync( sceneNames[ index ], UnityEngine.SceneManagement.LoadSceneMode.Additive );

		yield return op;

		scenes[ index ] = UnityEngine.SceneManagement.SceneManager.GetSceneByName( sceneNames[ index ] );
	}

	void UnloadScene( int index )
	{
		if( scenes[ index ].IsValid() && scenes[ index ].isLoaded )
		{
			UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync( sceneNames[ index ] );
			scenes[ index ] = new UnityEngine.SceneManagement.Scene();
		}
	}

	void SetActiveScene( int index )
	{
		if( scenes[ index ].IsValid() && scenes[ index ].isLoaded )
		{
			UnityEngine.SceneManagement.SceneManager.SetActiveScene( scenes[ index ] );
		}
	}
}
