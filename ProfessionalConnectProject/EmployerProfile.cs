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
    [Activity(Label = "EmployerProfile")]
    public class EmployerProfile : Activity
    {
        EditText myFirstName, myLastName, myUsername, myPassword, myRole, mycompany, myposition;

        ImageView myProfilePic;

        Button myUpdateBtn;

        Android.App.AlertDialog.Builder myAlert;

        string alertField = "";

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
            myRole = FindViewById<EditText>(Resource.Id.role);
            mycompany = FindViewById<EditText>(Resource.Id.company);
            myposition = FindViewById<EditText>(Resource.Id.position);

            myUpdateBtn = FindViewById<Button>(Resource.Id.updateEmployerProfile);

            myAlert = new Android.App.AlertDialog.Builder(this);

            Dialog myDialog = myAlert.Create();

            myUpdateBtn.Click += myUpdateBtnClick;

            void myUpdateBtnClick(object sender, System.EventArgs e)
            {

                if (myFirstName.Text == " " || myFirstName.Text.Equals(""))
                {
                    alertField = "First Name";
                    myDialog.Show();

                }
                else if (myLastName.Text == " " || myLastName.Text.Equals(""))
                {

                    myDialog.Show();
                    alertField = "Last Name";

                }
                else if (myUsername.Text == " " || myUsername.Text.Equals(""))
                {

                    myDialog.Show();
                    alertField = "username";

                }
                else if (myPassword.Text == " " || myPassword.Text.Equals(""))
                {

                    myDialog.Show();
                    alertField = "password";

                }
                else if (myRole.Text == " " || myRole.Text.Equals(""))
                {

                    myDialog.Show();
                    alertField = "confirmed password";

                }
                else if (mycompany.Text == " " || mycompany.Text.Equals(""))
                {

                    myDialog.Show();
                    alertField = "Company";

                }
                else if (myposition.Text == " " || myposition.Text.Equals(""))
                {

                    myDialog.Show();
                    alertField = "Position";

                }
                else
                {
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

                    // Dialog myDialog = myAlert.Create();
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

                    myRole.Enabled = false;
                    mycompany.Enabled = false;
                    myposition.Enabled = false;


                    myUpdateBtn.Text = "Updated";
                }
                else
                {
                    myFirstName.Enabled = true;
                    myLastName.Enabled = true;
                    myUsername.Enabled = true;
                    myPassword.Enabled = true;
                    myRole.Enabled = true;
                    mycompany.Enabled = true;
                    myposition.Enabled = true;


                    myUpdateBtn.Text = "Update";
                }

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
                        Intent myLoginPage = new Intent(this, typeof(MainActivity));
                        StartActivity(myLoginPage);
                        // add your code  
                        return true;
                    }
                case Resource.Id.menuItem3:
                    {
                        Intent myStudentProfilePage = new Intent(this, typeof(StudentProfile));
                        StartActivity(myStudentProfilePage);
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
            System.Console.WriteLine("OK Button Cliked");
        }

    }

      
    
}