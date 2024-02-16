SELECT (person_id || ' - ' || first_name || ' ' || last_name) AS "Artist", title AS "Title", purchase_date AS "Purchase Date", price AS "Price"
FROM purchase
JOIN artwork ON purchase.artwork_id = artwork.artwork_id
JOIN person ON artwork.artist_id = person.person_id;
