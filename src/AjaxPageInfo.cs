using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpisms
{
    public class AjaxPageInfo
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool SortAscending { get; set; }
        public string SortBy { get; set; }

        public AjaxPageInfo()
        {
            Skip = 0;
            Take = 10;
            SortAscending = false;
            SortBy = string.Empty;
        }
    }
}