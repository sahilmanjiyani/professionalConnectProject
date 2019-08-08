using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ProfessionalConnectProject
{
    class UserDBHelper : SQLiteOpenHelper
    {
        private static string _DatabaseName = "myuserdatabase.db";

     // Table #1 - Reg table Common Table for both user and emp
        private const string TableName1 = "REG_TABLE";                
        private const string ColumnFname = "FIRST_NAME";
        private const string ColumnLname = "LAST_NAME";
        private const string ColumnUserId = "ID";
        private const string ColumnPassowrd = "PASS";
        private const string ColumnPhone = "PHONE";
        // private const string ColumnRePass = "repass";
        private const string ColumnRole = "ROLE";


     // Reg Table creation Query
     
        public const string CreateRegTable = "CREATE TABLE " +
            TableName1 + " ( " + ColumnFname + " TEXT, "
              + ColumnLname + " TEXT, "
              + ColumnUserId + " TEXT, "
              + ColumnPassowrd + " TEXT, "
              + ColumnPhone + " INTEGER, "
              //  + ColumnRePass + "TEXT,"
              + ColumnRole + " TEXT, " +
            "PRIMARY KEY(" + ColumnUserId + "));";


    // Table #2 for user or student

        private const string TableName2 = "STUDENT_TABLE";
        private const string ColumnStuId = "STU_ID";
        private const string ColumnSkills = "SKILLS";
        private const string ColumnEdu = "EDUCATION";
        private const string ColumnExp = "EXPERIENCE";
        private const string ColumnCert = "CERTIFICATION";

     // Student table creation Query
        public const string CreateStudentTable = "CREATE TABLE " +
            TableName2 + " ( " + ColumnStuId + " TEXT, "
            + ColumnSkills + " TEXT, "
            + ColumnEdu + " TEXT, "
            + ColumnExp + " TEXT, "
            + ColumnCert + " TEXT, " +
            "FOREIGN KEY ( " + ColumnStuId + " ) " + "REFERENCES " +TableName1 + " ( " +ColumnUserId +" ));" ;

       
     // Table #3 for  Employer

        private const string TableName3 = "EMP_TABLE";
        private const string ColumnEmpId = "ID";
        private const string ColumnCmp = "COMPANY";
        private const string ColumnPos = "POSITION";

     // Emp table creation Query   

        public const string CreateEmpTable = "CREATE TABLE " +
            TableName3 + " ( " + ColumnEmpId + " TEXT, "
            + ColumnCmp + " TEXT, "
            + ColumnPos + " TEXT, "
            + "FOREIGN KEY( " + ColumnEmpId + " ) " + "REFERENCES " +TableName1 + " ( " + ColumnUserId +"));" ;


        SQLiteDatabase myDBuser;    // user database
        Context myContext;
        public UserDBHelper(Context context) : base(context, name: _DatabaseName, factory: null, version: 1)
        {
            myContext = context;
            myDBuser = WritableDatabase;
        }



        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(CreateRegTable);
            db.ExecSQL(CreateStudentTable);
            db.ExecSQL(CreateEmpTable);

           
            
        }


         // insert values for reg table 
        public void insertValue(string fnameValue, string lnameValue, string emailValue, string passValue,int phone, string myroleValue)
        {
            // insert values into the user DB

            String insertSQLReg = "insert into  " + TableName1 +" ( "+ 
                                                    ColumnFname + ", "+ 
                                                    ColumnLname + ", " + 
                                                    ColumnUserId + ", " + 
                                                    ColumnPassowrd + ", " + 
                                                    ColumnPhone + ", " + 
                                                    ColumnRole + ") " +
                " values ( '" + fnameValue + "', '" + 
                               lnameValue + "', '" + 
                               emailValue + "', '" + 
                               passValue + "', " + 
                               phone + ", '" + 
                               myroleValue + "');" ;

            System.Console.WriteLine("Insert SQL " + insertSQLReg);
            myDBuser.ExecSQL(insertSQLReg);

        }

        // insert values for student table

        public void insertValue(string stuid, string skills, string education, string experience, string certification)
        {
            String insertSQLStu = "insert into "  + TableName2 + " ( " +
                                                   ColumnStuId + ", " +
                                                   ColumnSkills + ", " +
                                                   ColumnEdu + ", " +
                                                   ColumnExp + ", " +
                                                   ColumnCert + ") " +

            " values ( '" + stuid + "', '" +
                            skills + "', '" +
                            education + "', '" +
                            experience + "', '" +
                            certification + "');" ;

            System.Console.WriteLine("Insert SQL " + insertSQLStu);
            myDBuser.ExecSQL(insertSQLStu);

           
        }

        // insert values for emp table

        public void insertValue(string empid, string company, string position)
        {
            String insertSQLEmp = "insert into " + TableName3 + " ( " +
                                                   ColumnEmpId + ", " +
                                                   ColumnCmp + ", " +
                                                   ColumnPos + ") " +

            " values ( '" + empid + "', '" +
                            company + "', '" +
                            position + "');";

            System.Console.WriteLine("Insert SQL " + insertSQLEmp);
            myDBuser.ExecSQL(insertSQLEmp);
        }

        //check if user exists
        public ICursor checkIFEmailExist(String email, String password)
        {
            String sqlQuery = "Select * from " + TableName1 + " Where " + ColumnUserId + " = '" + email + "' AND " + ColumnPassowrd + " = '" + password + "'";

            ICursor result = myDBuser.RawQuery(sqlQuery, null);

            return result;
        }



        // display values for reg table
        public void selectMyValuesReg()
        {

            String sqlQuery = "Select * from " + TableName1;

            ICursor result = myDBuser.RawQuery(sqlQuery, null);

            while (result.MoveToNext())
            {
                var FNamefromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnFname));
                System.Console.WriteLine(" Value  Of FirstName  FROM DB  --> " + FNamefromDB);

                var LNamefromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnLname));
                System.Console.WriteLine(" Value  Of LastName  FROM DB  --> " + LNamefromDB);

                var IDfromDB = result.GetInt(result.GetColumnIndexOrThrow(ColumnUserId));
                System.Console.WriteLine(" Value Of ID FROM DB --> " + IDfromDB);

                var PassfromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnPassowrd));
                System.Console.WriteLine(" Value  Of Password  FROM DB --> " + PassfromDB);

                var RolefromDB = result.GetInt(result.GetColumnIndexOrThrow(ColumnRole));
                System.Console.WriteLine(" Value Of Role FROM DB --> " + RolefromDB);

            }


        }

        //trial INNER JOINT reg table + student table

        public ICursor selectfrominnerjoint1()
        {
            System.Console.WriteLine(" Value form DB ----------------------------------------->  selectfrominnerjoint1");

            String sqlQueryinner = "SELECT " +
            TableName1 + "." + ColumnFname + ", " +
            TableName1 + "." + ColumnLname + ", " +
           //  ColumnUserId + " TEXT, " +
            TableName2 + "." + ColumnEdu + 
            " FROM " + TableName1 + " INNER JOIN ( " + TableName2 + " )" +
                "ON " + TableName1 + "." + ColumnUserId + " = " + TableName2 + "." + ColumnStuId;


            ICursor myresult = myDBuser.RawQuery(sqlQueryinner, null);


            System.Console.WriteLine(" Value form DB -----------------------------------------> " + sqlQueryinner);

           // System.Console.WriteLine(" Value form DB -----------------------------------------> "+ myresult.Count);
            //System.Console.WriteLine(" Value form DB -----------------------------------------> " + myresult.GetColumnIndexOrThrow(ColumnLname));

            while (myresult.MoveToNext())
            {

               var innerfirst = myresult.GetString(myresult.GetColumnIndexOrThrow(ColumnFname));

                
                System.Console.WriteLine(" Value form DB --> " + innerfirst);

                var innerlast = myresult.GetString(myresult.GetColumnIndexOrThrow(ColumnLname));
                System.Console.WriteLine(" Value form DB --> " + innerlast);
            }

            return myresult;

        }



        //trial INNER JOINT reg table + employee table

        public ICursor selectfrominnerjoint2()
        {
            System.Console.WriteLine(" Value form DB ----------------------------------------->  selectfrominnerjoint2");

            String sqlQueryinneremp = "SELECT " +
            TableName1 + "." + ColumnFname + ", " +
            TableName1 + "." + ColumnLname + ", " +
            //  ColumnUserId + " TEXT, " +
            //TableName1 + "." + ColumnPhone + ", " +
           // TableName1 + "." + ColumnRole + ", " +
            TableName3 + "." + ColumnCmp + 
            //TableName3 + "." + ColumnPos +


           " FROM " + TableName1 + " INNER JOIN ( " + TableName3 + " )" +
            "ON " + TableName1 + "." + ColumnUserId + " = " + TableName3 + "." + ColumnEmpId; ;


            ICursor myresult = myDBuser.RawQuery(sqlQueryinneremp, null);


            System.Console.WriteLine(" Value form DB -----------------------------------------> " + sqlQueryinneremp);

            // System.Console.WriteLine(" Value form DB -----------------------------------------> "+ myresult.Count);
            //System.Console.WriteLine(" Value form DB -----------------------------------------> " + myresult.GetColumnIndexOrThrow(ColumnLname));

            while (myresult.MoveToNext())
            {

                var innerfirst = myresult.GetString(myresult.GetColumnIndexOrThrow(ColumnFname));


                System.Console.WriteLine(" Value form DB --> " + innerfirst);

                var innerlast = myresult.GetString(myresult.GetColumnIndexOrThrow(ColumnLname));
                System.Console.WriteLine(" Value form DB --> " + innerlast);
            }

            return myresult;
        }






        public ICursor getProfile(string email)
        {
            string sqlQuery = "Select * from " + TableName1 +
                                " where " + ColumnUserId + " = '" + email + "'";

            ICursor result = myDBuser.RawQuery(sqlQuery, null);

            return result;
        }

        public ICursor getStudentProfile(string email)
        {
            string sqlQuery = "Select * from " + TableName2 +
                                " where " + ColumnStuId + " = '" + email + "'";

            ICursor result = myDBuser.RawQuery(sqlQuery, null);


            while (result.MoveToNext())
            {
                var StuIDfromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnStuId));
                System.Console.WriteLine(" Value  Of StuID  FROM DB ---------------------- --> " + StuIDfromDB);

                var SkillsfromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnSkills));
                System.Console.WriteLine(" Value  Of Skills  FROM DB ----------------------------- --> " + SkillsfromDB);

                var EdufromDB = result.GetInt(result.GetColumnIndexOrThrow(ColumnEdu));
                System.Console.WriteLine(" Value Of Edu FROM DB ----------> " + EdufromDB);

                var ExpfromDB = result.GetInt(result.GetColumnIndexOrThrow(ColumnExp));
                System.Console.WriteLine(" Value Of Edu FROM DB ----------> " + ExpfromDB);

                var CertfromDB = result.GetInt(result.GetColumnIndexOrThrow(ColumnCert));
                System.Console.WriteLine(" Value Of Cert FROM DB --> " + CertfromDB);
            }

            return result;
        }


        public ICursor getEmployerProfile(string email)
        {
            string sqlQuery = "Select * from " + TableName3 +
                                " where " + ColumnEmpId + " = '" + email + "'";

            ICursor result = myDBuser.RawQuery(sqlQuery, null);


            while (result.MoveToNext())
            {
                var EmpIDfromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnEmpId));
                System.Console.WriteLine(" Value  Of StuID  FROM DB ---------------------- --> " + EmpIDfromDB);

                var CompanyfromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnCmp));
                System.Console.WriteLine(" Value  Of Skills  FROM DB ----------------------------- --> " + CompanyfromDB);

                var PosfromDB = result.GetInt(result.GetColumnIndexOrThrow(ColumnPos));
                System.Console.WriteLine(" Value Of Edu FROM DB ----------> " + PosfromDB);

            }

            return result;
        }

        // display values for Student table 

        public void selectMyValuesStu()
        {

            String sqlQuery = "Select * from " + TableName2;

            ICursor result = myDBuser.RawQuery(sqlQuery, null);

            while (result.MoveToNext())
            {
                var StuIDfromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnStuId));
                System.Console.WriteLine(" Value  Of StuID  FROM DB  --> " + StuIDfromDB);

                var SkillsfromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnSkills));
                System.Console.WriteLine(" Value  Of Skills  FROM DB  --> " + SkillsfromDB);

                var EdufromDB = result.GetInt(result.GetColumnIndexOrThrow(ColumnEdu));
                System.Console.WriteLine(" Value Of Edu FROM DB --> " + EdufromDB);

                var ExpfromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnExp));
                System.Console.WriteLine(" Value  Of Exp  FROM DB --> " + ExpfromDB);

                var CertfromDB = result.GetInt(result.GetColumnIndexOrThrow(ColumnCert));
                System.Console.WriteLine(" Value Of Cert FROM DB --> " + CertfromDB);
            }

        }

       
        // display values for Employee table 

        public void selectMyValuesEmp()
        {

            String sqlQuery = "Select * from " + TableName3;

            ICursor result = myDBuser.RawQuery(sqlQuery, null);

            while (result.MoveToNext())
            {

                var EmpIDfromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnEmpId));
                System.Console.WriteLine(" Value  Of EmpID  FROM DB  --> " + EmpIDfromDB);

                var CmpfromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnCmp));
                System.Console.WriteLine(" Value  Of Company  FROM DB  --> " + CmpfromDB);

                var PosfromDB = result.GetInt(result.GetColumnIndexOrThrow(ColumnPos));
                System.Console.WriteLine(" Value Of Pos FROM DB --> " + PosfromDB);

            }


        }


        /*
        public ICursor CheckIfEmailExist(String email, String password)
        {

            String sqlQuery = "Select * from " + TableName1 + " Where " + ColumnUserId + " = '" + email + "' AND " + ColumnPassowrd + " = '" + password + "'";

            ICursor result = myDBuser.RawQuery(sqlQuery, null);

            if (result.Count > 0)
            {

                System.Console.WriteLine(" Email found ");
                return result;

            }
            else
            {
                System.Console.WriteLine(" Email not found ");
                return result;
            }
        }


    */


        /*public void savedFavEmp(string email)
        {
            string alterStuQuery = "ALTER TABLE " + TableName2 + " ADD " + "ColumnFav " + "TEXT";
            updateEmpQuery = "UPDATE TABLE " + TableName2 + "WHERE " + ColumnStuId + " = " + email + "SET " + Colu
        }*/
        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            throw new NotImplementedException();
        }
    }
}
