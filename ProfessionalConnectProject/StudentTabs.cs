using System.Collections;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using ActionBar = Android.App.ActionBar;

namespace ProfessionalConnectProject
{
    [Activity(Label = "StudentTabs", MainLauncher = true)]
    public class StudentTabs : Activity
    {
        Fragment[] _fragmentsArray;
/*
        SearchView searchUsers;*/

        UserDBHelper myUserDb;
        string myValue;
        List<Cards> myFavList = new List<Cards>();
        List<Cards> myFilteredUser = new List<Cards>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Set our view from the "main" layout resource
            // RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
            //enable navigation mode to support tab layout
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            base.OnCreate(savedInstanceState);

            // Create your application here

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.studentTabsLayout);
/*
            searchUsers = FindViewById<SearchView>(Resource.Id.searchViewId);*/

                List<Cards> myFavList = new List<Cards>();

                myUserDb = new UserDBHelper(this);

                myValue = Intent.GetStringExtra("studentEmail");
            myFavList.Add(new Cards("Sahil", "Manjiyani", Resource.Drawable.myProfilePic, "B.E"));
            myFavList.Add(new Cards("Sandharb", "Misra", Resource.Drawable.myProfilePic, "B.E"));
            myFavList.Add(new Cards("Vandana", "Ramaprasad", Resource.Drawable.myProfilePic, "B.E"));
            myFavList.Add(new Cards("Ranjit", "Singh", Resource.Drawable.myProfilePic, "B.E"));

                ICursor myResult = myUserDb.selectfrominnerjoint2();
                         myResult.MoveToFirst();

                do {
                    myFavList.Add(new Cards(myResult.GetString(0), myResult.GetString(1), Resource.Drawable.myProfilePic, myResult.GetString(2)));
                } while (myResult.MoveToNext());

                /*myFavList.Add(new Cards("Sahil", "Manjiyani", Resource.Drawable.myProfilePic, "B.E"));*/


                _fragmentsArray = new Fragment[]
                    {
                        new StudentFirstFragment(this, myFavList, myValue ),
                        new StudentSecondFragment(this),
                    };


            AddTabToActionBar("Employers"); //First Tab
            AddTabToActionBar("Connected"); //Second Tab

        }

        void AddTabToActionBar(string tabTitle)
        {
            Android.App.ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText(tabTitle);

            if (tabTitle == "Employers")
            {
               tab.SetIcon(Resource.Drawable.userIcon);
            }
            else
            {
                tab.SetIcon(Resource.Drawable.starIcon);
            }

            tab.TabSelected += TabOnTabSelected;
            ActionBar.AddTab(tab);
        }

        void TabOnTabSelected(object sender, ActionBar.TabEventArgs tabEventArgs)
        {
            ActionBar.Tab tab = (ActionBar.Tab)sender;

            //Log.Debug(Tag, "The tab {0} has been selected.", tab.Text);
            Fragment frag = _fragmentsArray[tab.Position];

            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // set the menu layout on Main Activity  
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menuItem1:
                    {
                        Intent myLoginPage = new Intent(this, typeof(MainActivity));
                        StartActivity(myLoginPage);
                        // add your code  
                        return true;
                    }
                case Resource.Id.menuItem2:
                    {
                        Intent profilePage = new Intent(this, typeof(StudentProfile));
                  
                        profilePage.PutExtra("studentEmail", myValue);
                        StartActivity(profilePage);
                        // add your code  
                        return true;
                    }
                case Resource.Id.menuItem3:
                    {
                        Intent tabPage = new Intent(this, typeof(StudentTabs));
                        StartActivity(tabPage);
                        // add your code  
                        return true;
                    }
            }
            return base.OnOptionsItemSelected(item);
        }

    }
}