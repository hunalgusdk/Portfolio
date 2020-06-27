using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(540.0f, 460.0f, 200.0f, 100.0f), "Popup"))
        {
            SceneManager.LoadScene("PopupScene");
        }

        if (GUI.Button(new Rect(540.0f, 310.0f, 200.0f, 100.0f), "Animation"))
        {
            SceneManager.LoadScene("AnimationScene");
        }

        if (GUI.Button(new Rect(540.0f, 160.0f, 200.0f, 100.0f), "Effect Pool"))
        {
            SceneManager.LoadScene("EffectPoolScene");
        }
    }
}
