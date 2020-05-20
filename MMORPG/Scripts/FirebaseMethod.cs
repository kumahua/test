using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class FirebaseMethod
{
    private DatabaseReference databaseReference;

    public FirebaseMethod()
    {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://mmorpg-c7ad5.firebaseio.com/");
        // Get the root reference location of the database.
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void Data_Push()
    {
        databaseReference.Child("Test").Child("Kavo").SetValueAsync("上傳成功");
        Debug.Log("Firebase 成功上傳");
    }
}
