SELECT sale_id, total, is_delivery, customer_id
    FROM sale
    WHERE is_delivery = 1
    ORDER BY sale_id;