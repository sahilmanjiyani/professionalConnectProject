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
    public class EmployerFirstFragment : Fragment
    {

        // ListView myEmpFavList;

        ListView myStuFavList;

        // ArrayAdapter myArrayAdapter;

        Activity myContext;

        List<Cards> myList;
        string myEmail;

        //Button myConnectedBtn;



        public EmployerFirstFragment(Activity mycontext, List<Cards> myFavList, string email)
        {
            this.myContext = mycontext;
            this.myList = myFavList;
            this.myEmail = email;
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
            View myView = inflater.Inflate(Resource.Layout.employerFirstFragmentLayout, container, false);

            // myView.FindViewById<TextView>(Resource.Id.myNameId).Text = mylocalName;

            //myFavList.Add(new Cards("abc", "xyz", Resource.Drawable.myPic, "sd"));          

            myStuFavList = myView.FindViewById<ListView>(Resource.Id.stuFavList);

            //myConnectedBtn = myView.FindViewById<Button>(Resource.Id.connectBtn);

            var myCustomAdp = new myCustomAdapter(myContext, myList, myEmail);

            myStuFavList.Adapter = myCustomAdp;

           

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