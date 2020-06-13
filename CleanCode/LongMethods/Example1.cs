using System;
using System.IO;
using System.Web;

namespace FooFoo
{
    #region Comments

    //Long methods are the ones with more than 10 lines
    //problems
    //hard to understand
    //hard to change
    //hard to re-use
    //methods that specialise in one thing

    //How I know if some lines belong a method or a class or not?
    //Cohesion
    //Things that are relate, would be together
    //Things that are not related, should not be together

    //Single responsability principle
    //A class/method should do only one thing, and do it very well
    
    //this class must only present data

    //Extract Class in the case the class has no related to presentation layer

    #endregion

    public partial class Download : System.Web.UI.Page
    {
        private readonly DataTableToCsvMapper _dataTableToCsvMapper = new DataTableToCsvMapper();
        private readonly TableReader _tableReader = new TableReader();

        protected void Page_Load(object sender, EventArgs e)
        {

            ClearResponse();

            SetCacheability();

            WriteContentToResponse(GetCsv());
        }

        private byte[] GetCsv()
        {
            MemoryStream ms = _dataTableToCsvMapper.Map(_tableReader.GetDataTable("[FooFoo]"));
            byte[] byteArray = ms.ToArray();
            ms.Flush();
            ms.Close();
            return byteArray;
        }

        private void WriteContentToResponse(byte[] byteArray)
        {
            Response.Charset = System.Text.Encoding.UTF8.WebName;
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "text/comma-separated-values";
            Response.AddHeader("Content-Disposition", "attachment; filename=FooFoo.csv");
            Response.AddHeader("Content-Length", byteArray.Length.ToString());
            Response.BinaryWrite(byteArray);
        }

        private void SetCacheability()
        {
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.CacheControl = "private";
            Response.AppendHeader("Pragma", "cache");
            Response.AppendHeader("Expires", "60");
        }

        private void ClearResponse()
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Cookies.Clear();
        }
    }
}