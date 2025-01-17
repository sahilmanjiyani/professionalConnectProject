﻿using System.Collections;
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
    [Activity(Label = "EmployerTabs", MainLauncher = true)]
    public class EmployerTabs : Activity
    {
        Fragment[] _fragmentsArray;

        UserDBHelper myUserDb;
        string myValue;

        protected override void OnCreate(Bundle savedInstanceState)
        {
                // Set our view from the "main" layout resource
                // RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
                //enable navigation mode to support tab layout
                ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            
                base.OnCreate(savedInstanceState);

                // Create your application here

                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.employerTabsLayout);

                List<Cards> myFavList = new List<Cards>();

                myUserDb = new UserDBHelper(this);

                myValue = Intent.GetStringExtra("EmployerEmail");

                ICursor myResult = myUserDb.selectfrominnerjoint1();
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


                AddTabToActionBar("Students"); //First Tab
                AddTabToActionBar("Connected"); //Second Tab


            

        }

        void AddTabToActionBar(string tabTitle)
        {
            Android.App.ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText(tabTitle);
            // tab.SetIcon(Android.Resource.Drawable.IcInputAdd);
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
                        Intent profilePage = new Intent(this, typeof(EmployerProfile));
                  
                        profilePage.PutExtra("employerEmail", myValue);
                        StartActivity(profilePage);
                        // add your code  
                        return true;
                    }
                case Resource.Id.menuItem3:
                    {
                        Intent tabPage = new Intent(this, typeof(EmployerTabs));
                        StartActivity(tabPage);
                        // add your code  
                        return true;
                    }
            }
            return base.OnOptionsItemSelected(item);
        }

    }
}