using DAbile.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DAbile
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> li = new ItemService().ItemList();
            this.ItemGrid.DataSource = li;
            this.ItemGrid.DataBind();
        }

        protected void ItemGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int b = new ItemService().DeleteItem(id);
                List<Item> li = new ItemService().ItemList();
                this.ItemGrid.DataSource = li;
                this.ItemGrid.DataBind();
            }
        }
        protected void ItemGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            /* int id = Convert.ToInt32(e.RowIndex);
             int b = new ItemService().DeleteItem(id);
             List<Item> i = new ItemService().ItemList();
             this.ItemGrid.DataSource = i;
             this.ItemGrid.DataBind(); */
        }
    }
}