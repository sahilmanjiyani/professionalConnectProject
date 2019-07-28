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
                else if (mySkills.Text == " " || mySkills.Text.Equals(""))
                {

                    myDialog.Show();
                    alertField = "Role";

                }
                else if (myEducation.Text == " " || myEducation.Text.Equals(""))
                {

                    myDialog.Show();
                    alertField = "Role";

                }
                else if (myCertifications.Text == " " || myCertifications.Text.Equals(""))
                {

                    myDialog.Show();
                    alertField = "Role";

                }
                else
                {
                    // save student details to database in student_table 

                    // go to student list page if role is student
                    //Intent profilePage = new Intent(this, typeof(studentProfile));
                    //StartActivity(profilePage);

                }

            }

        }

    }
}