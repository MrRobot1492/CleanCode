
namespace CleanCode.MagicNumbers
{
    //When you have magic numbers is better to convert them into enumerations
    //1.Refactor, introduce a field
    //select constant declarations and extract the respective class
    //make the properties as public
    //2.convert manually the class into an enumeration by removing the access modifiers, and the semicolon as well
    //3.change safer the signature of the method by using resharper, Transform parameters

    //USE CONSTANTS OR ENUMS
    public enum DocumentStatus
    {
        Draft = 1,
        Lodged = 2
    }

    public class MagicNumbers
    {
        public void ApproveDocument(DocumentStatus status)
        {
            if (status == DocumentStatus.Draft)
            {
                // ...
            }
            else if (status == DocumentStatus.Lodged)
            {
                // ...
            }
        }

        public void RejectDocument(DocumentStatus status)
        {
            switch (status)
            {
                case DocumentStatus.Draft:
                    // ...
                    break;
                case DocumentStatus.Lodged:
                    // ...
                    break;
            }
        }
    }
}