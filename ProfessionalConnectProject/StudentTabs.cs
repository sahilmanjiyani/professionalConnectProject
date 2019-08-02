using System.Collections;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using ActionBar = Android.App.ActionBar;

namespace ProfessionalConnectProject
{
    [Activity(Label = "StudentTabs")]
    public class StudentTabs : Activity
    {
        Fragment[] _fragmentsArray;



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

            List<Cards> myFavList = new List<Cards>();

            myFavList.Add(new Cards("abc", "xyz", Resource.Drawable.myPic));


            _fragmentsArray = new Fragment[]
                {
                    new StudentFirstFragment(this, myFavList),
                    new StudentSecondFragment(this),
                };


                AddTabToActionBar("First"); //First Tab
                AddTabToActionBar("Second"); //Second Tab


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
    }
}