using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickLoadScene : MonoBehaviour, IPointerClickHandler
{
    public int LevelNum;
    public void OnPointerClick(PointerEventData eventData)
    {
        LevelLoader.Lev = LevelNum;
        SceneManager.LoadScene(1);
    }
}
