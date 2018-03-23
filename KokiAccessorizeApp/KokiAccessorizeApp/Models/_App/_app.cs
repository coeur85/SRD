using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KokiDB;
using System.Web.Mvc;
using System.Reflection;
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

        public class oerder
        {

            public static string StatusCss(int stsusid)
            {

                string css = "alert-";

                if (stsusid == 1) { return null; };
                if (stsusid == 2) { css += "warning"; }
                if (stsusid == 3) { css += "dark"; }
                if (stsusid == 4) { css += "primary"; }
                if (stsusid == 5) { css += "success"; }
                if (stsusid == 6) { css += "danger"; }


                return css;
            }


        }

    }

   public class Current
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

    public class Audits
    {

        private static KokiDB.OrderAudit  audits(UserInfo u, Order o) { OrderAudit newau = new OrderAudit { AdminID = u.UserID, AuditDate = DateTime.Now , OrderID = o.OrderID, }; o.OrderAudits.Add(newau);
            return newau; }



        public static void NewForStatus1(UserInfo u, Order order) { var au = audits(u, order); order.OrderStatusID = 1;
            au.AdminNotes = "Order was created by the administrator";
            au.NewStatusID = order.OrderStatusID;  }
        public static void NewForStatus2(UserInfo u, Order order)
        {
            var au = audits(u, order); order.OrderStatusID = 2;
            au.AdminNotes = "Order is waiting to purchase materials";
            au.NewStatusID = order.OrderStatusID;
        }

        public static void NewForStatus3(UserInfo u, Order order)
        {
            var au = audits(u, order); order.OrderStatusID = 3;
            au.AdminNotes = "Order is a work in progress";
            au.NewStatusID = order.OrderStatusID;
        }


        public static void NewForStatus4(UserInfo u, Order order)
        {
            var au = audits(u, order); order.OrderStatusID = 4;
            au.AdminNotes = "Product is compelte and wiating to be deleverd";
            au.NewStatusID = order.OrderStatusID;
        }


        public static void NewForStatus5(UserInfo u, Order order)
        {
            var au = audits(u, order); order.OrderStatusID = 5;
            au.AdminNotes = "Order is compeleted and has been deleverd to customer";
            au.NewStatusID = order.OrderStatusID;
        }

        public static void NewForStatus6(UserInfo u, Order order)
        {
            var au = audits(u, order); order.OrderStatusID = 6;
            au.AdminNotes = "Product is compelte and wiating to be deleverd";
            au.NewStatusID = order.OrderStatusID;
        }


        public static void NewForStatus1(Order order){  NewForStatus1(_App.Current.User, order); }
        public static void NewForStatus2(Order order) { NewForStatus2(_App.Current.User, order); }
        public static void NewForStatus3(Order order) { NewForStatus3(_App.Current.User, order); }
        public static void NewForStatus4(Order order) { NewForStatus4(_App.Current.User, order); }
        public static void NewForStatus5(Order order) { NewForStatus5(_App.Current.User, order); }
        public static void NewForStatus6(Order order) { NewForStatus6(_App.Current.User, order); }

    }


}





[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class MultipleButtonAttribute : ActionNameSelectorAttribute
{
    public string Name { get; set; }
    public string Argument { get; set; }

    public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
    {
        var isValidName = false;
        var keyValue = string.Format("{0}:{1}", Name, Argument);
        var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);

        if (value != null)
        {
            controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
            isValidName = true;
        }

        return isValidName;
    }
}


