using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Views;
using Android.Database;

namespace ProfessionalConnectProject
{
    [Activity(Label = "@string/app_name")]
    public class MainActivity : Activity
    {
        EditText myUsername, myPassword;
        Button myLoginBtn, mySignUpBtn;

        Spinner spinnerView;
        string myRoleValue;
        string[] myCategory = { "Role", "Student", "Employer" };

        UserDBHelper myUserDb;
        Android.App.AlertDialog.Builder myAlert;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            myUsername = FindViewById<EditText>(Resource.Id.username);
            myPassword = FindViewById<EditText>(Resource.Id.userpass);

            myLoginBtn = FindViewById<Button>(Resource.Id.loginBtn);
            mySignUpBtn = FindViewById<Button>(Resource.Id.signUpBtn);

            spinnerView = FindViewById<Spinner>(Resource.Id.roleSpinner );

            spinnerView.Adapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleSpinnerDropDownItem , myCategory);


            /*ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.array.spinner_data, Resource.Layout.sip );
            adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
            spinner.setAdapter(adapter)*/

            spinnerView.ItemSelected += MyItemSelectedMethod;

            myLoginBtn.Click += onLoginButtonClick;
            
            // call function to click signup button
            mySignUpBtn.Click += onSignUpButtonClick;

            myAlert = new Android.App.AlertDialog.Builder(this);

            myUserDb = new UserDBHelper(this);
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

        void onLoginButtonClick(object sender, System.EventArgs e)
        {
            var usernameValue = myUsername.Text;
            var passValue = myPassword.Text;
            
            string alertField = "";
            
            //Inform the user with some Alert Message

            if (usernameValue == " " || usernameValue.Equals(""))
            {
                alertField = "username";
            }
            else if (passValue == " " || passValue.Equals(""))
            {
                alertField = "password";
            }
            else
            {
                ICursor userExist = myUserDb.checkIFEmailExist(usernameValue, passValue);
                System.Console.WriteLine("---------------" + userExist.Count);
                // navigate to profile page here
                if (userExist.Count > 0)
                {
                    if (myRoleValue == "Student")
                    {
                        Intent studentTabPage = new Intent(this, typeof(StudentTabs));
                        StartActivity(studentTabPage);
                    }
                    else if (myRoleValue == "Employer")
                    {
                        /* Intent studentTabPage = new Intent(this, typeof());
                         StartActivity(studentTabPage);*/
                        System.Console.WriteLine("----------->>>>>>>>>>> Navigate to employee page");
                    }
                    else
                    {
                        myAlert.SetTitle("Error");
                        myAlert.SetMessage("Please select role");
                        myAlert.SetPositiveButton("OK", OkAction);
                        myAlert.SetNegativeButton("Cancel", CancelAction);

                        Dialog myDialog = myAlert.Create();
                        myDialog.Show();
                    } // if ends for role and intent for tabs page

                }

                else
                {
                    myAlert.SetTitle("Error");
                    myAlert.SetMessage("User does not exist");
                    myAlert.SetPositiveButton("OK", OkAction);
                    myAlert.SetNegativeButton("Cancel", CancelAction);

                    Dialog myDialog = myAlert.Create();
                    myDialog.Show();
                } // if end for user exit in database

            } // if ends for field validations

            if (alertField != "")
            {
                myAlert.SetTitle("Error");
                myAlert.SetMessage("Enter the " + alertField);
                myAlert.SetPositiveButton("OK", OkAction);
                myAlert.SetNegativeButton("Cancel", CancelAction);

                Dialog myDialog = myAlert.Create();
                myDialog.Show();

            }

        } // ends onLoginButtonClick 

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

        void onSignUpButtonClick(object sender, System.EventArgs e)
        {
            // direct to registration page
            Intent regPage = new Intent(this, typeof(Registration));
            StartActivity(regPage);
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