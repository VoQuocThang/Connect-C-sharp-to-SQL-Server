# Connect-C-sharp-to-SQL-Server
Step to step how to connect C# to SQL Server.

Use System.Data as a library supports for Database Management 

1. HOW TO CONNECT?
- Create a variable that has 'SqlConnection' type
- Use a string (URL) to contain information of the connection.
  URL includes :  + Data Source: Name of server 
                  + Intial Catalog: Name of Database
                  + Integrated Security: True or False
                  + User ID: User Name 
                  + Password: Password
  Ex: URL = @"Data Source=SERVER_NAME;Initial Catalog=DATABASE_NAME;Integrated Security=False;User ID=sa;Password=your_password"
- Bind connection wih URL 
- Call open() to open a connection with database.
- Call close() to close connection with database.
2. HOW TO FETCH DATA?
- Create a variable type of 'SQLCommand' (SQLCommand is a class responsible for read and write data into or from database)
- Create a cursor to read Data. In C#, it's called 'SqlDataReader'
- Save your query in string
- Bind connection and your query into command
- Execute your (read) command (ExecuteReader)
- While( cursor.Read() ) to continue to read data
- Call GetValue(index) to get value of a specific column
- Dipose your command when it's done

3. HOW TO VIEW DATA IN TABLE?
- Bind connection and your query into command
- Put command into SqlDataAdapter
- Create a DataTable
- Use the result in adater to fill the table (adapter.Fil(table))
- Draw a dataGridView in your Design form
- Binding your DataTable into DataResoure of dataGridView (dataGridView.DataSource = new BindingSource(table,null))

4. HOW TO INSERT/UPDATE/DELETE DATA?
- Create a SqlDataAdapter (We use SqlDataAdapter to insert/update/delete data)
- Put connection and query into InsertCommand/UpdateCommand/DeleteComand
- Execute it with non query as parameter

Reference: https://www.guru99.com/c-sharp-access-database.html
       
