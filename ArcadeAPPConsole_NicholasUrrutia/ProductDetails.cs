using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ArcadeAPPConsole_NicholasUrrutia
{
    class ProductDetails
    {
        #region Product Variables
            public int pId { get; set; }
            public string pName { get; set; }
            public string pCategory { get; set; }
            public string pSize { get; set; }
            public int pQtyBought { get; set; }
            public int pQtyLeftInStock { get; set; }
            public int pPrice { get; set; }
            public DateTime pDateBought { get; set; }
            //too complex for now, circle back
            //public DateTime pDateArrived { get; set; }

        #endregion
    SqlConnection con = new SqlConnection(@"server=DESKTOP-2LDPKO5\NICHOLASINSTANCE;database=ArcadeAPPConsole_NicholasUrrutia;integrated security=true");
        public string AddNewProduct(ProductDetails newProduct)

            {
                SqlCommand cmd_addProduct = new SqlCommand("insert into ProductDetails values(@pName,@pCat,@pSize,@pQtyBought,@pQtyLeftInStock,@pPrice,@pDateBought)",con);
                
                cmd_addProduct.Parameters.AddWithValue("@pName",newProduct.pName);
                cmd_addProduct.Parameters.AddWithValue("@pCat",newProduct.pCategory);
                cmd_addProduct.Parameters.AddWithValue("@pSize",newProduct.pSize);
                cmd_addProduct.Parameters.AddWithValue("@pQtyBought",newProduct.pQtyBought);
                cmd_addProduct.Parameters.AddWithValue("@pQtyLeftInStock",newProduct.pQtyLeftInStock);
                cmd_addProduct.Parameters.AddWithValue("@pPrice",newProduct.pPrice);
                cmd_addProduct.Parameters.AddWithValue("@ppDateBought",newProduct.pDateBought);
                
                try
                {
                    con.Open();
                    cmd_addProduct.ExecuteNonQuery();                    
                }
                catch(SqlException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return "Product Added Successfully";

            }
        public string EditProduct(ProductDetails newProduct)
        {
                SqlCommand cmd_update = new SqlCommand("update ProductDetails set pName = @newPName, pSize = @newPSize, pCategory = @pNewCategory, pQtyBought = @newPQtyBought, pQtyLeftInStock = @newPQtyLIS, pPrice = @newPPrice where pId = @pId",con);
                cmd_update.Parameters.AddWithValue("@newPName",newProduct.pName);
                cmd_update.Parameters.AddWithValue("@pNewCategory",newProduct.pCategory);
                cmd_update.Parameters.AddWithValue("@newPSize",newProduct.pSize);
                cmd_update.Parameters.AddWithValue("@newPQtyBought",newProduct.pQtyBought);
                cmd_update.Parameters.AddWithValue("@newPQtyLIS",newProduct.pQtyLeftInStock);
                cmd_update.Parameters.AddWithValue("@newPPrice",newProduct.pPrice);
                cmd_update.Parameters.AddWithValue("@pId",newProduct.pId);

                try
                {
                    con.Open();
                    cmd_update.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return "Product Updated";
                
        }
        public string DeleteProduct(int id)
        {
            SqlCommand cmd_deleteProduct = new SqlCommand("delete from ProductDetails where pId=@pid",con);
            cmd_deleteProduct.Parameters.AddWithValue("@pid",id);
            try
            {
                con.Open();
                cmd_deleteProduct.ExecuteNonQuery();
            }
            catch (System.Exception es)
            {
                
                System.Console.WriteLine(es.Message);
            }
            finally
            {
                con.Close();
            }
            return "Product deleted";
        }
    
        public ProductDetails GetProductById(int id)
        {
            ProductDetails pr = new ProductDetails();
            SqlCommand cmd_search = new SqlCommand("select * from productdetails where pId =@pId",con);
            cmd_search.Parameters.AddWithValue("@pId",id);
            SqlDataReader _read = null;
            try
            {
                con.Open();
                _read = cmd_search.ExecuteReader();
                if(_read.Read()){
                    pr.pId = id;
                    pr.pName =Convert.ToString(_read[1]);
                    pr.pCategory =Convert.ToString(_read[2]);
                    pr.pSize =Convert.ToString(_read[3]);
                    pr.pQtyBought = Convert.ToInt32(_read[4]);
                    pr.pQtyLeftInStock = Convert.ToInt32(_read[5]);
                    pr.pPrice =Convert.ToInt32(_read[6]);
                    pr.pDateBought =Convert.ToDateTime(_read[7]);
                    return pr;
                }
                else
                {
                    System.Console.WriteLine("Product Not Found in System");
                }
            }
            catch (System.Exception es)
            {
                
                System.Console.WriteLine(es.Message);
            }
            finally
            {
                _read.Close();
                con.Close();
            }
        return pr;
        }

        public List<ProductDetails> GetProductList()
        {
            SqlCommand cmd_allProducts = new SqlCommand("select * from ProductDetails",con);
            SqlDataReader readProducts = null;
            List<ProductDetails> lst_ProductsFromDB = new List<ProductDetails>();

            try
            {
                con.Open();
                readProducts = cmd_allProducts.ExecuteReader();
                while (readProducts.Read())
                {
                    
                    lst_ProductsFromDB.Add(new ProductDetails()
                    {
                        pId = Convert.ToInt32(readProducts[0]),
                        pName = readProducts[1].ToString(),
                        pCategory = readProducts[2].ToString(),
                        pSize = readProducts[3].ToString(),
                        pQtyBought = Convert.ToInt32(readProducts[4]),
                        pQtyLeftInStock = Convert.ToInt32(readProducts[5]),
                        pPrice = Convert.ToInt32(readProducts[6]),
                        pDateBought = Convert.ToDateTime(readProducts[7])
                    });
                }
            }
            catch(SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                readProducts.Close();
                con.Close();
            }

    return lst_ProductsFromDB;
//DESKTOP-2LDPKO5\NICHOLASINSTANCE
        }
    }
}