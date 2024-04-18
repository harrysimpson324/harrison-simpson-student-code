SELECT TOP 1 sale_id, total, is_delivery, customer_id
    FROM sale
    ORDER BY total DESC;
