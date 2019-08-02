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
            SetContentView(Resource.Layout.employerProfileView);

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

                        // go to emp list page if role is student
                        //Intent profilePage = new Intent(this, typeof(EmployerProfile));
                        //StartActivity(profilePage);

                    }

                }
            }


        }

      
    }
}