using System;
using System.Data.SqlClient;
using CampgroundReservations.Exceptions;
using CampgroundReservations.Models;

namespace CampgroundReservations.DAO
{
    public class ReservationSqlDao : IReservationDao
    {
        private readonly string connectionString;

        public ReservationSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Reservation GetReservationById(int id)
        {
            Reservation reservation = null;
            
            string sql = "SELECT reservation_id, site_id, name, from_date, to_date, create_date FROM reservation WHERE reservation_id = @reservation_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@reservation_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        reservation = MapRowToReservation(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return reservation;
        }

        public Reservation CreateReservation(Reservation reservation)
        {
            Reservation newReservation = null;

            string sql = "INSERT INTO reservation (site_id, name, from_date, to_date, create_date) " +
                         "OUTPUT INSERTED.reservation_id " +
                         "VALUES (@siteId, @name, @fromDate, @toDate, GETDATE())";

            int newReservationId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@siteId", reservation.SiteId);
                    cmd.Parameters.AddWithValue("@name", reservation.Name);
                    cmd.Parameters.AddWithValue("@fromDate", reservation.FromDate);
                    cmd.Parameters.AddWithValue("@toDate", reservation.ToDate);

                    newReservationId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                newReservation = GetReservationById(newReservationId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return newReservation;
        }

        private Reservation MapRowToReservation(SqlDataReader reader)
        {
            Reservation reservation = new Reservation();
            reservation.ReservationId = Convert.ToInt32(reader["reservation_id"]);
            reservation.SiteId = Convert.ToInt32(reader["site_id"]);
            reservation.Name = Convert.ToString(reader["name"]);
            reservation.FromDate = Convert.ToDateTime(reader["from_date"]);
            reservation.ToDate = Convert.ToDateTime(reader["to_date"]);
            reservation.CreateDate = Convert.ToDateTime(reader["create_date"]);

            return reservation;
        }
    }
}
