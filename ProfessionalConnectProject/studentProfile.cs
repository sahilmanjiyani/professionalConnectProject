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
    [Activity(Label = "studentProfile")]
    public class StudentProfile : Activity
    {
        EditText myFirstName, myLastName, myUsername, myPassword, myRole,
                 mySkills, myEducation, myCertifications;

        ImageView myProfilePic;

        Button myUpdateBtn;

        Android.App.AlertDialog.Builder myAlert;

        string alertField = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.studentProfileLayout);

            myProfilePic = FindViewById<ImageView>(Resource.Id.myStudentPic);
            myProfilePic.SetImageResource(Resource.Drawable.myPic);

            myFirstName = FindViewById<EditText>(Resource.Id.firstName);
            myLastName = FindViewById<EditText>(Resource.Id.lastName);
            myUsername = FindViewById<EditText>(Resource.Id.username);
            myPassword = FindViewById<EditText>(Resource.Id.password);
            myRole = FindViewById<EditText>(Resource.Id.role);
            mySkills = FindViewById<EditText>(Resource.Id.skills);
            myEducation = FindViewById<EditText>(Resource.Id.education);
            myCertifications = FindViewById<EditText>(Resource.Id.certification);

            myUpdateBtn = FindViewById<Button>(Resource.Id.updateStudentProfile);

            myFirstName.Text = "Sahil";
            myLastName.Text = "Manjiyani";
            myUsername.Text = "sahilmanjiyani";
            myPassword.Text = "1234";
            myRole.Text = "Student";
            mySkills.Text = "Java";
            myEducation.Text = "B.E.";
            myCertifications.Text = "Oracle";

            myAlert = new Android.App.AlertDialog.Builder(this);

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
            else if (myRole.Text == " " || myRole.Text.Equals(""))
            {
                alertField = "confirmed password";
            }
            else if (mySkills.Text == " " || mySkills.Text.Equals(""))
            {
                alertField = "Role";
            }
            else if (myEducation.Text == " " || myEducation.Text.Equals(""))
            {
                alertField = "Role";
            }
            else if (myCertifications.Text == " " || myCertifications.Text.Equals(""))
            {
                alertField = "Role";
            }
            else
            {
                // save student details to database in student_table 

                onUpdateUnenableEdit(sender, e);

                // go to student list page if role is student
                /*Intent studentTabsPage = new Intent(this, typeof(StudentTabs));
                StartActivity(studentTabsPage);*/
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
                myRole.Enabled = false;
                mySkills.Enabled = false;
                myEducation.Enabled = false;
                myCertifications.Enabled = false;

                myUpdateBtn.Text = "Updated";
            }
            else
            {
                myFirstName.Enabled = true;
                myLastName.Enabled = true;
                myUsername.Enabled = true;
                myPassword.Enabled = true;
                myRole.Enabled = true;
                mySkills.Enabled = true;
                myEducation.Enabled = true;
                myCertifications.Enabled = true;

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