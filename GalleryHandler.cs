using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class GalleryHandler : MonoBehaviour
{
    public Image targetImage; // Reference to the UI Image where you want to display the selected photo
    private string permission = "android.permission.READ_EXTERNAL_STORAGE";

    public void RequestPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(permission))
        {
            Permission.RequestUserPermission(permission);
        }
        else
        {
            AccessGallery();
        }
    }

    private void AccessGallery()
    {
        AndroidJavaClass galleryClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = galleryClass.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent", intentClass.GetStatic<string>("ACTION_PICK"));

        intentObject.Call<AndroidJavaObject>("setType", "image/*");
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_GET_CONTENT"));

        int requestCode = 101;
        activity.Call("startActivityForResult", intentObject, requestCode);
    }

    private void OnActivityResult(int requestCode, int resultCode, AndroidJavaObject data)
    {
        if (requestCode == 101 && resultCode == -1) // -1 indicates success
        {
            AndroidJavaObject uri = data.Call<AndroidJavaObject>("getData");

            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject resolver = activity.Call<AndroidJavaObject>("getContentResolver");
            AndroidJavaObject inputStream = resolver.Call<AndroidJavaObject>("openInputStream", uri);

            byte[] imageData = new byte[inputStream.Call<int>("available")];
            inputStream.Call<int>("read", imageData);

            Texture2D selectedTexture = new Texture2D(1, 1);
            selectedTexture.LoadImage(imageData);

            // Set the selectedTexture to the targetImage UI Image component
            targetImage.sprite = Sprite.Create(selectedTexture, new Rect(0, 0, selectedTexture.width, selectedTexture.height), new Vector2(0.5f, 0.5f));
        }
    }

    private void Update()
    {
        if (Permission.HasUserAuthorizedPermission(permission))
        {
            Debug.Log("Permission granted.");
        }
        else
        {
            Debug.Log("Permission denied.");
        }
    }
}
