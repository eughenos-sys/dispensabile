using DAbile.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DAbile
{
    public partial class EditItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["idItem"]))
                {
                    Item i = new ItemService().LoadItem(int.Parse(Request.QueryString["idItem"]));
                    this.idItem.Value = i.id.ToString();
                    this.marca.Text = i.marca.ToString();
                    this.prodotto.Text = i.prodotto.ToString();
                    this.quanti.Text = i.quanti.ToString();
                    this.scadenza.Text = i.scadenza.ToString();
                }
            }
        }

        protected void SaveItem(object sender, EventArgs e)
        {
            int id_;
            if (!String.IsNullOrEmpty(this.idItem.Value))
            {
                Item i = new Item();
                i.id = (Int32.Parse(Request.QueryString["idItem"]));
                i.marca = this.marca.Text;
                i.prodotto = this.prodotto.Text;
                i.quanti = this.quanti.Text;
                i.scadenza = this.scadenza.Text;
                id_ = new ItemService().UpdateItem(i);
            }

         else {
             Item i = new Item();
             
                 i.marca = this.marca.ToString();
                 i.prodotto = this.prodotto.ToString();
                 i.quanti = this.quanti.ToString();
                 i.scadenza = this.scadenza.ToString();
                 id_ = new ItemService().InsertItem(i);
                }
            Response.Redirect("Default.aspx");
            }
        }
    }