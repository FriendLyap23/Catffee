using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageView : MonoBehaviour
{
    public Image Image;

    private void Awake()
    {
        Image = GetComponent<Image>();
    }
}
