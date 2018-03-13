using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KokiDB;

namespace _App
{

    namespace ui
    {

        public class Message
        {

            private static List<WepApp.InfoMessages> msgs = new List<WepApp.InfoMessages>();
           


            public static void add(WepApp.InfoMessages message)
            {
                msgs.Add(message);

            }
            public static void addError(string msg)
            {
                WepApp.InfoMessages m = new WepApp.InfoMessages();
                m.MessageType = WepApp.InfoMessages.messageType.Error;
                m.Message = msg;
                add(m);

            }
            public static void addSuccess(string msg)
            {
                WepApp.InfoMessages m = new WepApp.InfoMessages();
                m.MessageType = WepApp.InfoMessages.messageType.Sucsess;
                m.Message = msg;
                add(m);

            }
            public static void SuccessAddNew()
            {
                addSuccess("New Data has been added successfully !");
            }
            public static void SuccessUpdate()
            {
                addSuccess("Data has been updated successfully !");
            }
            public static void SuccessDelete()
            {
                addSuccess("Data has been deleted successfully !");
            }


            public static List<WepApp.InfoMessages> Show { get { var r = msgs; msgs = new List<WepApp.InfoMessages>() ; return r;  }  }


        }

    }

    class Current
    {
        public static UserInfo User
        {
            get
            {
                // LoanAppDBEntities db = new LoanAppDBEntities();
                // return db.Employees.Find(9).UsersInfo;
                UserInfo u = (UserInfo)HttpContext.Current.Session["UserID"];
                if (u == null)
                {
                    u = new UserInfo();// HttpContext.Current.Response.Redirect("Login/index");
                }
                return u;
            }

            set
            {

                HttpContext.Current.Session["UserID"] = value;

            }


        }
    }

}