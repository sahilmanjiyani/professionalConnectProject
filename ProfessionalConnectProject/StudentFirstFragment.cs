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
        // string mylocalName;

        ListView myEmpFavList;

        List<Cards> myFavList = new List<Cards>();

        // ArrayAdapter myArrayAdapter;

        // List<int> myStringArray = new List<int>();

        Activity myContext;

        public StudentFirstFragment(Activity mycontext)
        {
            //mylocalName = name; 
            this.myContext = mycontext;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

            // myArrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, myStringArray);



        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View myView = inflater.Inflate(Resource.Layout.studentFirstFragmentLayout, container, false);

            // myView.FindViewById<TextView>(Resource.Id.myNameId).Text = mylocalName;

            //myFavList.Add(new Cards("abc", "xyz", Resource.Drawable.myPic, "sd"));
            myFavList.Add(new Cards("abc", "xyz"));

            myEmpFavList = myView.FindViewById<ListView>(Resource.Id.empFavList);


            var myCustomAdp = new myCustomAdapter(myContext, myFavList);

            myEmpFavList.Adapter = myCustomAdp;

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