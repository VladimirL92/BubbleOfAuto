using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickLoadScene : MonoBehaviour, IPointerClickHandler
{
    public int SceneNum;
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(SceneNum);
    }
}
