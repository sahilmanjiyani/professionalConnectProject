using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ProfessionalConnectProject
{
    public class StudentFirstFragment : Fragment
    {
        string mylocalName;

        public StudentFirstFragment(string name)
        {
            mylocalName = name;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View myView = inflater.Inflate(Resource.Layout.studentFirstFragmentLayout, container, false);

            myView.FindViewById<TextView>(Resource.Id.myNameId).Text = mylocalName;

            return myView;

            // return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override void OnResume()
        {
            base.OnResume();
            System.Console.WriteLine("OnResume");

        }
    }
}