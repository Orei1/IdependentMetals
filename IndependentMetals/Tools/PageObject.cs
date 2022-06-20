using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentMetals
{
     public static class PageObject
    {
        public const string AcceptPolicy = "(a[contains(@class,'btn btn-secondary')])[2]";
        public const string SecondaryAccept = "a.btn.btn-secondary.accept";
        public const string TypeContainer = "#select2-type-container";
        public const string PressedContainer = "//span[@class='select2-search select2-search--dropdown']//input[1]";
        public const string FormContainer = "#select2-form-container";
        public const string WeightContainer = "#select2-weight-container";
        public const string FinenessContainer = "#select2-fineness-container";
        public const string PriceSwitch = "a[data-sort='unit-price']";
    }
}
