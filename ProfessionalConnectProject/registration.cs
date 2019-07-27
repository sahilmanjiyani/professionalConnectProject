using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ProfessionalConnectProject
{
    [Activity(Label = "registration")]
    public class registration : Activity
    {
        EditText myFirstName, myLastName, myUsername, myPassword, myConfirmPassword, myRole;

        Android.App.AlertDialog.Builder myAlert;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.registrationView);

            myFirstName = FindViewById<EditText>(Resource.Id.firstName);
            myLastName = FindViewById<EditText>(Resource.Id.lastName);
            myUsername = FindViewById<EditText>(Resource.Id.username);
            myPassword = FindViewById<EditText>(Resource.Id.password);
            myConfirmPassword = FindViewById<EditText>(Resource.Id.confirmPassword);
            myRole = FindViewById<EditText>(Resource.Id.role);

        }

    }
}