using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ArcadeAPPConsole_NicholasUrrutia
{
    class CardDetails{
        #region Card Variables
            public int cId { get; set; }
            public string cName { get; set; }
            public string cEmail { get; set; }
            public int cTier { get; set; }
            public DateTime cDateSubbed { get; set; }
            public double cBalance { get; set; }
            public int cTickets { get; set; }
            //We'll work on this one later
            //public string cGameLog { get; set; }

            SqlConnection con = new SqlConnection(@"server=DESKTOP-2LDPKO5\NICHOLASINSTANCE;database=project0;integrated security=true");
        #endregion

        #region Card Methods
            public void AddFunds(double payment){
                cBalance = cBalance + (int)Math.Round(payment * 15);
            }

            public void AddTickets(int winnings){
                cTickets = cTickets + winnings;
            }

            public void CheckBalance(){
                Console.WriteLine($"Credit Balance is: {cBalance}\n");
            }

            public void CheckTickets(){
                Console.WriteLine($"Ticket Balance is: {cTickets}\n");
            }

        #endregion

        #region SQL Methods
        public string AddNewCard(CardDetails newCard)

            {
                SqlCommand cmd_addCard = new SqlCommand("insert into CardDetails values(@cName,@cEmail,@cTier,@cDateSubbed,@cBalance,@cTickets)",con);
                
                cmd_addCard.Parameters.AddWithValue("@cName",newCard.cName);
                cmd_addCard.Parameters.AddWithValue("@cEmail",newCard.cEmail);
                cmd_addCard.Parameters.AddWithValue("@cTier",newCard.cTier);
                cmd_addCard.Parameters.AddWithValue("@cDateSubbed",newCard.cDateSubbed);
                cmd_addCard.Parameters.AddWithValue("@cBalance",newCard.cBalance);
                cmd_addCard.Parameters.AddWithValue("@cTickets",newCard.cTickets);
                
                try
                {
                    con.Open();
                    cmd_addCard.ExecuteNonQuery();                    
                }
                catch(SqlException e)
                {
                    System.Console.WriteLine(e.Message);
                }
                finally
                {
                    con.Close();
                }
                return "Card Added Successfully";

            }
        public string EditCard(CardDetails newCard)
        {
                //cDateSubbed = @newCDateSubbed
                SqlCommand cmd_update = new SqlCommand("update CardDetails set cName = @newCName, cEmail = @newCEmail, cTier = @newCTier, cBalance = @newCBalance, cTickets = @newCTickets where cId = @cId",con);
                cmd_update.Parameters.AddWithValue("@newCName",newCard.cName);
                cmd_update.Parameters.AddWithValue("@newCEmail",newCard.cEmail);
                cmd_update.Parameters.AddWithValue("@newCTier",newCard.cTier);
                //cmd_update.Parameters.AddWithValue("@newCDateSubbed",newCard.cDateSubbed);
                cmd_update.Parameters.AddWithValue("@newCBalance",newCard.cBalance);
                cmd_update.Parameters.AddWithValue("@newCTickets",newCard.cTickets);
                cmd_update.Parameters.AddWithValue("@cId",newCard.cId);

                try
                {
                    con.Open();
                    cmd_update.ExecuteNonQuery();
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
                finally
                {
                    con.Close();
                }
                return "Card Updated";
                
        }
        public string DeleteCard(int id)
        {
            SqlCommand cmd_deleteCard = new SqlCommand("delete from CardDetails where cId = @cId",con);
            cmd_deleteCard.Parameters.AddWithValue("@cId",id);
            try
            {
                con.Open();
                cmd_deleteCard.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return "Card Deleted";
        }
    
        public CardDetails GetCardById(int id)
        {
            CardDetails cr = new CardDetails();
            SqlCommand cmd_search = new SqlCommand("select * from CardDetails where cId = @cId",con);
            cmd_search.Parameters.AddWithValue("@cId",id);
            SqlDataReader _read = null;
            try
            {
                con.Open();
                _read = cmd_search.ExecuteReader();
                if(_read.Read()){
                    cr.cId = id;
                    cr.cName =Convert.ToString(_read[1]);
                    cr.cEmail =Convert.ToString(_read[2]);
                    cr.cTier =Convert.ToInt32(_read[3]);
                    cr.cDateSubbed = Convert.ToDateTime(_read[4]);
                    cr.cBalance = Convert.ToDouble(_read[5]);
                    cr.cTickets =Convert.ToInt32(_read[6]);
                    return cr;
                }
                else
                {
                    System.Console.WriteLine("Card Not Found in System");
                }
            }
            catch (System.Exception e)
            {
                
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                _read.Close();
                con.Close();
            }
        return cr;
        }

        public List<CardDetails> GetCardList()
        {
            SqlCommand cmd_allCards = new SqlCommand("select * from CardDetails",con);
            SqlDataReader readCards = null;
            List<CardDetails> lst_CardsFromDB = new List<CardDetails>();

            try
            {
                con.Open();
                readCards = cmd_allCards.ExecuteReader();
                while (readCards.Read())
                {
                    
                    lst_CardsFromDB.Add(new CardDetails()
                    {
                        cId = Convert.ToInt32(readCards[0]),
                        cName = readCards[1].ToString(),
                        cEmail = readCards[2].ToString(),
                        cTier = Convert.ToInt32(readCards[3]),
                        cDateSubbed = Convert.ToDateTime(readCards[4]),
                        cBalance = Convert.ToDouble(readCards[5]),
                        cTickets = Convert.ToInt32(readCards[6]),
                    });
                }
            }
            catch(SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                readCards.Close();
                con.Close();
            }

    return lst_CardsFromDB;
//DESKTOP-2LDPKO5\NICHOLASINSTANCE
        }
        #endregion
    }
}