using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace ProfessionalConnectProject
{
    [Activity(Label = "@string/app_name",  MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText myUsername, myPassword;
        Button myLoginBtn, mySignUpBtn;

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



            myLoginBtn.Click += onLoginButtonClick;
            
            // call function to click signup button
            mySignUpBtn.Click += onSignUpButtonClick;

            myAlert = new Android.App.AlertDialog.Builder(this);

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

            myAlert.SetTitle("Error");
            myAlert.SetMessage("Enter the " + alertField);
            myAlert.SetPositiveButton("OK", OkAction);
            myAlert.SetNegativeButton("Cancel", CancelAction);

            Dialog myDialog = myAlert.Create();
            myDialog.Show();

        }

        void onSignUpButtonClick(object sender, System.EventArgs e)

        {
            // direct to registration page
            // Intent regPage = new Intent(this, typeof(Registration));
            // StartActivity(regPage);

            Intent stdTab = new Intent(this, typeof(StudentTabs));
            StartActivity(stdTab);
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