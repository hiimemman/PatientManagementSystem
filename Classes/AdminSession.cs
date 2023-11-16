using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PatientManagementSystem.Classes
{

    public class AdminSessionInformation
    {
        public int Id { get; set; }
        public string Password { get; set; }
       
    }
   public static class AdminSession
    {
        private static List<AdminSessionInformation> _adminSession = new List<AdminSessionInformation>();

        public static List<AdminSessionInformation> UserInformationArray
        {

            get { return _adminSession; }
        }

        public static List<AdminSessionInformation> GetUserInformation()
        {
            Debug.WriteLine(_adminSession.Count);
            return _adminSession;
        }

        public static void AddUser(AdminSessionInformation userInfo)
        {


            try
            {
                Debug.WriteLine(userInfo.Id);
                _adminSession.Add(userInfo);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in adding user information " + ex.Message);
            }
        }

        public static void ClearUser()
        {
            try
            {
                _adminSession.Clear();
                Debug.WriteLine("This is the length of the user session: " + _adminSession.Count);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error clearing the user session " + ex.Message);
            }
        }

    }
}
