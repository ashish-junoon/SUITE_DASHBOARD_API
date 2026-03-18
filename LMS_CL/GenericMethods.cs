using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

namespace LMS_CL

{
    public static class GenericMethods
    {
        //private static string KeyForEncript = "1a2s3d4f5g6h7j8k9lA1S2D3F4G5H6J7K8L9";
       // public static object StringCases { get; private set; }
        public static string ConvertToBase64String(Byte[] bytes)
        {
            return Convert.ToBase64String(bytes,0,bytes.Length);
        }

        public static Byte [] ConvertToByteFrom64String(string base64String)
        {
            try
            {
              return  Convert.FromBase64String(base64String);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ------------------------------ Encode and Decode Password written code by Namrata singh ------------------------
        public static string Encodestring(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public static string Decodestring(string encodedData)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(encodedData);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new System.String(decoded_char);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64decode" + ex.Message);
            }
        }

        public static bool IsBase64String(string base64)
        {
            base64 = base64.Trim();
            return (base64.Length % 4 == 0) && Regex.IsMatch(base64, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        public static string RemoveSpecialCharacter(string character)
        {
            string _character= character.ToLower().Replace(" ", "_");
            string my_String = Regex.Replace(character, @"[^0-9a-zA-Z]+" ,"");
            my_String.ToLower().Replace(" ", "_");
            return my_String;
        }

        public static string ManageURL(string pagegroup ,string pagename)
        {
            string _pagename = Regex.Replace(pagename, @"[^0-9a-zA-Z]+", "");
            _pagename.ToLower().Replace(" ", "_");
            string url = "/" + pagegroup + "/" + _pagename;
            return url;
        }



        //---------------------------- End ---------------------------------------------------------
    }
}
