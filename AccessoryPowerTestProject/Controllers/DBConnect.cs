using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;
using System.Data;

//This is the DB Controller.
namespace AccessoryPowerTestProject
{
    class DBConnect
    {
        #region Variables & Constructor
        private MySqlConnection connection;
        private MySqlDataAdapter mySqlDataAdapter;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }
        //Initialize values
        private void Initialize()
        {
            connection = new MySqlConnection("SERVER=184.168.74.225;PORT=3306;DATABASE=devacce_testing3;UID=devacce_testdev3;PWD=F942/0987iW6Y=8;");
        }

        #endregion

        #region Connection 
        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion

        #region Insert Statements

            #region Products
            //Insert Product
            public void InsertProduct(ProductItem p)
            {
                //Adding Product
                string partIdValue = (p.PartId == -1) ? "NULL" : p.PartId.ToString();

                string query = "INSERT INTO products (title, number, price, kit_flag, part_id) VALUES('"
                    + p.Title + "', '"
                    + p.Number + "', '"
                    + p.Price + "', '"
                    + p.Kit + "', '"
                    + partIdValue + "')";

                //Open Connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    //Get the Product ID from DB
                    p.ID = Convert.ToInt32(cmd.LastInsertedId);

                    //Close connection
                    this.CloseConnection();
                }

                //If this is a Kit Product, add the new relations.
                if (p.Kit == 1)
                {
                    InsertKitRelation(p);
                }
            }

            //Insert Kit Relations
            public void InsertKitRelation(ProductItem p)
            {
                int partsCount = p.GetParts().Count;

                if (partsCount > 0)
                {
                    //Open Connection
                    if (this.OpenConnection() == true)
                    {
                        string query = string.Empty;
                        int partId = -1;

                        for (int i = 0; i < partsCount; i++)
                        {
                            partId = p.GetParts()[i];
                            query = "INSERT INTO kit_relations (product_id, part_id, part_qty) VALUES('"
                                            + p.ID + "', '"
                                            + partId + "', '1')";

                            //create command and assign the query and connection from the constructor
                            MySqlCommand cmd = new MySqlCommand(query, connection);

                            //Execute command
                            cmd.ExecuteNonQuery();
                        }

                        //Close Connection
                        this.CloseConnection();
                    }
                }
            }
            #endregion

            #region Parts
            //Insert Part
            public void InsertPart(PartItem p)
            {
                //Adding Part
                string query = "INSERT INTO parts (part_name, number, description) VALUES('"
                    + p.Name + "', '"
                    + p.Number + "', '"
                    + p.Description + "')";

                //Open Connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    //Get the Product ID from DB
                    p.ID = Convert.ToInt32(cmd.LastInsertedId);


                    //Update Quantity
                    query = "INSERT INTO inventory (part_id, quantity) VALUES('"
                    + p.ID + "', '"
                    + p.Quantity + "')";
                    
                    cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    //Close connection
                    this.CloseConnection();
                }
            }
            #endregion

        #endregion

        #region Update Statements

            #region Products
            //Update statement
            public void UpdateProduct(ProductItem p)
            {
                string query = string.Empty;
                MySqlCommand cmd;

                int kitValue = (p.GetParts().Count > 1) ? 1 : 0;
                string partIdValue = (p.PartId == -1) ? "NULL" : p.PartId.ToString();

                //Delete Old Relations and Add the updated ones.
                if (this.OpenConnection() == true)
                {
                    //We have to Delete the Kit Relations first
                    query = "DELETE FROM kit_relations WHERE product_id = " + p.ID;
                    cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    //Closing Connection
                    this.CloseConnection();
                }

                //If this is a Kit Product, add the new relations.
                if (kitValue == 1)
                {
                    InsertKitRelation(p);
                }

                //Update the product details
                if (this.OpenConnection() == true)
                {
                    //Update Product Details
                    query = @"UPDATE products SET title='"
                        + p.Title + "', number='"
                        + p.Number + "', price="
                        + p.Price + ", kit_flag="
                        + kitValue + ", part_id="
                        + partIdValue + " WHERE id='"
                        + p.ID + "'";

                    cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    //Closing Connection
                    this.CloseConnection();
                }
            }
            #endregion

            #region Parts
            //Update statement
            public void UpdatePart(PartItem p)
            {
                string query = string.Empty;
                MySqlCommand cmd;

                if (this.OpenConnection() == true)
                {
                    //Update Part Details
                    query = @"UPDATE parts SET part_name='"
                        + p.Name + "', number='"
                        + p.Number + "', description='"
                        + p.Description + "' WHERE id='"
                        + p.ID + "'";

                    cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    //Update Quantity
                    query = @"UPDATE inventory SET quantity='"
                        + p.Quantity + "' WHERE part_id='"
                        + p.ID + "'";

                    cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    //Closing Connection
                    this.CloseConnection();
                }
            }
            #endregion

        #endregion
        
        #region Delete Statements

            #region Products
            //Delete Product
            public int DeleteProduct(int id)
            {
                int result = 0;
                //We have to Delete the Kit Relations first
                string query = "DELETE FROM kit_relations WHERE product_id = " + id;

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    //Then Deleting the Product from the Products Table
                    query = "DELETE FROM products WHERE id = " + id;
                    cmd = new MySqlCommand(query, connection);
                    result = cmd.ExecuteNonQuery();

                    //Closing Connection
                    this.CloseConnection();
                }

                return result;
            }
            #endregion

            #region Parts
            //Delete Part
            public int DeletePart(int id)
            {
                int result = 0;
                List<int> relatedProductsIds = GetProductsFromPartID(id);

                if (this.OpenConnection() == true)
                {
                    string query = string.Empty;
                    MySqlCommand cmd;

                    //Delete related products
                    if (relatedProductsIds.Count > 0)
                    {
                        #region Set IDs String
                        string ids = string.Empty;
                        for (int i = 0; i < relatedProductsIds.Count; i++)
                        {
                            if (i == relatedProductsIds.Count - 1)
                            { 
                                ids += relatedProductsIds[i]; 
                            }
                            else 
                            { 
                                ids += relatedProductsIds[i] + ", "; 
                            }
                        }
                        #endregion

                        //Delete the related Products relations
                        query = "DELETE FROM kit_relations WHERE product_id IN (" + ids + ")";
                        cmd = new MySqlCommand(query, connection);
                        result = cmd.ExecuteNonQuery();

                        //Delete the related Products
                        query = "DELETE FROM products WHERE id IN (" + ids + ")";
                        cmd = new MySqlCommand(query, connection);
                        result = cmd.ExecuteNonQuery();
                    }

                    //We have to Delete the Relations first
                    query = "DELETE FROM inventory WHERE part_id = " + id;
                    cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    //Then Deleting the part from the Parts Table
                    query = "DELETE FROM parts WHERE id = " + id;
                    cmd = new MySqlCommand(query, connection);
                    result = cmd.ExecuteNonQuery();

                    //Closing Connection
                    this.CloseConnection();
                }

                return result;
            }
            #endregion

        #endregion

        #region Select Statements

            #region Products
            //Select All Products
            public DataTable SelectAllProducts()
            {
                DataTable dataTable = new DataTable();
                string query = @"SELECT DISTINCT p.id AS ID, p.title AS 'Product Title', p.number AS 'Product Number', 
                                                 p.price AS 'Product Price', p.kit_flag AS 'Kit?', 
                                                 (SELECT part_name FROM parts WHERE id = p.part_id) AS 'Part Name',
                                                 IF(p.kit_flag=1,(SELECT MIN(quantity) FROM inventory WHERE part_id IN (SELECT part_id FROM kit_relations WHERE product_id = p.id)), (SELECT quantity FROM inventory WHERE part_id = p.part_id)) AS 'Available'
                                  FROM products p";

                //Open connection
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    mySqlDataAdapter = new MySqlDataAdapter(query, connection);
                    mySqlDataAdapter.Fill(dataTable);

                    //Close Connection
                    this.CloseConnection();

                    //Return Results
                    return dataTable;
                }
                else
                {
                    return dataTable;
                }
 
            }

            //Select Product by ID
            public ProductItem SelectProduct(int id)
            {
                ProductItem p = new ProductItem();
                string query = @"SELECT * FROM products WHERE id=" + id;

                //Open connection
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        p.ID = Convert.ToInt32(dataReader["id"]);
                        p.Title = dataReader["Title"].ToString();
                        p.Price = Convert.ToDouble(dataReader["price"]);
                        p.Number = dataReader["number"].ToString();
                        p.Kit = Convert.ToInt32(dataReader["kit_flag"]);
                        if (dataReader["part_id"].ToString() != "")
                        {
                            p.PartId = Convert.ToInt32(dataReader["part_id"].ToString());
                        }
                    }
                    //close Data Reader
                    dataReader.Close();

                    //Get all Parts associated with the Product
                    if (p.Kit == 1)
                    {
                        query = @"SELECT part_id FROM kit_relations WHERE product_id=" + p.ID;

                        cmd = new MySqlCommand(query, connection);

                        //Create a data reader and Execute the command
                        dataReader = cmd.ExecuteReader();

                        //Read the data and store them in the list
                        while (dataReader.Read())
                        {
                            p.AddPart(Convert.ToInt32(dataReader["part_id"]));
                        }
                        //close Data Reader
                        dataReader.Close();
                    }
                    else
                    {
                        p.AddPart(p.PartId);
                    }
                    //close Connection
                    this.CloseConnection();
                }

                return p;
            }
            #endregion

            #region Parts
            //Select All Parts
            public DataTable SelectAllParts()
            {
                DataTable dataTable = new DataTable();
                string query = @"SELECT DISTINCT p.id AS 'ID', p.part_name AS 'Part Name', p.number AS 'Part Number', (SELECT quantity FROM inventory WHERE part_id = p.id) AS 'Quantity'
                                 FROM parts p";

                //Open connection
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    mySqlDataAdapter = new MySqlDataAdapter(query, connection);
                    mySqlDataAdapter.Fill(dataTable);

                    //Close Connection
                    this.CloseConnection();
                
                    //Return Results
                    return dataTable;
                }

                else
                {
                    return dataTable;
                }
            }
            //Select Product by ID
            public PartItem SelectPart(int id)
            {
                PartItem p = new PartItem();
                string query = @"SELECT * FROM parts WHERE id=" + id;

                //Open connection
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        p.ID = Convert.ToInt32(dataReader["id"]);
                        p.Name = dataReader["part_name"].ToString();
                        p.Number = dataReader["number"].ToString();
                        p.Description = dataReader["description"].ToString();
                    }
                    //close Data Reader
                    dataReader.Close();

                    //Get Inventory Details
                    
                    query = @"SELECT quantity FROM inventory WHERE part_id=" + p.ID;
                    cmd = new MySqlCommand(query, connection);
                    
                    //Create a data reader and Execute the command
                    dataReader = cmd.ExecuteReader();
                    
                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        p.Quantity = (Convert.ToInt32(dataReader["quantity"]));
                    }
                    //close Data Reader
                    dataReader.Close();
                }
                    
                //close Connection
                this.CloseConnection();

                return p;
            }
            //Select Associated Products Count
            public int GetRelatedProductsCount(int id)
            {
                int count = -1;

                //Open connection
                if (this.OpenConnection() == true)
                {
                    string query = @"SELECT COUNT(part_id) FROM products WHERE part_id=" + id;
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    count = int.Parse(cmd.ExecuteScalar().ToString());

                    //If count is 0, The part maybe used in a Kit Product
                    if (count == 0)
                    {
                        query = @"SELECT COUNT(product_id) FROM kit_relations WHERE part_id=" + id;
                        cmd = new MySqlCommand(query, connection);
                        count = int.Parse(cmd.ExecuteScalar().ToString());
                    }

                    //close Connection
                    this.CloseConnection();
                }

                return count;
            }
            //Select Products from Part ID
            public List<int> GetProductsFromPartID(int id)
            {
                List<int> result = new List<int>();
                //Open connection
                if (this.OpenConnection() == true)
                {
                    string query = @"SELECT id FROM products WHERE part_id=" + id;
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                       result.Add(Convert.ToInt32(dataReader["id"]));
                    }
                    //close Data Reader
                    dataReader.Close();

                    query = @"SELECT product_id AS 'id' FROM kit_relations WHERE part_id=" + id;
                    cmd = new MySqlCommand(query, connection);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result.Add(Convert.ToInt32(dataReader["id"]));
                    }
                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();
                }

                return result;
            }
            #endregion

        #endregion
    }
}
