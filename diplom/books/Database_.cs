using Database;
namespace books
{
    public class Database_
    {
        public static ApplicationContext context;

        public static void OpenDatabase() {
            context = new ApplicationContext();
        }
    }
}
