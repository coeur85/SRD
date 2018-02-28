using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeIssueApp.Models;

namespace CodeIssueApp.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CodeIssueApp.Models.CodeIssueEntities db = new Models.CodeIssueEntities();

                List<missingItems> miss = new List<missingItems>();



                var britmes = db.WARD_sys_item.ToList() ;
                var hqitems = db.HQ_sys_item.ToList();
                List<HQ_sys_item> q = new List<HQ_sys_item>();


                foreach (var item in britmes)
                {
                    q.Clear();
                    // q = hqitems.Where(x => x.itemean == item.itemean && x.a_name.Trim() == item.a_name.Trim()).ToList();
                    q = hqitems.Where(x => x.itemean == item.itemean).ToList();

                    if (q.Count == 0)
                    {
                        miss.Add(new missingItems
                        {
                            BritemCode = item.itemean,
                            BritemName = item.a_name
                           

                        });

                    }
                  


                }


                gv_data.DataSource = miss;
                gv_data.DataBind();


            }


        }
    }



    public class missingItems
    {
        //public string HQitemCode { get; set; }    
        public string BritemCode { get; set; }
        //public string HQitemName { get; set; }
        public string BritemName { get; set; }
        

    }

}