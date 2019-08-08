using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ProfessionalConnectProject
{
    [Activity(Label = "EmployerProfile")]
    public class EmployerProfile : Activity
    {
        EditText myFirstName, myLastName, myUsername, myPassword, myPhone, mycompany, myposition;

        ImageView myProfilePic;

        Button myUpdateBtn;

        UserDBHelper myuserDBHelper;

        Android.App.AlertDialog.Builder myAlert;

        string alertField = "";

        string myValue;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.employerProfileLayout);

            myProfilePic = FindViewById<ImageView>(Resource.Id.myEmployerPic);
            myProfilePic.SetImageResource(Resource.Drawable.myPic);

            myFirstName = FindViewById<EditText>(Resource.Id.firstName);
            myLastName = FindViewById<EditText>(Resource.Id.lastName);
            myUsername = FindViewById<EditText>(Resource.Id.username);
            myPassword = FindViewById<EditText>(Resource.Id.password);
            myPhone = FindViewById<EditText>(Resource.Id.phonenum);
            //myRole = FindViewById<EditText>(Resource.Id.role);
            mycompany = FindViewById<EditText>(Resource.Id.company);
            myposition = FindViewById<EditText>(Resource.Id.position);

            myUpdateBtn = FindViewById<Button>(Resource.Id.updateEmployerProfile);

            myuserDBHelper = new UserDBHelper(this);

            myValue = Intent.GetStringExtra("employerEmail");

            System.Console.WriteLine("------------------------------------------------> " + myValue);

            ICursor employerProfile = myuserDBHelper.getProfile(myValue);
            ICursor employerDetails = myuserDBHelper.getEmployerProfile(myValue);

            employerProfile.MoveToFirst();

            myFirstName.Text = employerProfile.GetString(0);
            myLastName.Text = employerProfile.GetString(1);
            myUsername.Text = employerProfile.GetString(2);
            myUsername.Enabled = false;
            myPassword.Text = employerProfile.GetString(3);
            myPhone.Text = employerProfile.GetString(4);



            if (employerDetails.Count > 0)
            {
                employerDetails.MoveToFirst();

                mycompany.Text = employerProfile.GetString(0);

                myposition.Text = employerDetails.GetString(1);
            }


            myAlert = new Android.App.AlertDialog.Builder(this);

                 // Dialog myDialog = myAlert.Create();

            myUpdateBtn.Click += myUpdateBtnClick;
        }

            void myUpdateBtnClick(object sender, System.EventArgs e)
            {

                if (myFirstName.Text == " " || myFirstName.Text.Equals(""))
                {
                    alertField = "First Name";
                    

                }
                else if (myLastName.Text == " " || myLastName.Text.Equals(""))
                {

                    
                    alertField = "Last Name";

                }
                else if (myUsername.Text == " " || myUsername.Text.Equals(""))
                {

                    
                    alertField = "username";

                }
                else if (myPassword.Text == " " || myPassword.Text.Equals(""))
                {

                    
                    alertField = "password";

                }
                else if (myPhone.Text == " " || myPhone.Text.Equals(""))
                {

                    
                    alertField = "phone num ";

                }
                else if (mycompany.Text == " " || mycompany.Text.Equals(""))
                {

                    
                    alertField = "Company";

                }
                else if (myposition.Text == " " || myposition.Text.Equals(""))
                {

                   
                    alertField = "Position";

                }
                else
                {

                    myuserDBHelper.insertValue(myUsername.Text, mycompany.Text, myposition.Text);

                    // save employer details to database in employer_table 

                    onUpdateUnenableEdit(sender, e);

                    // go to emp list page if role is student
                    //Intent profilePage = new Intent(this, typeof(EmployerProfile));
                    //StartActivity(profilePage);

                }

                if (alertField != "")
                {
                    myAlert.SetTitle("Error");
                    myAlert.SetMessage("Enter the " + alertField);
                    myAlert.SetPositiveButton("OK", OkAction);
                    myAlert.SetNegativeButton("Cancel", CancelAction);

                    Dialog myDialog = myAlert.Create();
                    myDialog.Show();
                }

            }

            void onUpdateUnenableEdit(object sender, System.EventArgs e)
            {
                if (myUpdateBtn.Text == "Update")
                {
                    myFirstName.Enabled = false;
                    myLastName.Enabled = false;
                    myUsername.Enabled = false;
                    myPassword.Enabled = false;

                    myPhone.Enabled = false;
                    mycompany.Enabled = false;
                    myposition.Enabled = false;


                    myUpdateBtn.Text = "Updated";
                }
                else
                {
                    myFirstName.Enabled = true;
                    myLastName.Enabled = true;
                    
                    myPassword.Enabled = true;
                    myPhone.Enabled = true;
                    mycompany.Enabled = true;
                    myposition.Enabled = true;


                    myUpdateBtn.Text = "Update";
                }

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
                        Intent myProfilePage = new Intent(this, typeof(EmployerProfile));
                        StartActivity(myProfilePage);
                        // add your code  
                        return true;
                    }
                case Resource.Id.menuItem3:
                    {
                        Intent tabPage = new Intent(this, typeof(EmployerTabs));

                        tabPage.PutExtra("EmployerEmail", myUsername.Text);
                        StartActivity(tabPage);
                        // add your code  
                        return true;
                    }
            }

            return base.OnOptionsItemSelected(item);
        }   

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            System.Console.WriteLine("OK Button Cliked");
        }

        private void CancelAction(object sender, DialogClickEventArgs e)
        {
            System.Console.WriteLine("Cancel Button Cliked");
        }

    }
   
}