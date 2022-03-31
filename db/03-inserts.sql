INSERT INTO app(app_id, name, code_name, version, observations, date_creation, date_cancellation,
                date_activation, usr_creates_id, usr_cancels_id, usr_activates_id)
VALUES (1, 'Parcel Service', 'parcel', 1, 'N/A', NOW()::timestamptz, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP,
        1, 0, 0);

INSERT INTO company(company_id, name, rfc, contact_name, contact_title, business_name,
                    company_name, email, area_code, phone, home_page, zip_code, street,
                    street_number, suburb, township, city, state_id, note, observations,
                    date_creation, date_modification, date_cancellation, date_activation,
                    usr_creates_id, usr_modifies_id, usr_cancels_id, usr_activates_id)
VALUES(1,'Parcel Service','XAXX010101000','Sam','Admin','Parcel Service','Parcel Service',
       'parcel@fake#com','','','','','','','','','',0,'', NOW()::timestamptz, CURRENT_TIMESTAMP,
       CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 1, 0, 0, 0);

-- --
INSERT INTO roles(role_id, role_name)
VALUES(1, 'Master');

INSERT INTO roles(role_id, role_name)
VALUES(2, 'Administrator');

INSERT INTO roles(role_id, role_name)
VALUES(3, 'Supervisor');

INSERT INTO roles(role_id, role_name)
VALUES(4, 'Typist');

INSERT INTO roles(role_id, role_name)
VALUES(5, 'Courier');

INSERT INTO roles(role_id, role_name)
VALUES(6, 'Customer');

INSERT INTO roles(role_id, role_name)
VALUES(7, 'Driver');

-- --
INSERT INTO users(user_id, firstname, lastname, email, username,
                  date_creation, date_modification, usr_creates_id, usr_modifies_id)
VALUES(1,'Camina','Drummer','drummer.parcel@fake#com','drummer',NOW()::timestamptz,
       CURRENT_TIMESTAMP, 1, 0);

INSERT INTO users(user_id, firstname, lastname, email, username,
                  date_creation, date_modification, usr_creates_id, usr_modifies_id)
VALUES(2,'James','Dean','dean.parcel@fake#com','dean',NOW()::timestamptz,
       CURRENT_TIMESTAMP, 1, 0);
-- --
INSERT INTO parcel(parcel_id, role_id, user_id, mid, auth, password, is_staff,
                   date_creation, date_modification, usr_creates_id, usr_modifies_id)
VALUES(1, 1, 1, '67e276d4-7d6c-8330-c823-7d62ccd35a95', '00Ji2ltAr/B8b9JvZAnaKQbYibEjQErONs+8+Zkfo+0=',
       'z2MIR6Xh04Y=',1,NOW()::TIMESTAMP, CURRENT_TIMESTAMP, 1, 0);

INSERT INTO parcel(parcel_id, role_id, user_id, mid, auth, password, is_staff,
                   date_creation, date_modification, usr_creates_id, usr_modifies_id)
VALUES(2, 6, 2, '24086f97-6a7a-8800-38f9-6df61d0bc92b', '00KDLp8xTvU1uro/yHT/3epVfLuCkLHgZ4f502FGYlQ=',
       'z2MIR6Xh04Y=',1,NOW()::TIMESTAMP, CURRENT_TIMESTAMP, 1, 0);
-- --
INSERT INTO user_access(user_access_id, user_id, mid, auth, last_login, activity_status, is_staff,
                        operation_id, operation_context_id, date_creation, date_modification,
                        date_activation, usr_creates_id, usr_modifies_id, usr_activates_id)
VALUES(1, 1, '67e276d4-7d6c-8330-c823-7d62ccd35a95', '00Ji2ltAr/B8b9JvZAnaKQbYibEjQErONs+8+Zkfo+0=',
       CURRENT_TIMESTAMP, false, 1, 1542, 1562, NOW()::TIMESTAMP, CURRENT_TIMESTAMP,
       CURRENT_TIMESTAMP, 1, 0, 0);

INSERT INTO user_access(user_access_id, user_id, mid, auth, last_login, activity_status, is_staff,
                        operation_id, operation_context_id, date_creation, date_modification,
                        date_activation, usr_creates_id, usr_modifies_id, usr_activates_id)
VALUES(2, 2,'24086f97-6a7a-8800-38f9-6df61d0bc92b', '00KDLp8xTvU1uro/yHT/3epVfLuCkLHgZ4f502FGYlQ=',
       CURRENT_TIMESTAMP, false, 2, 1542, 1562, NOW()::TIMESTAMP, CURRENT_TIMESTAMP,
       CURRENT_TIMESTAMP, 1, 0, 0);
-- --
INSERT INTO branch_offices(branch_office_id, status, is_suspended, tax_residence_id, state_id,
                           name, abbreviation, code, address, phone, email, date_creation,
                           date_modification, date_cancellation, date_activation, usr_creates_id,
                           usr_modifies_id, usr_cancels_id, usr_activates_id)
VALUES (1, false, false, 4003, 18, 'Guadalajara, Jal.', 'GDL', 1, '', '33 123456789', 'parcel@fake#com',
        NOW()::timestamptz, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 1, 0, 0, 0);

-- --
INSERT INTO customers(customer_id, user_access_id, branch_office_id, third_type_id,
                      firstname, lastname, business_name, company_name, rfc,
                      email, area_code, phone, customer_type_id, with_agreement, date_creation,
                      date_modification, date_authorization, usr_creates_id, usr_modifies_id,
                      usr_authorizes_id)
VALUES(1,1,1,0,'James','Dean','Vintage','Vintage','XAXX010101000','jamesdean@fake#com','','',
       0,false,NOW()::timestamptz, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 1, 0, 0);
