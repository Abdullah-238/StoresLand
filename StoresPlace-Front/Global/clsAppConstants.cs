using StoresLand_API;


namespace StoresPlace_Front.Global
{
    public class clsAppConstants
    {
        static public string Email = clsUtil.ComputeHash("Email");

        static public string Password = clsUtil.ComputeHash("Password");

        static public string ItemsLastUpdated = clsUtil.ComputeHash("ItemsLastUpdated");

    }
}
