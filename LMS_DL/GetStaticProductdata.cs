

namespace LMS_DL
{
    public class GetStaticProductdata
    {
        public static string GetLeadStatus(string step_status)
        {
            switch (step_status)
            {
                case "1": 
                    return "New Lead";
                case "2":  
                    return "Processing";
                case "3": 
                    return "Approved";
                case "4":
                    return "eKyc";
                case "5": 
                    return "Under Disbursement";
                case "6":
                    return "Active";
                case "7":
                    return "Rejected";
                case "8":
                    return "FollowUp";
                case "9": 
                    return "Disbursement Hold";
                case "10":  
                    return "Closed";
                case "11": 
                    return "Collection";
                case "12": 
                    return "Settlement";
                case "13": 
                    return "NPA";
                case "14":
                    return "No Responce";
                case "15":
                    return "Waive Off";
                default:
                    return "New Lead";
            }
        }

        public static string repaymentfrequency(string repaymentfrequency)
        {
            switch (repaymentfrequency)
            {
                case "DAILY":
                    return "1";
                case "WEEKLY":
                    return "7";
                case "BI-WEEKLY":
                    return "14";
                case "FOURTHNIGHTLY": 
                    return "15";
                case "MONTHLY": 
                    return "30";
                //case "BULLETPAYMENT":
                //    return "0";
                default:
                    return "0";
            }
        }
        public static string getrepaymentfrequency(string repaymentfrequency)
        {
            // The switch case here is less readable because of these integral numbers
            switch (repaymentfrequency)
            {
                case "1":
                    return "Daily";
                case "7":
                    return "Weekly";
                case "14":
                    return "Bi-weekly";
                case "15":
                    return "FourthNightly";
                case "30":
                    return "Monthly";
                default:
                    return "Bulletpayment";
            }
        }
        public static string interesttype(string interesttype)
        {
            // The switch case here is less readable because of these integral numbers
            switch (interesttype)
            {
                case "FIXED":
                    return "FIX";
                case "REDUCING":
                    return "RED";
                case "FLOATING":
                    return "FLO";
                default:
                    return "RED";
            }
        }

        public static int collectionstatus(string interesttype)
        {
            // The switch case here is less readable because of these integral numbers
            switch (interesttype)
            {
                case "Pending":
                    return 0;
                case "Paid":
                    return 10;   //------------- set lead_ status 11
                case "Part":
                    return 6;
                case "Settled":
                    return 12;    //------------- set lead_ status 12
                case "Overdue":
                    return 4;
                case "Write-Off":
                    return 13;   //------------- set lead_ status 13
                case "Foreclosed":
                    return 10;  //------------- set lead_ status 11
                default:
                    return 0;
            }
        }

        public static string getinteresttype(string interesttype)
        {
            // The switch case here is less readable because of these integral numbers
            switch (interesttype)
            {
                case "FIX":
                    return "FIXED";
                case "RED":
                    return "REDUCING";
                case "FLO":
                    return "FLOATING";
                default:
                    return "RED";
            }
        }

        public static string GetCampaign(string CampaignCode="JC")
        {
            // The switch case here is less readable because of these integral numbers
            switch (CampaignCode)
            {
                case "PU":
                    return "PAISA_UDHAAR";
                case "EW":
                    return "EARLY_WAGES";
                case "JC":
                    return "JUNOON_CAPITAL";
                default:
                    return "JC";
            }
        }

        public static string GetLoanStatus(string loan_status)
        {
            // The switch case here is less readable because of these integral numbers
            switch (loan_status)
            {
                case "D":
                    return "Due";
                case "O":
                    return "Overdue";
                case "A":
                    return "Active";
                case "C":
                    return "Closed";
                default:
                    return "Active";
            }
        }

        public static string GetCodeByStateName(string stateName)
        {
            switch (stateName.Trim().ToLower())
            {
                case "jammu & kashmir": return "01";
                case "himachal pradesh": return "02";
                case "punjab": return "03";
                case "chandigarh": return "04";
                case "uttarakhand": return "05";
                case "haryana": return "06";
                case "delhi": return "07";
                case "rajasthan": return "08";
                case "uttar pradesh": return "09";
                case "bihar": return "10";
                case "sikkim": return "11";
                case "arunachal pradesh": return "12";
                case "nagaland": return "13";
                case "manipur": return "14";
                case "mizoram": return "15";
                case "tripura": return "16";
                case "meghalaya": return "17";
                case "assam": return "18";
                case "west bengal": return "19";
                case "jharkhand": return "20";
                case "odisha": return "21";
                case "chhattisgarh": return "22";
                case "madhya pradesh": return "23";
                case "gujarat": return "24";
                case "daman and diu": return "25";
                case "dadra and nagar haveli": return "26";
                case "maharashtra": return "27";
                case "andhra pradesh": return "28";
                case "karnataka": return "29";
                case "goa": return "30";
                case "lakshadweep": return "31";
                case "kerala": return "32";
                case "tamil nadu": return "33";
                case "puducherry": return "34";
                case "andaman and nicobar islands": return "35";
                case "telangana": return "36";
                case "other territory": return "97";
                case "centre jurisdiction": return "99";
                default: return "21";
            }
        }
    }
}
