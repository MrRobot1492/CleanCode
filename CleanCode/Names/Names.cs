using System.Drawing;

namespace CleanCode.Names
{
    //AVOID:
    //1.MYSTERIOUS NAMES=> int od, void Button1_Click(), class Page1, SqlDataReader dr1
    //2.NAMES WITH ENCODINGS=> int iMaxRequests
    //3.AMBIGUOS NAMES=> MultiSelect(){}, int? incidentNameId
    //4.Noisy Names => Customer theCustomer (customer), List<Customer> LisfOfApprovedCustomers (approvedCustomers)
    //NOT TOO SHORT, NOT TOO LONG
    //MEANINGFUL
    //REVEAL INTENTION
    //CHOSEN FROM PROBLEM DOMAIN

    //CLASSES, METHODS
    //input parameters, local variables _private variables, 
    public class Names
    {
        public Bitmap GenerateImage(string path)
        {
            var bitmap = new Bitmap(path);
            var graphics = Graphics.FromImage(bitmap);
            graphics.DrawString("a", SystemFonts.DefaultFont, SystemBrushes.Desktop, new PointF(0, 0));
            graphics.DrawString("b", SystemFonts.DefaultFont, SystemBrushes.Desktop, new PointF(0, 20));
            graphics.DrawString("c", SystemFonts.DefaultFont, SystemBrushes.Desktop, new PointF(0, 30));
            return bitmap;
        }
    }
}