using System.Collections.Generic;
using System.Linq;

namespace UniqueEmails.Data
{
    public class EmailRepo : IEmailRepo
    {
        public IEnumerable<string> GetUniqueEmails(string emailString)
        {
            var emails = emailString.ToLower().Trim().Split(',');

            HashSet<string> set = new HashSet<string>();
            
            foreach(var email in emails) {
                var userName = email.Split('@')[0].Trim();
                var emailService = email.Split('@')[1].Trim();

                //Remove "." from userName part
                userName = userName.Replace(".","");
                
                //If userName has "+" or "-", discard the rest of the string
                int idx = userName.IndexOf("+");
                if (idx > -1) {
                    userName = userName.Substring(0, idx);
                }
                idx = userName.IndexOf("-");
                if (idx > -1) {
                    userName = userName.Substring(0, idx);
                }

                if (userName.Length == 0)
                    continue;

                set.Add(userName + "@" + emailService);
            }

            return set.AsEnumerable();
        }
    }
}