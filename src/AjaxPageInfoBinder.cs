using System;
using System.Web.Mvc;

namespace CSharpisms
{
    /// <summary>
    /// This model binder converts the values produced by the DataTables plugin
    /// to a convenient AjaxPageInfo object.
    /// 
    /// If you move away from DataTables to another jquery grid plugin, then reimplementing this
    /// class should be sufficient.
    /// </summary>
    public class AjaxPageInfoBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
                                ModelBindingContext bindingContext)
        {
            AjaxPageInfo pageInfo = new AjaxPageInfo();
            ValueProviderResult val = bindingContext.ValueProvider.GetValue("iDisplayStart");
            if ((val != null) && !string.IsNullOrEmpty(val.AttemptedValue))
            {
                string incomingString = ((string[])val.RawValue)[0];
                pageInfo.Skip = Int32.Parse( incomingString );
            }
            
            val = bindingContext.ValueProvider.GetValue("iDisplayLength");
            if ((val != null) && !string.IsNullOrEmpty(val.AttemptedValue))
            {
                string incomingString = ((string[])val.RawValue)[0];
                pageInfo.Take = Int32.Parse(incomingString);
            }

            val = bindingContext.ValueProvider.GetValue("sSortDir_0");
            if ((val != null) && !string.IsNullOrEmpty(val.AttemptedValue))
            {
                string incomingString = ((string[])val.RawValue)[0];
                if(string.CompareOrdinal(incomingString, "desc") == 0)
                {
                    pageInfo.SortAscending = false;
                }
                else
                {
                    pageInfo.SortAscending = true;
                }
            }
            
            // get the name of the column to order by
            val = bindingContext.ValueProvider.GetValue("iSortCol_0");
            if ((val != null) && !string.IsNullOrEmpty(val.AttemptedValue))
            {
                string sortColumnIndex = ((string[])val.RawValue)[0];
                if(!string.IsNullOrWhiteSpace(sortColumnIndex))
                {
                    string orderByColumnRequestName = string.Format("mDataProp_{0}", sortColumnIndex);
                    val = bindingContext.ValueProvider.GetValue(orderByColumnRequestName);
                    if ((val != null) && !string.IsNullOrEmpty(val.AttemptedValue))
                    {
                        pageInfo.SortBy = ((string[])val.RawValue)[0];
                    }
                }
            }

            return pageInfo;
        }
    }
}