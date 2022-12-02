namespace BookShop.Areas.Admin.Models
{
    public class StoreContext
    {
        public string ConnectionString { get; set; }

        public StoreContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
    }
}
