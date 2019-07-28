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
    [Activity(Label = "studentProfile")]
    public class studentProfile : Activity
    {
        ImageView myProfilePic;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.studentProfileLayout);

            myProfilePic = FindViewById<ImageView>(Resource.Id.myStudentPic);
            myProfilePic.SetImageResource(Resource.Drawable.myPic);
        }
    }
}