using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Classes
{
    public class UserInformation
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
    public static class UserSession
    {
        private static List<UserInformation> _userInformationArray = new List<UserInformation>();

        public static List<UserInformation> UserInformationArray
        {

            get { return _userInformationArray; }
        }

        public static List<UserInformation> GetUserInformation()
        {
            Debug.WriteLine(_userInformationArray.Count);
            return _userInformationArray;
        }

        public static void AddUser(UserInformation userInfo)
        {
           

            try
            {
               Debug.WriteLine(userInfo.Email);
                _userInformationArray.Add(userInfo);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in adding user information "+ ex.Message);
            }
        }

        public static void ClearUser()
        {
            try
            {
                _userInformationArray.Clear();
                Debug.WriteLine("This is the length of the user session: "+_userInformationArray.Count);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error clearing the user session " + ex.Message);
            }
        }

    }
}
