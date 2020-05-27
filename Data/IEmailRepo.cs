using System.Collections.Generic;

namespace UniqueEmails.Data
{
    public interface IEmailRepo
    {
        IEnumerable<string> GetUniqueEmails(string emailString);
    }
}