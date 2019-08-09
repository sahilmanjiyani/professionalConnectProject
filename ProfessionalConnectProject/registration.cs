using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Database;
using Android.Widget;

namespace ProfessionalConnectProject
{
    [Activity(Label = "Registration")]
    public class Registration : Activity
    {

        // EditText myfname, mylname, myuserid, mypass, myphone, myrole;
        EditText myFirstName, myLastName, myUsername,
                    myPassword, myConfirmPassword, myPhone;

        Spinner spinnerView;
        string myRoleValue;
        string[] myCategory = { "Role", "Student", "Employer" };

        Button myCreateAccBtn;

        Android.App.AlertDialog.Builder myAlert;

        string alertField = "";
        UserDBHelper myuserDBHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.registrationView);



            myuserDBHelper = new UserDBHelper(this);

            // inserting values to the reg table 
           /*  myuserDBHelper.insertValue("vandana","R","v@mail.com","1234",0344,"Student", "Resource.Drawable.vandu");
             myuserDBHelper.insertValue("Sahil", "M", "S@mail.com", "12345",0455, "Employer", "Resource.Drawable.vandu");
             myuserDBHelper.insertValue("Sandarbh", "MS", "MS@mail.com", "123456",0211, "Employer", "Resource.Drawable.vandu");
*/
            // myuserDBHelper.selectMyValuesReg();

            // inserting values to the student table 
  /*           myuserDBHelper.insertValue("v@mail.com", "HTML,CSS,JS", "B.E", "4", "PEGA");
              myuserDBHelper.insertValue("S@mail.com", "JS,JQuery,Angular", "M.S", "5", "ORACLE");
              myuserDBHelper.insertValue("MS@mail.com", "Android,C#,JS", "P.G", "3", "SPLUNK");
  */
            myuserDBHelper.selectMyValuesStu();

            // inserting values into the emp table
    /*        myuserDBHelper.insertValue("v@mail.com", "ABC","HR");
            myuserDBHelper.insertValue("S@mail.com", "XYZ","IT");
             myuserDBHelper.insertValue("MS@mail.com", "XXX","CEO");
*/
            // myuserDBHelper.selectMyValuesEmp();

            myFirstName = FindViewById<EditText>(Resource.Id.firstName);
            myLastName = FindViewById<EditText>(Resource.Id.lastName);
            myUsername = FindViewById<EditText>(Resource.Id.username);
            myPassword = FindViewById<EditText>(Resource.Id.password);
            myConfirmPassword = FindViewById<EditText>(Resource.Id.confirmPassword);
            myPhone = FindViewById<EditText>(Resource.Id.phone);
            myCreateAccBtn = FindViewById<Button>(Resource.Id.createAccountBtn);

            spinnerView = FindViewById<Spinner>(Resource.Id.role);

            spinnerView.Adapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleSpinnerDropDownItem, myCategory);

            //trail
            spinnerView.ItemSelected += MyItemSelectedMethod;

            myuserDBHelper.selectfrominnerjoint1();

            myuserDBHelper.selectfrominnerjoint2();


            myAlert = new Android.App.AlertDialog.Builder(this);

            myCreateAccBtn.Click += oncreateAccountBtnClick;
        }

        void oncreateAccountBtnClick(object sender, System.EventArgs e)
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
            else if (myConfirmPassword.Text == " " || myConfirmPassword.Text.Equals(""))
            {

                alertField = "confirmed password";

            }
            else if (myPhone.Text == " " || myPhone.Text.Equals(""))
            {

                alertField = "Phone Number";

            }
            else if (myRoleValue == "Role")
            {

                alertField = "Role";

            }
            else
            {
              
                // save registration to database in reg_table 
                myuserDBHelper.insertValue(myFirstName.Text, myLastName.Text,
                                                myUsername.Text, myPassword.Text, Int32.Parse(myPhone.Text),
                                                    myRoleValue);



                if (myRoleValue == "Student")
                {
                    // go to student profile page if role is student
                    Intent profilePage = new Intent(this, typeof(StudentProfile));

                    profilePage.PutExtra("studentEmail", myUsername.Text);
                    StartActivity(profilePage);


                }
                else
                {
                    // go to student profile page if role is student
                    Intent profilePage = new Intent(this, typeof(EmployerProfile));

                    profilePage.PutExtra("employerEmail", myUsername.Text);
                    StartActivity(profilePage);

                }



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
        void MyItemSelectedMethod(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            myRoleValue = myCategory[index];
            //System.Console.WriteLine("value is " + value);


            /*if (value.ToLower().Equals("Action"))
            {
                //create a veg array and create as a new adater 

            }*/

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