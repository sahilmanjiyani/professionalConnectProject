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
        List<Cards> myFilteredUser = new List<Cards>();

        Button myConnectedBtn;

        SearchView searchUsers;




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


            searchUsers = myView.FindViewById<SearchView>(Resource.Id.searchViewId);

            myConnectedBtn = myView.FindViewById<Button>(Resource.Id.connectBtn);

            var myCustomAdp = new myCustomAdapter(myContext, myList);

            searchUsers.QueryTextChange += MySearch_QueryTextChange;

            myEmpFavList.Adapter = myCustomAdp;

            return myView;

            // return base.OnCreateView(inflater, container, savedInstanceState);
        }

        private void MySearch_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var searchValue = e.NewText;

            myFilteredUser.Clear();

            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].firstName.Contains(searchValue) || myList[i].lastName.Contains(searchValue))
                {
                    myFilteredUser.Add(myList[i]);
                }
            }

            var myFilteredAdapter = new myCustomAdapter(myContext, myFilteredUser);

            myEmpFavList.Adapter = myFilteredAdapter;

        }

        public override void OnResume()
        {
            base.OnResume();
            System.Console.WriteLine("OnResume");

        }
    }
}