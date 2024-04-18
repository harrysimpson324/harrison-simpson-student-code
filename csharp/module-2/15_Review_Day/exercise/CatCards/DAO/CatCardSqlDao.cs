using CatCards.Exceptions;
using CatCards.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CatCards.DAO
{
    public class CatCardSqlDao : ICatCardDao
    {
        private readonly string connectionString;

        public CatCardSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<CatCard> GetCatCards()
        {
            IList<CatCard> catCards = new List<CatCard>();

            string sql = "SELECT id, img_url, fact, caption FROM catcards";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CatCard catCard = MapRowToCatCard(reader);
                        catCards.Add(catCard);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return catCards;
        }

        public CatCard GetCatCardById(int id)
        {
            CatCard catCard = null;

            string sql = "SELECT id, img_url, fact, caption FROM catcards WHERE id = @card_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@card_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        catCard = MapRowToCatCard(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return catCard;
        }

        public CatCard CreateCatCard(CatCard catCard)
        {
            CatCard newCatCard = null;

            string sql = "INSERT INTO catcards (img_url, fact, caption) " +
                         "OUTPUT INSERTED.id " +
                         "VALUES (@img_url, @fact, @caption)";

            int newCatCardId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@img_url", catCard.ImgUrl);
                    cmd.Parameters.AddWithValue("@fact", catCard.CatFact);
                    cmd.Parameters.AddWithValue("@caption", catCard.Caption);

                    newCatCardId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                newCatCard = GetCatCardById(newCatCardId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return newCatCard;
        }

        public CatCard UpdateCard(CatCard catCard)
        {
            CatCard updatedCatCard = null;

            string sql = "UPDATE catcards SET img_url = @img_url, fact = @fact, caption = @caption WHERE id = @card_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@img_url", catCard.ImgUrl);
                    cmd.Parameters.AddWithValue("@fact", catCard.CatFact);
                    cmd.Parameters.AddWithValue("@caption", catCard.Caption);
                    cmd.Parameters.AddWithValue("@card_id", catCard.CatCardId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new DaoException("Zero rows affected, expected at least one");
                    }
                }
                updatedCatCard = GetCatCardById(catCard.CatCardId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return updatedCatCard;
        }

        public int DeleteCatCardById(int id)
        {
            int rowsAffected = 0;

            string sql = "DELETE FROM catcards WHERE id = @card_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@card_id", id);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return rowsAffected;
        }

        private CatCard MapRowToCatCard(SqlDataReader reader)
        {
            CatCard catCard = new CatCard();
            catCard.CatCardId = Convert.ToInt32(reader["id"]);
            catCard.ImgUrl = Convert.ToString(reader["img_url"]);
            catCard.CatFact = Convert.ToString(reader["fact"]);
            catCard.Caption = Convert.ToString(reader["caption"]);

            return catCard;
        }
    }
}
