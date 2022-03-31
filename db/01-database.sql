CREATE ROLE parcel_user_main WITH
    LOGIN
    PASSWORD 'secret123';

-- --
CREATE DATABASE db_parcel with owner parcel_user_main;
