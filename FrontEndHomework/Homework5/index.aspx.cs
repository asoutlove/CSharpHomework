using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEndHomework.Homework5
{
    public partial class index : System.Web.UI.Page
    {
        class BookInfo
        {
            public string Name { get; set; }
            public string ISBN { get; set; }
            public int Price { get; set; }
        }

        private List<BookInfo> _list = new List<BookInfo>()
        {
            new BookInfo() { Name= "超圖解 ESP32 深度實作", ISBN="9863126608", Price= 880 },
            new BookInfo() { Name= "大話設計模式", ISBN= "9866761797", Price= 620 }
        };


        public string ArrText { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> outputTextList = new List<string>();

            foreach(var book in this._list)
            {
                outputTextList.Add($@"{{ ""Name"": ""{book.Name}"", ""ISB"": ""{ book.ISBN }"", ""Price"": {book.Price} }}");
            }

            this.ArrText = "[" + string.Join(", ", outputTextList) + "]";
        }
    }
}