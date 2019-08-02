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
    class Cards
    {
        public String firstName;
        public String lastName;
       /* public int profilePic;
        public String qualification;*/

        //public Cards(String fn, String ln, int pic, String qual )
        public Cards(String fn, String ln)
        {
            this.firstName = fn;
            this.lastName = ln;
           /* this.profilePic = pic;
            this.qualification = qual;*/

        }
    }
}