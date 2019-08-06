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
    class myCustomAdapter : BaseAdapter<Cards>
    {
        Activity myContext;

        Context context;

        List<Cards> myList;
        private StudentFirstFragment studentFirstFragment;
        private List<Cards> myFavList;
        string myEmail;
        UserDBHelper myUserDb;
        public myCustomAdapter(Activity myContext, List<Cards> myUserList, string myEmail)
        {
            this.myContext = myContext;
            myList = myUserList;
            this.myEmail = myEmail;
        }

        /*public myCustomAdapter(Activity myContext, List<Cards> myFavList)
        {
            myContext = myContext;
           myFavList = myFavList;
        }*/

        public override Cards this[int position]
        {

            get { return myList[position]; }

        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View myView = convertView;

            //myCustomAdapterViewHolder holder = null;
            Cards myCardsObj = myList[position];

           /* if (view != null)
                holder = view.Tag as myCustomAdapterViewHolder;*/

            if (myView == null)
            {
                // holder = new myCustomAdapterViewHolder();
                //var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                //view = inflater.Inflate(Resource.Layout.item, parent, false);
                //holder.Title = view.FindViewById<TextView>(Resource.Id.text);
                // view.Tag = holder;

                myView = myContext.LayoutInflater.Inflate(Resource.Layout.myStudentCardView, null);

                myView.FindViewById<TextView>(Resource.Id.firstName).Text = myCardsObj.firstName;
                myView.FindViewById<TextView>(Resource.Id.qual).Text = myCardsObj.qualification;
                myView.FindViewById<TextView>(Resource.Id.lastName).Text = myCardsObj.lastName;
                myView.FindViewById<ImageView>(Resource.Id.studentPic).SetImageResource(myCardsObj.profilePic);
                Button connectBtn = myView.FindViewById<Button>(Resource.Id.connectBtn);

                connectBtn.Click += delegate
                {
                    connectBtn.Text = "CONNECTED";


                    Intent myFavTab = new Intent();

                    /*myFavTab.PutExtra("position", position);
                    myContext.StartActivityFromFragment(studentFirstFragment, myFavTab, 0 );

                    
                   myUserDb = new UserDBHelper(myContext);
                    myUserDb.savedFavEmp(myEmail);*/

                };
            }

            //fill in your items
            //holder.Title.Text = "new text here";

            return myView;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return myList.Count;
            }
        }

    }

    class myCustomAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}