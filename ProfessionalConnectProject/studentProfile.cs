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
    [Activity(Label = "studentProfile")]
    public class StudentProfile : Activity
    {
        EditText myFirstName, myLastName, myUsername, myPassword, myPhone,
                 mySkills, myEducation, myExprience, myCertifications;

        ImageView myProfilePic;

        Button myUpdateBtn;

        Android.App.AlertDialog.Builder myAlert;

        UserDBHelper myuserDBHelper;

        string alertField = "";
        string myValue;

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
            myPhone = FindViewById<EditText>(Resource.Id.phonenum);
            mySkills = FindViewById<EditText>(Resource.Id.skills);
            myEducation = FindViewById<EditText>(Resource.Id.education);
            myExprience = FindViewById<EditText>(Resource.Id.exprience);
            myCertifications = FindViewById<EditText>(Resource.Id.certification);

            myUpdateBtn = FindViewById<Button>(Resource.Id.updateStudentProfile);

            myuserDBHelper = new UserDBHelper(this);

            myValue = Intent.GetStringExtra("studentEmail");

            System.Console.WriteLine("-----------------------------> " + myValue);


             ICursor studentProfile = myuserDBHelper.getProfile(myValue);
            ICursor studentDetails = myuserDBHelper.getStudentProfile(myValue);

            studentProfile.MoveToFirst();

            myFirstName.Text = studentProfile.GetString(0);
            myLastName.Text = studentProfile.GetString(1);

            myUsername.Text = studentProfile.GetString(2);
            myUsername.Enabled = false;
            myPassword.Text = studentProfile.GetString(3);
            myPhone.Text = studentProfile.GetString(4);
            myExprience.Text = studentProfile.GetString(5);

            if (studentDetails.Count > 0)
            {
                studentDetails.MoveToFirst();

                mySkills.Text = studentDetails.GetString(0);
                myEducation.Text = studentDetails.GetString(1);
                myCertifications.Text = studentDetails.GetString(2);

            }

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
            else if (myPhone.Text == " " || myPhone.Text.Equals(""))
            {
                alertField = "confirmed password";
            }
            else if (mySkills.Text == " " || mySkills.Text.Equals(""))
            {
                alertField = "Skills";
            }
            else if (myEducation.Text == " " || myEducation.Text.Equals(""))
            {
                alertField = "Education";
            }
            else if (myExprience.Text == " " || myExprience.Text.Equals(""))
            {
                alertField = "Exprience";
            }
            else if (myCertifications.Text == " " || myCertifications.Text.Equals(""))
            {
                alertField = "Certification";
            }
            else
            {

                myuserDBHelper.insertValue(myUsername.Text,mySkills.Text,myEducation.Text, myExprience.Text,myCertifications.Text);

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
               
                myPassword.Enabled = false;

                myPhone.Enabled = false;
                mySkills.Enabled = false;
                myEducation.Enabled = false;
                myCertifications.Enabled = false;

                myUpdateBtn.Text = "Updated";
            }
            else
            {
                myFirstName.Enabled = true;
                myLastName.Enabled = true;
        
                myPassword.Enabled = true;
                myPhone.Enabled = true;
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
                        Intent profilePage = new Intent(this, typeof(StudentProfile));
                        StartActivity(profilePage);
                        // add your code  
                        return true;
                    }
                case Resource.Id.menuItem3:
                    {
                        Intent tabPage = new Intent(this, typeof(StudentTabs));
                        tabPage.PutExtra("studentEmail", myUsername.Text);
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
            System.Console.WriteLine("OK Button Cliked");
        }
    }
}