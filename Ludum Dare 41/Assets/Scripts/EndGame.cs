using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public ArrowGenerator gen;
    public int SceneIndex;
    public LoadingScreen loading;
	// Update is called once per frame
	void Update ()
    {
        if (!gen.mainSongSource.isPlaying)
        {
            loading.LoadLevel(SceneIndex);
        }
	}
}
