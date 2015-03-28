using UnityEngine;
using System.Collections;

public class DestroyOnMobile : MonoBehaviour {

    public bool DestroyGameObject = true;

#if UNITY_ANDROID
    void Start()
    {
        if (DestroyGameObject)
            Destroy(this.gameObject);
        else
            Destroy(this);
    }
#endif
}
