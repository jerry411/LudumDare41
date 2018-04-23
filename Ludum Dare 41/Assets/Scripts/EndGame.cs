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
<<<<<<< HEAD
            loading.LoadLevel(SceneIndex);
=======
            //SceneManager.LoadScene(SceneIndex);
>>>>>>> b46a5ea36253a58b05a70e1db6dbd868fc55d331
        }
	}
}
