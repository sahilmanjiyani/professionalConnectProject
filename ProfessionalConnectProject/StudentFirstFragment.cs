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

        ListView myEmpFavList;

        // ArrayAdapter myArrayAdapter;

        Activity myContext;

        List<Cards> myList;

        Button myConnectedBtn;



        public StudentFirstFragment(Activity mycontext, List<Cards> myFavList)
        {
            this.myContext = mycontext;
            this.myList = myFavList;
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

            myEmpFavList = myView.FindViewById<ListView>(Resource.Id.empFavList);

            myConnectedBtn = myView.FindViewById<Button>(Resource.Id.connectBtn);

            var myCustomAdp = new myCustomAdapter(myContext, myList);

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