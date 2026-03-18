using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_DL
{
    public static class FrefillKYCInfo
    {
        public static string GetIDType(string IDType)
        {
            // The switch case here is less readable because of these integral numbers
            switch (IDType)
            {
                case "PANCARD":
                    return "T";
                case "AADHAAR":
                    return "M";
                case "VOTERID":
                    return "V";
                default:
                    return "T";
            }
        }

        public static string GetIDValue(string IDType)
        {
            // The switch case here is less readable because of these integral numbers
            switch (IDType)
            {
                case "T":
                    return "PANCARD";
                case "M":
                    return "UID";
                case "V":
                    return "VOTERID";
                default:
                    return "PANCARD";
            }
        }

        public static string GetEkycTypeCode(string IDType)
        {
            // The switch case here is less readable because of these integral numbers
            switch (IDType)
            {
                case "VOTER_ID":
                    return "VID";
                case "BANKACCOUNT":
                    return "BID";
                case "AADHAAR_CARD":
                    return "ADV";
                case "AADHAAR_CARD_OTP":
                    return "GADV2";
                case "SUBMIT_ADDHAR_CARD_OTP":
                    return "SADV2";
                case "DRIVING_LICENSE":
                    return "DID";
                case "PAN_CARD_LITE":
                    return "PID";
                case "PAN_CARD_COMPREHENSIVE":
                    return "PCID";
                case "RC_FULL":
                    return "RCID";
                case "ITR_COMPLIANCE":
                    return "ITRC";
                case "VEHICLE_RC_V10":
                    return "RCV10";
                case "GST":
                    return "GSTIN";
                default:
                    return "";
            }
        }

        //public static string GetProductName(string)
        //{
        //    switch (IDType)
        //    {
        //        case "VOTER_ID":
        //            return "VID";
        //        default:
        //            return "";
        //    }
        //}

    }
}
