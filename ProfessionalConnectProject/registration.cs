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
    [Activity(Label = "Registration")]
    public class Registration : Activity
    {

       // EditText myfname, mylname, myuserid, mypass, myphone, myrole;
        EditText myFirstName, myLastName, myUsername, myPassword, myConfirmPassword, myRole;

        Button myCreateAccBtn;

        Android.App.AlertDialog.Builder myAlert;

        string alertField = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.registrationView);


            UserDBHelper myuserDBHelper;

            myuserDBHelper = new UserDBHelper(this);

    

         // inserting values to the reg table 
            myuserDBHelper.insertValue("vandana","R","v@mail.com","1234",0344,"BA");
            myuserDBHelper.insertValue("Sahil", "M", "S@mail.com", "12345",0455, "TL");
            myuserDBHelper.insertValue("Sandarbh", "MS", "MS@mail.com", "123456",0211, "SE");

            myuserDBHelper.selectMyValuesReg();

    
         // inserting values to the student table 
            myuserDBHelper.insertValue("v@mail.com", "HTML,CSS,JS", "B.E", "4", "PEGA");
            myuserDBHelper.insertValue("S@mail.com", "JS,JQuery,Angular", "M.S", "5", "ORACLE");
            myuserDBHelper.insertValue("MS@mail.com", "Android,C#,JS", "P.G", "3", "SPLUNK");

            myuserDBHelper.selectMyValuesStu();

         // inserting values into the emp table
            myuserDBHelper.insertValue("v@mail.com", "ABC","HR");
            myuserDBHelper.insertValue("S@mail.com", "XYZ","IT");
            myuserDBHelper.insertValue("MS@mail.com", "XXX","CEO");

            myuserDBHelper.selectMyValuesEmp();

            myFirstName = FindViewById<EditText>(Resource.Id.firstName);
            myLastName = FindViewById<EditText>(Resource.Id.lastName);
            myUsername = FindViewById<EditText>(Resource.Id.username);
            myPassword = FindViewById<EditText>(Resource.Id.password);
            myConfirmPassword = FindViewById<EditText>(Resource.Id.confirmPassword);
            myRole = FindViewById<EditText>(Resource.Id.role);
            myCreateAccBtn = FindViewById<Button>(Resource.Id.createAccountBtn);

            myAlert = new Android.App.AlertDialog.Builder(this);

            myCreateAccBtn.Click += oncreateAccountBtnClick;

            void oncreateAccountBtnClick(object sender, System.EventArgs e)
            {
                Dialog myDialog = myAlert.Create();

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
                else if (myConfirmPassword.Text == " " || myConfirmPassword.Text.Equals(""))
                {

                    myDialog.Show();
                    alertField = "confirmed password";

                }
                else if (myRole.Text == " " || myRole.Text.Equals(""))
                {

                    myDialog.Show();
                    alertField = "Role";

                } else
                {
                    // save registration to database in reg_table 

                    // go to student profile page if role is student
                    Intent profilePage = new Intent(this, typeof(StudentProfile));
                    StartActivity(profilePage);

                }

            }

            myAlert.SetTitle("Error");
            myAlert.SetMessage("Enter the " + alertField);
            myAlert.SetPositiveButton("OK", OkAction);
            myAlert.SetNegativeButton("Cancel", CancelAction);


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