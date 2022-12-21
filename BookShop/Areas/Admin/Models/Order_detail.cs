namespace BookShop.Areas.Admin.Models
{
    public class Order_detail
    {
        private string Dt_ID;
        private string Od_ID;
        private string Pd_ID;
        private string Pd_title;
        private int Quantity;
        private int Price;
        private int Total;
        private int Sub_total;
        public string dt_ID
        {
            get { return Dt_ID; }
            set { Dt_ID = value; }
        }
        public string od_ID
        {
            get { return Od_ID; }
            set { Od_ID = value; }
        }
        public string pd_ID
        {
            get { return Pd_ID; }
            set { Pd_ID = value; }
        }
        public string pd_title
        {
            get { return Pd_title; }
            set { Pd_title = value; }
        }
        public int quantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }

        public int price
        {
            get { return Price; }
            set { Price = value; }
        }
        public int total
        {
            get { return Total; }
            set { Total = value; }
        }

        public int sub_total
        {
            get { return Sub_total; }
            set { Sub_total = value; }
        }


        public Order_detail()
        {
        }
    }
}
