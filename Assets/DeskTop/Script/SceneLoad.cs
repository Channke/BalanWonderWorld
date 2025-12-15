using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public GameObject Player;
    [Header("ロードするシーンの名前")]
    public SceneAsset targetSceneAsset;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Player.tag))
        SceneManager.LoadScene(targetSceneAsset.name);
    }
}
