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
    [Activity(Label = "registration")]
    public class registration : Activity
    {

       // EditText myfname, mylname, myuserid, mypass, myphone, myrole;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.registrationView);

            userDBHelper myuserDBHelper;

            myuserDBHelper = new userDBHelper(this);

    

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

        }
    }
}