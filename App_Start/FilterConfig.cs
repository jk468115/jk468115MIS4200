﻿using System.Web;
using System.Web.Mvc;

namespace jk468115MIS4200
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
