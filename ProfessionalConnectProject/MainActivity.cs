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
        Button myLoginBtn, mySignUpBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            myLoginBtn = FindViewById<Button>(Resource.Id.loginBtn);
            mySignUpBtn = FindViewById<Button>(Resource.Id.signUpBtn);

            // call function to click signup button
            mySignUpBtn.Click += onSignUpButtonClick;

            void onSignUpButtonClick(object sender, System.EventArgs e)
            {
                // direct to registration page
                Intent regPage = new Intent(this, typeof(registration));
                StartActivity(regPage);
            }

        }

        
        
    }
}