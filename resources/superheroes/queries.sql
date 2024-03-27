-- Sample SQL query finding all superheroes who don't have blue eyes

Select superhero_name, color AS eye_color 
from superhero 
JOIN color on superhero.eye_color_id = color.id
WHERE color <> 'Blue';


-- Challenge 1: Write a SQL query to find all the 'DC Comics' (publisher) superheroes 
--              that are over 2m tall


-- Challenge 2: Write a SQL query to show all Female superheroes along with their superpowers. 
--              Be sure to include every female superhero, even if they don't have 
--              any known superpowers.
