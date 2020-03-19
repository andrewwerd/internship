using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
   static class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var sqlCommandText1 = "IF OBJECT_ID(N'Customers', N'U') IS NULL CREATE TABLE Customers(CustomerId int not null identity(1,1) primary key, First_Name NVARCHAR(40),Last_Name NVARCHAR(40))";
                var sqlCommandText2 = "IF OBJECT_ID(N'Orders', N'U') IS NULL CREATE TABLE Orders(OrderId int not null identity(1,1) primary key, OrderName NVARCHAR(40), Price decimal(5,2) not null, Quantity int not null, CustomerId int foreign key references Customers(CustomerId))";
                using (var sqlCommand = new SqlCommand(sqlCommandText1, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
                using (var sqlCommand = new SqlCommand(sqlCommandText2, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var customersDataAdapter = CustomerDataAdapter(new SqlConnection(connectionString));
                var ordersDataAdapter = OrderDataAdapter(new SqlConnection(connectionString));
                DataSet dataSet = new DataSet();

                customersDataAdapter.Fill(dataSet, "Customers");
                ordersDataAdapter.Fill(dataSet, "Orders");
               // dataSet.Relations.Add("CustOrders", dataSet.Tables["Customers"].Columns["CustomerId"], dataSet.Tables["Orders"].Columns["CustomerId"]);

                DataTable customersTable = dataSet.Tables["Customers"];
                DataTable ordersTable = dataSet.Tables["Orders"];

                customersTable.AddNewCustomer("John", "Doe");
                customersTable.AddNewCustomer("Joshua", "Brooks");
                customersTable.AddNewCustomer("Jane", "Arnold");
                customersTable.AddNewCustomer("Patricia", "Burns");
                customersTable.AddNewCustomer("Sabrina", "McBride");
                customersTable.AddNewCustomer("Gordon", "Moody");
                customersTable.AddNewCustomer("Tyrone", "Moody");

                ordersTable.AddNewOrder("Apples", 25, 2, 1);
                ordersTable.AddNewOrder("Smartphone", 2000, 1, 1);
                ordersTable.AddNewOrder("Marshmallows", 30, 10, 1);
                ordersTable.AddNewOrder("Cake", 100, 6, 3);
                ordersTable.AddNewOrder("Pie", 25, 2, 7);
                ordersTable.AddNewOrder("Apples", 25, 13, 5);
                ordersTable.AddNewOrder("Smartphone", 3000, 2, 4); 
                ordersTable.AddNewOrder("Cheese", 34, 8, 3);
                ordersTable.AddNewOrder("Cola", 20, 5, 2);
                ordersTable.AddNewOrder("Dress", 300, 1, 3);

                customersDataAdapter.Update(customersTable);
                ordersDataAdapter.Update(ordersTable);
            }

        }
        public static SqlDataAdapter CustomerDataAdapter(SqlConnection sqlConnection)
        {
            SqlDataAdapter customersDataAdapter = new SqlDataAdapter();

             //SelectCommand
            SqlCommand command = new SqlCommand("SELECT * FROM Customers", sqlConnection);

            customersDataAdapter.SelectCommand = command;

            //InsertComand
            var insertText = "INSERT INTO Customer(First_Name, Last_Name) VALUES(@First_Name, @Last_Name)";

            SqlCommand insertCommand = new SqlCommand(insertText, sqlConnection);
            insertCommand.Parameters.Add("@First_Name", SqlDbType.NVarChar, 40, "First_Name");
            insertCommand.Parameters.Add("@Last_Name", SqlDbType.NVarChar, 40, "Last_Name");

            customersDataAdapter.InsertCommand = insertCommand;

            //UpdateComand
            command = new SqlCommand( "UPDATE Customers SET First_Name = @First_Name, Last_Name = @Last_Name " +
                                      "WHERE CustomerId = @CustomerId", sqlConnection);

            command.Parameters.Add("@First_Name", SqlDbType.NVarChar, 40, "First_Name");
            command.Parameters.Add("@Last_Name", SqlDbType.NVarChar, 40, "Last_Name");
            SqlParameter parameter = command.Parameters.Add("@CustomerId", SqlDbType.BigInt);
            parameter.SourceVersion = DataRowVersion.Original;

            customersDataAdapter.UpdateCommand = command;

            //DeleteCommand
            command = new SqlCommand("DELETE FROM Customers WHERE CustomerId = @CustomerId", sqlConnection);

            parameter = command.Parameters.Add("@CustomerId", SqlDbType.BigInt);
            parameter.SourceVersion = DataRowVersion.Original;

            customersDataAdapter.DeleteCommand = command;

            return customersDataAdapter;
        }
        public static SqlDataAdapter OrderDataAdapter(SqlConnection sqlConnection)
        {
            SqlDataAdapter ordersDataAdapter = new SqlDataAdapter();

            //SelectCommand
            var command = new SqlCommand("SELECT * FROM Orders", sqlConnection);
            ordersDataAdapter.SelectCommand = command;

            //InsertCommand
            var insertText = "INSERT INTO Orders( OrderName, Price, Quantity, CustomerId) VALUES(@OrderName, @Price, @Quantity, @CustomerId)";

            var insertCommand = new SqlCommand(insertText, sqlConnection);
            insertCommand.Parameters.Add("@OrderName", SqlDbType.NVarChar, 255, "OrderName");
            insertCommand.Parameters.Add("@Price", SqlDbType.Decimal);
            insertCommand.Parameters.Add("@Quantity", SqlDbType.Int);
            insertCommand.Parameters.Add("@CustomerId", SqlDbType.Int);

            ordersDataAdapter.InsertCommand = insertCommand;

            //UpdateCommand
            command = new SqlCommand("UPDATE Orders SET OrderName = @OrderName, Price = @Price, Quantity = @Quantity, CustomerId = @CustomerId" +
                                          "WHERE OrderID = @OrderID", sqlConnection);

            command.Parameters.Add("@OrderName", SqlDbType.NVarChar, 255, "OrderName");
            command.Parameters.Add("@Price", SqlDbType.Decimal);
            command.Parameters.Add("@Quantity", SqlDbType.Int);
            command.Parameters.Add("@CustomerId", SqlDbType.Int);
            var parameter = command.Parameters.Add("@OrderId", SqlDbType.BigInt);
            parameter.SourceVersion = DataRowVersion.Original;

            ordersDataAdapter.UpdateCommand = command;

            //DeleteCommand
            command = new SqlCommand("DELETE FROM Orders WHERE OrderId = @OrderId", sqlConnection);

            parameter = command.Parameters.Add("@OrderId", SqlDbType.BigInt);
            parameter.SourceVersion = DataRowVersion.Original;

            ordersDataAdapter.DeleteCommand = command;

            return ordersDataAdapter;
        }

        public static void AddNewCustomer(this DataTable customersTable, string first_Name, string last_Name)
        {
            DataRow customersRow = customersTable.NewRow();

            customersRow["First_Name"] = first_Name;
            customersRow["Last_Name"] = last_Name;

            customersTable.ImportRow(customersRow);
        }
        public static void AddNewOrder( this DataTable ordersTable,string orderName, decimal price, int quantity, int customerId)
        {
            DataRow orderRow = ordersTable.NewRow();

            orderRow["OrderName"] = orderName;
            orderRow["Price"] = price;
            orderRow["Quantity"] = quantity;
            orderRow["CustomerId"] = customerId;

            ordersTable.ImportRow(orderRow);
        }
    }
}
