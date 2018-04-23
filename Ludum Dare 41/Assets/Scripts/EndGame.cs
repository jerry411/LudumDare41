using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public ArrowGenerator gen;
    public int SceneIndex;
	// Update is called once per frame
	void Update ()
    {
        if (!gen.mainSongSource.isPlaying)
        {
            SceneManager.LoadScene(SceneIndex);
        }
	}
}
