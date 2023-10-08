using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inf
{
    class BAL
    {

        public static bool timeHasBeenChanged = false;
        public static bool itemsHadBeenChanged = false;
        public static bool printCus = false;
        public static bool PrintKitch = false;
        public static bool timeHasBeenSubd = false;
        public static int newTimeInminits;

        public static bool okEdit = false;

        public static List<string> DrinkListName = new List<string>();
        public static List<string> FoodListName = new List<string>();
        public static List<string> ArgyListName = new List<string>();

        public static List<string> DrinkListPrice = new List<string>();
        public static List<string> FoodListPrice = new List<string>();
        public static List<string> ArgyListPrice = new List<string>();

        public static List<int> DrinkAmount = new List<int>();
        public static List<int> FoodAmount = new List<int>();
        public static List<int> ArgyAmount = new List<int>();


        public static string TotalPrice = "";
        public static string timeAndDAte = "";
        public static string TableIDLabel = "";




        public static int DrinkIDHolder;
        public static int DrinkIDPrice = 0;
        public static string DrinkNameHolder;
        public static int FoodIDHolder;
        public static int FoodIDHPrice = 0;
        public static string FoodNameHolder;
        public static int ArgyIDHolder;
        public static int ArgyIDPrice = 0;
        public static string ArgyNameHolder;

        public static int TableID;
        public static string TableName = "";
        public static int ResDuration;
        public static int TimeAndDate;
        public static int AddedLast = 0;

        public static List<int> DrinkIDHolderList = new List<int>();
        public static List<int> DrinkIDPriceList = new List<int>();
        public static List<string> DrinkNameHolderList = new List<string>();


        public static List<int> FoodIDHolderList = new List<int>();
        public static List<int> FoodIDPriceList = new List<int>();
        public static List<string> FoodNameHolderList = new List<string>();


        public static List<int> ArgyIDHolderList = new List<int>();
        public static List<int> ArgyIDPriceList = new List<int>();
        public static List<string> ArgyNameHolderList = new List<string>();

        public static DataTable ResDT = null;
        public static DataTable DrinksDT = null;
        public static DataTable FoodDT = null;
        public static DataTable ArgyDT = null;
        public static DataTable Log = null;

        public static bool dataEnterdByMenu;
        //public static bool selectOne;
        public static int PasswordFormSelector = 0;



        public static bool InsertDrinkOrder(int DrinkID, int Amount, string TimeAndDate, int ResRecordID)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertDrinkOrder";

            cm.Parameters.AddWithValue("@DrinkID", DrinkID);
            cm.Parameters.AddWithValue("@Amount", Amount);
            cm.Parameters.AddWithValue("@TimeAndDate", TimeAndDate.Trim());
            cm.Parameters.AddWithValue("@ResRecordID", ResRecordID);





            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }

        public static bool InsertFoodOrder(int FoodID, int Amount, string TimeAndDate, int ResRecordID)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertFoodOrder";

            cm.Parameters.AddWithValue("@FoodID", FoodID);
            cm.Parameters.AddWithValue("@Amount", Amount);
            cm.Parameters.AddWithValue("@TimeAndDate", TimeAndDate.Trim());
            cm.Parameters.AddWithValue("@ResRecordID", ResRecordID);





            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }
        public static bool InsertArgylah(string Argylah, int ArgylahPrice, string Color)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertArgylah";

            cm.Parameters.AddWithValue("@Argylah", Argylah);
            cm.Parameters.AddWithValue("@ArgylahPrice", ArgylahPrice);
            cm.Parameters.AddWithValue("@Color", Color);






            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }
        public static bool InsertFood(string FoodName, int FoodPrice, string Color)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertFood";

            cm.Parameters.AddWithValue("@FoodName", FoodName);
            cm.Parameters.AddWithValue("@FoodPrice", FoodPrice);
            cm.Parameters.AddWithValue("@Color", Color);






            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }
        public static bool InsertDrink(string DrinkName, int DrinkPrice, string Color)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertDrink";

            cm.Parameters.AddWithValue("@DrinkName", DrinkName);
            cm.Parameters.AddWithValue("@DrinkPrice", DrinkPrice);
            cm.Parameters.AddWithValue("@Color", Color);






            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }
        public static bool InsertArgyOrder(int ArgyID, int Amount, string TimeAndDate, int ResRecordID)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertArgyOrder";

            cm.Parameters.AddWithValue("@ArgylahID", ArgyID);
            cm.Parameters.AddWithValue("@Amount", Amount);
            cm.Parameters.AddWithValue("@TimeAndDate", TimeAndDate.Trim());
            cm.Parameters.AddWithValue("@ResRecordID", ResRecordID);





            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }
        public static bool InsertRes(int ResDuration, int TableOrPs, string TimeAndDate)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertRes";

            cm.Parameters.AddWithValue("@ResDuration", ResDuration);
            cm.Parameters.AddWithValue("@TableOrPs", TableOrPs);
            cm.Parameters.AddWithValue("@TimeAndDate", TimeAndDate.Trim());






            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }
        public static bool InsertEmpTbl(string EmpName, string Date, int Salary, int Bonus, int Penalty)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertEmpTbl";

            cm.Parameters.AddWithValue("@EmpName", EmpName);


            cm.Parameters.AddWithValue("@Date", Date);
            cm.Parameters.AddWithValue("@Salary", Salary);
            cm.Parameters.AddWithValue("@Bonus", Bonus);
            cm.Parameters.AddWithValue("@Penalty", Penalty);






            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }
        public static bool InsertExpenses(string name, int count, int priec, string date)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertExpenses";

            cm.Parameters.AddWithValue("@name", name);


            cm.Parameters.AddWithValue("@count", count);
            cm.Parameters.AddWithValue("@priec", priec);
            cm.Parameters.AddWithValue("@date", date);






            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }
        public static DataTable GetPasswords()
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();

            cm.CommandText = "GetPasswords";


            SqlConnection.ClearAllPools();
            return DAL.ExecuteSelectCommand(cm);
        }
        public static DataTable GetDrinks()
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();

            cm.CommandText = "GetDrinks";


            SqlConnection.ClearAllPools();
            return DAL.ExecuteSelectCommand(cm);
        }



        public static DataTable GetFilter()
        {










            SqlCommand cm;
            cm = DAL.CreateCommand();

            cm.CommandText = " select* from Reservation left join DrinkOrder on DrinkOrder.ResRecordID = Reservation.ID left join FoodOrder on FoodOrder.RedRecordID = Reservation.ID left join ArgylahOrder on ArgylahOrder.ResRecordID = Reservation.ID where Reservation.TimeAndDate Like '%3/15/2023%'";


            SqlConnection.ClearAllPools();
            return DAL.ExecuteSelectCommand(cm);
        }








        public static DataTable GetEmpTbl()
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();

            cm.CommandText = "GetEmpTbl";


            SqlConnection.ClearAllPools();
            return DAL.ExecuteSelectCommand(cm);
        }




        public static DataTable GetExpenses()
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();

            cm.CommandText = "GetExpenses";


            SqlConnection.ClearAllPools();
            return DAL.ExecuteSelectCommand(cm);
        }

        public static void GetLog()
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();

            cm.CommandText = "GetLogTBL";


            SqlConnection.ClearAllPools();

            Log = DAL.ExecuteSelectCommand(cm);




            Log.Columns["ID"].ColumnName = "ID";
            Log.Columns["ResOrOrderID"].ColumnName = "رقم الحجز او الطلب";
            Log.Columns["Oper"].ColumnName = "العملية";
            Log.Columns["LogDate"].ColumnName = "وقت";



        }

        public static DataTable GetReservation()
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();

            cm.CommandText = "GetReservation";


            SqlConnection.ClearAllPools();
            return DAL.ExecuteSelectCommand(cm);
        }

        public static DataTable GetArgy()
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();

            cm.CommandText = "GetArgylah";


            SqlConnection.ClearAllPools();
            return DAL.ExecuteSelectCommand(cm);
        }
        public static DataTable GetFood()
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();

            cm.CommandText = "GetFood";


            SqlConnection.ClearAllPools();
            return DAL.ExecuteSelectCommand(cm);
        }







        public static bool DelArgy(int ID)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "DelArgy";


            cm.Parameters.AddWithValue("@ID", ID);





            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }




        public static bool DelDrink(int ID)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "DelDrink";


            cm.Parameters.AddWithValue("@ID", ID);





            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }




        public static bool DelFood(int ID)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "DelFood";


            cm.Parameters.AddWithValue("@ID", ID);





            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }





        public static bool DelResAndOrders(int ID)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "DelResAndOrders";


            cm.Parameters.AddWithValue("@ID", ID);





            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }

        public static bool DelExpenses(int ID)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "DelExpenses";


            cm.Parameters.AddWithValue("@ID", ID);





            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }
        public static bool DelEmpTbl(int ID)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "DelEmpTbl";


            cm.Parameters.AddWithValue("@ID", ID);





            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }
        public static bool DelOrders(int ID)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "DelOrders";


            cm.Parameters.AddWithValue("@ID", ID);





            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }
        public static DataTable GetResByID(int ID)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();

            cm.CommandText = "GetResByID";
            cm.Parameters.AddWithValue("@ID", ID);
            SqlConnection.ClearAllPools();
            return DAL.ExecuteSelectCommand(cm);
        }
        public static DataTable GetDrinkOrderByResID(int ID)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();

            cm.CommandText = "GetDrinkOrderByResID";
            cm.Parameters.AddWithValue("@ID", ID);
            SqlConnection.ClearAllPools();
            return DAL.ExecuteSelectCommand(cm);
        }
        public static DataTable GetFoodOrderByResID(int ID)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();

            cm.CommandText = "GetFoodOrderByResID";
            cm.Parameters.AddWithValue("@ID", ID);
            SqlConnection.ClearAllPools();
            return DAL.ExecuteSelectCommand(cm);
        }
        public static DataTable GetArgyOrderByResID(int ID)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();

            cm.CommandText = "GetArgyOrderByResID";
            cm.Parameters.AddWithValue("@ID", ID);
            SqlConnection.ClearAllPools();
            return DAL.ExecuteSelectCommand(cm);
        }










        public static bool UpdateArgylahOrder(int ID, int ArgylahID, int Amount, int ResRecordID, string TimeAndDate)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "UpdateArgylahOrder";

            cm.Parameters.AddWithValue("@ID", ID);
            cm.Parameters.AddWithValue("@ArgylahID", ArgylahID);
            cm.Parameters.AddWithValue("@Amount", Amount);
            cm.Parameters.AddWithValue("@ResRecordID", ResRecordID);

            cm.Parameters.AddWithValue("@TimeAndDate", TimeAndDate);




            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }





        public static bool UpdateFoodOrder(int ID, int FoodID, int Amount, int RedRecordID, string TimeAndDate)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "UpdateArgylahOrder";

            cm.Parameters.AddWithValue("@ID", ID);
            cm.Parameters.AddWithValue("@FoodID ", FoodID);
            cm.Parameters.AddWithValue("@Amount", Amount);
            cm.Parameters.AddWithValue("@RedRecordID", RedRecordID);

            cm.Parameters.AddWithValue("@TimeAndDate", TimeAndDate);




            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }



        public static bool UpdateDrinkOrder(int ID, int DrinkID, int Amount, int ResRecordID, string TimeAndDate)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "UpdateArgylahOrder";

            cm.Parameters.AddWithValue("@ID", ID);
            cm.Parameters.AddWithValue("@DrinkID ", DrinkID);
            cm.Parameters.AddWithValue("@Amount", Amount);
            cm.Parameters.AddWithValue("@ResRecordID", ResRecordID);

            cm.Parameters.AddWithValue("@TimeAndDate", TimeAndDate);




            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }
        public static bool UpdateRes(int ID, int TableOrPs, int ResDuration, string TimeAndDate)
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "UpdateRes";

            cm.Parameters.AddWithValue("@ID", ID);
            cm.Parameters.AddWithValue("@TableOrPs ", TableOrPs);
            cm.Parameters.AddWithValue("@ResDuration", ResDuration);

            cm.Parameters.AddWithValue("@TimeAndDate", TimeAndDate);




            SqlConnection.ClearAllPools();
            return DAL.ExecuteCommand(cm);



        }







        /* public static DataTable GetBrowse()
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();

             cm.CommandText = "GetBrowse";
             cm.Parameters.AddWithValue("@Department", MainWindow.DepartmentSt);

             SqlConnection.ClearAllPools();
             return DAL.ExecuteSelectCommand(cm);
         }

         public static DataTable GetReqItem(int RequestID)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();

             cm.CommandText = "GetReqItem";
             cm.Parameters.AddWithValue("@RequestID", RequestID);

             SqlConnection.ClearAllPools();
             return DAL.ExecuteSelectCommand(cm);
         }
         public static DataTable GetRejected()
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();

             cm.CommandText = "GetRejected";
             SqlConnection.ClearAllPools();
             return DAL.ExecuteSelectCommand(cm);
         }
         public static DataTable GetAppr()
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();

             cm.CommandText = "GetAppr";
             bool flag = false || false;

             cm.Parameters.AddWithValue("@flag", Convert.ToInt32(0));
             if (flag)
             {


             }
             cm.Parameters.AddWithValue("@Department", "dep 1");

             SqlConnection.ClearAllPools();
             return DAL.ExecuteSelectCommand(cm);
         }

         public static DataTable GetSaved()
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();

             cm.CommandText = "GetSaved";
             if (MainWindow.isDepMan)
             {
                 cm.Parameters.AddWithValue("@flag", 1);
             }
             else if (!MainWindow.isApplicant && !MainWindow.isDepMan)
             {

                 cm.Parameters.AddWithValue("@flag", MainWindow.IIDD + 1);


             }
             else
             {
                 cm.Parameters.AddWithValue("@flag", MainWindow.IIDD);

             }

             cm.Parameters.AddWithValue("@isDepMan", Convert.ToInt32(MainWindow.isDepMan));
             cm.Parameters.AddWithValue("@Department", MainWindow.DepartmentSt);




             SqlConnection.ClearAllPools();
             return DAL.ExecuteSelectCommand(cm);
         }

         public static DataTable GetReqById(int RequestID)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();

             cm.CommandText = "GetReqById";
             cm.Parameters.AddWithValue("@RequestID", RequestID);
             SqlConnection.ClearAllPools();
             return DAL.ExecuteSelectCommand(cm);
         }
         public static DataTable GetOneRecItem(int ID)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();

             cm.CommandText = "GetOneRecItem";
             cm.Parameters.AddWithValue("@ID", ID);
             SqlConnection.ClearAllPools();
             return DAL.ExecuteSelectCommand(cm);
         }
         public static DataTable GetSignatureID(string Name)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();

             cm.CommandText = "GetSignatureID";
             cm.Parameters.AddWithValue("@Name", Name);
             SqlConnection.ClearAllPools();
             return DAL.ExecuteSelectCommand(cm);
         }
         public static DataTable GetSignatures(int UserID)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();

             cm.CommandText = "GetSignatures";
             cm.Parameters.AddWithValue("@UserID", UserID);
             SqlConnection.ClearAllPools();
             return DAL.ExecuteSelectCommand(cm);
         }



         public static DataTable GetRecordForPDF(int RequestID)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();

             cm.CommandText = "GetRecordForPDF";
             cm.Parameters.AddWithValue("@RequestID", RequestID);
             SqlConnection.ClearAllPools();
             return DAL.ExecuteSelectCommand(cm);
         }


         public static DataTable GetItemsForPDF(int RequestID)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();

             cm.CommandText = "GetItemsForPDF";
             cm.Parameters.AddWithValue("@RequestID", RequestID);

             SqlConnection.ClearAllPools();
             return DAL.ExecuteSelectCommand(cm);
         }
       








         public static bool InsertReqItem(int RequestID, string MatNam, string CodeNo, int Quantity, string Descr, string NeedTime, string ByWho, string Note)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();
             if (cm == null) { return false; }
             cm.CommandText = "InsertReqItem";

             cm.Parameters.AddWithValue("@RequestID", RequestID);
             cm.Parameters.AddWithValue("@MatNam", MatNam.Trim());
             cm.Parameters.AddWithValue("@CodeNo", CodeNo.Trim());
             cm.Parameters.AddWithValue("@Quantity", Quantity);
             cm.Parameters.AddWithValue("@Descr", Descr.Trim());
             cm.Parameters.AddWithValue("@NeedTime", NeedTime.Trim());
             cm.Parameters.AddWithValue("@ByWho", ByWho.Trim());
             cm.Parameters.AddWithValue("@Note", Note.Trim());




             SqlConnection.ClearAllPools();
             return DAL.ExecuteCommand(cm);



         }

         public static bool SetApprov(int RequestID, string name, int flag)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();
             if (cm == null) { return false; }
             cm.CommandText = "SetApprov";

             cm.Parameters.AddWithValue("@RequestID", RequestID);
             cm.Parameters.AddWithValue("@name", name);
             cm.Parameters.AddWithValue("@flag", flag);




             SqlConnection.ClearAllPools();
             return DAL.ExecuteCommand(cm);



         }
         public static bool Reject(int RequestID, string RejReason, string ByWho, int flag)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();
             if (cm == null) { return false; }

             cm.CommandText = "Reject";

             cm.Parameters.AddWithValue("@RequestID", RequestID);
             cm.Parameters.AddWithValue("@RejReason", RejReason);
             cm.Parameters.AddWithValue("@ByWho", ByWho);
             cm.Parameters.AddWithValue("@flag", flag);




             SqlConnection.ClearAllPools();
             return DAL.ExecuteCommand(cm);



         }


         public static bool UpdateReqItem(int ID, string Offer1, string Offer2, int TargetPrice, string name, int RequestID)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();
             if (cm == null) { return false; }
             cm.CommandText = "UpdateReqItem";

             cm.Parameters.AddWithValue("@ID", ID);
             cm.Parameters.AddWithValue("@Offer1", Offer1);
             cm.Parameters.AddWithValue("@Offer2", Offer2);
             cm.Parameters.AddWithValue("@TargetPrice", TargetPrice);
             cm.Parameters.AddWithValue("@RequestID", RequestID);
             cm.Parameters.AddWithValue("@name", name);




             SqlConnection.ClearAllPools();
             return DAL.ExecuteCommand(cm);



         }




         public static bool Submit(int RequestID, string name)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();
             if (cm == null) { return false; }
             cm.CommandText = "Submit";


             cm.Parameters.AddWithValue("@RequestID", RequestID);
             cm.Parameters.AddWithValue("@name", name);




             SqlConnection.ClearAllPools();
             return DAL.ExecuteCommand(cm);



         }

         public static bool SetItemPaid(int flag, int ID, int RequestID, string ByWho)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();
             if (cm == null) { return false; }
             cm.CommandText = "SetItemPaid";


             cm.Parameters.AddWithValue("@flag", flag);
             cm.Parameters.AddWithValue("@ID", ID);
             cm.Parameters.AddWithValue("@RequestID", RequestID);
             cm.Parameters.AddWithValue("@ByWho", ByWho);




             SqlConnection.ClearAllPools();
             return DAL.ExecuteCommand(cm);



         }
         public static bool SetItemBought(int flag, int ID, int RequestID, string ByWho)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();
             if (cm == null) { return false; }
             cm.CommandText = "SetItemBought";


             cm.Parameters.AddWithValue("@flag", flag);
             cm.Parameters.AddWithValue("@ID", ID);
             cm.Parameters.AddWithValue("@RequestID", RequestID);
             cm.Parameters.AddWithValue("@ByWho", ByWho);




             SqlConnection.ClearAllPools();
             return DAL.ExecuteCommand(cm);



         }


         public static bool DelRow(int ID, string ByWho, int RequestID)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();
             if (cm == null) { return false; }
             cm.CommandText = "DelRow";


             cm.Parameters.AddWithValue("@ID", ID);
             cm.Parameters.AddWithValue("@ByWho", ByWho);
             cm.Parameters.AddWithValue("@RequestID", RequestID);




             SqlConnection.ClearAllPools();
             return DAL.ExecuteCommand(cm);



         }
         public static bool CreateReq(string Applicant, string Department, string ConcDepMan, string ByWho)
         {
             SqlCommand cm;
             cm = DAL.CreateCommand();
             if (cm == null) { return false; }
             cm.CommandText = "CreateReq";
             cm.Parameters.AddWithValue("@Applicant", Applicant);
             cm.Parameters.AddWithValue("@Department", Department);
             cm.Parameters.AddWithValue("@ConcDepMan", ConcDepMan);
             cm.Parameters.AddWithValue("@ByWho", ByWho);
             cm.Parameters.AddWithValue("@RequestID", GetCount() + 1);



             SqlConnection.ClearAllPools();
             return DAL.ExecuteCommand(cm);



         }
*/

        public static int GetNextRes()
        {
            SqlCommand cm;
            cm = DAL.CreateCommand();
            cm.CommandText = "GetNextRes";

            SqlConnection.ClearAllPools();
            return Convert.ToInt32(DAL.ExecuteScalar(cm));



        }



    }
}
