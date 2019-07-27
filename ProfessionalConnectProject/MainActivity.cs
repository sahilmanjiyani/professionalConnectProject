using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace ProfessionalConnectProject
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText myUsername, myPassword;
        Button myLoginBtn, mySignUpBtn;

        Android.App.AlertDialog.Builder myAlert;

        string alertField = "";

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



            void onLoginButtonClick(object sender, System.EventArgs e)
            {
                var usernameValue = myUsername.Text;
                var passValue =  myPassword.Text;

                //Inform the user with some Alert Message

                Dialog myDialog = myAlert.Create();

                


                if (usernameValue == " " || usernameValue.Equals(""))
                {
                    alertField = "username";
                    myDialog.Show();

                } else if (passValue == " " || passValue.Equals(""))
                {

                    myDialog.Show();
                    alertField = "password";

                }


            }

            void onSignUpButtonClick(object sender, System.EventArgs e)

            {
                // direct to registration page
                Intent regPage = new Intent(this, typeof(registration));
                StartActivity(regPage);
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