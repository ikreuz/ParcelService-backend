create or replace function fn_login(_user_name character varying)
    RETURNS SETOF vw_login
    language plpgsql
as
$$
/******************************************************************************
NAME: fn_login
GOAL: Performs the operation of obtaining the user data for the login.
RETURN: __record - Record of the user searched by their username.
******************************************************************************/
DECLARE
    __record vw_login;
BEGIN

    FOR __record IN SELECT * FROM vw_login WHERE username = lower(_user_name) LIMIT 1
        LOOP
            RETURN NEXT __record;
        END LOOP;
END;
$$;
alter function fn_login(varchar) owner to parcel_user_main;


-- -- -----------------------------------------------------------------------------------
-- -- roles
-- -- -----------------------------------------------------------------------------------
create or replace function fn_insert_roles(_role_id integer, _role_name character varying)
    returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_insert_roles
OBJETIVO: Performs the insert operation of a role.
RETORNA: 
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    INSERT INTO roles (role_id, role_name)
    VALUES (_role_id, _role_name);

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN
        __return := 1;
    ELSE
        __return := -1;
    END IF;

    RETURN __return;
END
$$;

alter function fn_insert_roles(integer, character varying) owner to parcel_user_main;

-- --
create or replace function fn_update_roles(_role_id integer, _role_name character varying) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_update_roles
OBJETIVO: 
RETORNA: 
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    UPDATE roles
    SET role_id   = _role_id,
        role_name = _role_name
    WHERE role_id = _role_id;

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END
$$;

alter function fn_update_roles (integer, varchar) owner to parcel_user_main;

-- --
create or replace function fn_delete_roles(_role_id integer) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_delete_roles
OBJETIVO: 
RETORNA: 
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN
    DELETE FROM roles WHERE role_id = _role_id;
    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END;
$$;
alter function fn_delete_roles(integer) owner to parcel_user_main;

-- --
create or replace function fn_get_roles(_role_id integer) returns SETOF roles
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_get_roles
OBJETIVO:
RETORNA: 
******************************************************************************/
DECLARE
    __record roles;
BEGIN
    FOR __record IN SELECT * FROM roles WHERE role_id = _role_id
        LOOP
            RETURN NEXT __record;
        END LOOP;
END ;
$$;

alter function fn_get_roles(integer) owner to parcel_user_main;

-- --
create or replace function fn_get_all_roles()
    returns TABLE
            (
                role_id     integer,
                role_name   character varying,
                total_count bigint
            )
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_get_all_roles
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record record;
    __query  text;
BEGIN

    __query := 'SELECT * ,COUNT(role_id) OVER() AS total_count FROM roles ORDER BY role_id DESC';

    FOR __record IN EXECUTE __query
        LOOP
            role_id := __record.role_id;
            role_name := __record.role_name;
            total_count := __record.total_count;
            RETURN NEXT;
        END LOOP;
END;
$$;

alter function fn_get_all_roles() owner to parcel_user_main;


-- -- -----------------------------------------------------------------------------------
-- -- customers
-- -- -----------------------------------------------------------------------------------
create or replace function fn_insert_customers(
    _customer_id integer,
    _user_access_id integer,
    _branch_office_id integer,
    _third_type_id integer,
    _firstname character varying,
    _lastname character varying,
    _business_name character varying,
    _company_name character varying,
    _rfc character varying,
    _email character varying,
    _area_code character varying,
    _phone character varying,
    _customer_type_id integer,
    _with_agreement boolean,
    _date_creation timestamptz,
    _date_modification timestamptz,
    _date_authorization timestamptz,
    _usr_creates_id integer,
    _usr_modifies_id integer,
    _usr_authorizes_id integer
)
    returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_insert_customers
OBJETIVO: Performs the insert operation of a role.
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    INSERT INTO customers (customer_id, user_access_id, branch_office_id, third_type_id, firstname,
                           lastname, business_name, company_name, rfc, email,
                           area_code, phone, customer_type_id, with_agreement, date_creation,
                           date_modification, date_authorization,
                           usr_creates_id, usr_modifies_id, usr_authorizes_id)
    VALUES (_customer_id, _user_access_id, _branch_office_id, _third_type_id, _firstname,
            _lastname, _business_name, _company_name, _rfc, _email,
            _area_code, _phone, _customer_type_id, _with_agreement, _date_creation,
            _date_modification, _date_authorization,
            _usr_creates_id, _usr_modifies_id, _usr_authorizes_id);

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN
        __return := 1;
    ELSE
        __return := -1;
    END IF;

    RETURN __return;
END
$$;

alter function fn_insert_customers(integer,integer,integer,integer,varchar,varchar,
    varchar,varchar,varchar,varchar,varchar,varchar,integer,boolean,
    timestamptz,timestamptz,timestamptz,integer,integer,integer) owner to parcel_user_main;

-- --
create or replace function fn_update_customers(
    _customer_id integer,
    _user_access_id integer,
    _branch_office_id integer,
    _third_type_id integer,
    _firstname character varying,
    _lastname character varying,
    _business_name character varying,
    _company_name character varying,
    _rfc character varying,
    _email character varying,
    _area_code character varying,
    _phone character varying,
    _customer_type_id integer,
    _with_agreement boolean,
    _date_creation timestamptz,
    _date_modification timestamptz,
    _date_authorization timestamptz,
    _usr_creates_id integer,
    _usr_modifies_id integer,
    _usr_authorizes_id integer
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_update_customers
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    UPDATE customers
    SET user_access_id=_user_access_id,
        branch_office_id=_branch_office_id,
        third_type_id=_third_type_id,
        firstname=_firstname,
        lastname=_lastname,
        business_name=_business_name,
        company_name=_company_name,
        rfc=_rfc,
        email=_email,
        area_code=_area_code,
        phone=_phone,
        customer_type_id=_customer_type_id,
        with_agreement=_with_agreement,
        date_creation=_date_creation,
        date_modification=_date_modification,
        date_authorization=_date_authorization,
        usr_creates_id=_usr_creates_id,
        usr_modifies_id=_usr_modifies_id,
        usr_authorizes_id=_usr_authorizes_id
    WHERE customer_id = _customer_id;

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END
$$;

alter function fn_update_customers(integer,integer,integer,integer,varchar,varchar,
    varchar,varchar,varchar,varchar,varchar,varchar,integer,boolean,
    timestamptz,timestamptz,timestamptz,integer,integer,integer) owner to parcel_user_main;

-- --
create or replace function fn_delete_customers(_customer_id integer) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_delete_customers
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN
    DELETE FROM customers WHERE customer_id = _customer_id;
    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END;
$$;
alter function fn_delete_customers(integer) owner to parcel_user_main;

-- --
create or replace function fn_get_customers(_customer_id integer) returns SETOF customers
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_get_customers
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record customers;
BEGIN
    FOR __record IN SELECT * FROM customers WHERE customer_id = _customer_id
        LOOP
            RETURN NEXT __record;
        END LOOP;
END ;
$$;

alter function fn_get_customers(integer) owner to parcel_user_main;

-- --
create or replace function fn_get_all_customers()
    returns TABLE
            (
                customer_id        integer,
                user_access_id     integer,
                branch_office_id   integer,
                third_type_id      integer,
                firstname          character varying,
                lastname           character varying,
                business_name      character varying,
                company_name       character varying,
                rfc                character varying,
                email              character varying,
                area_code          character varying,
                phone              character varying,
                customer_type_id   integer,
                with_agreement     boolean,
                date_creation      timestamptz,
                date_modification  timestamptz,
                date_authorization timestamptz,
                usr_creates_id     integer,
                usr_modifies_id    integer,
                usr_authorizes_id  integer,
                total_count        bigint
            )
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_get_all_customers
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record record;
    __query  text;
BEGIN

    __query := 'SELECT * ,COUNT(customer_id) OVER() AS total_count FROM customers ORDER BY customer_id DESC';

    FOR __record IN EXECUTE __query
        LOOP
            customer_id := __record.customer_id;
            user_access_id := __record.user_access_id;
            branch_office_id := __record.branch_office_id;
            third_type_id := __record.third_type_id;
            firstname := __record.firstname;
            lastname := __record.lastname;
            business_name := __record.business_name;
            company_name := __record.company_name;
            rfc := __record.rfc;
            email := __record.email;
            area_code := __record.area_code;
            phone := __record.phone;
            customer_type_id := __record.customer_type_id;
            with_agreement := __record.with_agreement;
            date_creation := __record.date_creation;
            date_modification := __record.date_modification;
            date_authorization := __record.date_authorization;
            usr_creates_id := __record.usr_creates_id;
            usr_modifies_id := __record.usr_modifies_id;
            usr_authorizes_id := __record.usr_authorizes_id;
            total_count := __record.total_count;
            RETURN NEXT;
        END LOOP;
END;
$$;

alter function fn_get_all_customers() owner to parcel_user_main;

-- -- -----------------------------------------------------------------------------------
-- -- users
-- -- -----------------------------------------------------------------------------------
create or replace function fn_insert_users(
    _customer_id integer,
    _user_access_id integer,
    _branch_office_id integer,
    _third_type_id integer,
    _firstname character varying,
    _lastname character varying,
    _business_name character varying,
    _company_name character varying,
    _rfc character varying,
    _email character varying,
    _area_code character varying,
    _phone character varying,
    _customer_type_id integer,
    _with_agreement boolean,
    _date_creation timestamptz,
    _date_modification timestamptz,
    _date_authorization timestamptz,
    _usr_creates_id integer,
    _usr_modifies_id integer,
    _usr_authorizes_id integer
)
    returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_insert_users
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    INSERT INTO customers (customer_id, user_access_id, branch_office_id, third_type_id, firstname,
                           lastname, business_name, company_name, rfc, email,
                           area_code, phone, customer_type_id, with_agreement, date_creation,
                           date_modification, date_authorization,
                           usr_creates_id, usr_modifies_id, usr_authorizes_id)
    VALUES (_customer_id, _user_access_id, _branch_office_id, _third_type_id, _firstname,
            _lastname, _business_name, _company_name, _rfc, _email,
            _area_code, _phone, _customer_type_id, _with_agreement, _date_creation,
            _date_modification, _date_authorization,
            _usr_creates_id, _usr_modifies_id, _usr_authorizes_id);

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN
        __return := 1;
    ELSE
        __return := -1;
    END IF;

    RETURN __return;
END
$$;

alter function fn_insert_users(integer,integer,integer,integer,varchar,varchar,
    varchar,varchar,varchar,varchar,varchar,varchar,integer,boolean,
    timestamptz,timestamptz,timestamptz,integer,integer,integer) owner to parcel_user_main;

-- --
create or replace function fn_update_users(
    _customer_id integer,
    _user_access_id integer,
    _branch_office_id integer,
    _third_type_id integer,
    _firstname character varying,
    _lastname character varying,
    _business_name character varying,
    _company_name character varying,
    _rfc character varying,
    _email character varying,
    _area_code character varying,
    _phone character varying,
    _customer_type_id integer,
    _with_agreement boolean,
    _date_creation timestamptz,
    _date_modification timestamptz,
    _date_authorization timestamptz,
    _usr_creates_id integer,
    _usr_modifies_id integer,
    _usr_authorizes_id integer
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_update_users
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    UPDATE customers
    SET user_access_id=_user_access_id,
        branch_office_id=_branch_office_id,
        third_type_id=_third_type_id,
        firstname=_firstname,
        lastname=_lastname,
        business_name=_business_name,
        company_name=_company_name,
        rfc=_rfc,
        email=_email,
        area_code=_area_code,
        phone=_phone,
        customer_type_id=_customer_type_id,
        with_agreement=_with_agreement,
        date_creation=_date_creation,
        date_modification=_date_modification,
        date_authorization=_date_authorization,
        usr_creates_id=_usr_creates_id,
        usr_modifies_id=_usr_modifies_id,
        usr_authorizes_id=_usr_authorizes_id
    WHERE customer_id = _customer_id;

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END
$$;

alter function fn_update_users(integer,integer,integer,integer,varchar,varchar,
    varchar,varchar,varchar,varchar,varchar,varchar,integer,boolean,
    timestamptz,timestamptz,timestamptz,integer,integer,integer) owner to parcel_user_main;

-- --
create or replace function fn_delete_users(_customer_id integer) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_delete_users
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN
    DELETE FROM customers WHERE customer_id = _customer_id;
    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END;
$$;
alter function fn_delete_users(integer) owner to parcel_user_main;

-- --
create or replace function fn_get_users(_customer_id integer) returns SETOF customers
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_get_users
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record customers;
BEGIN
    FOR __record IN SELECT * FROM customers WHERE customer_id = _customer_id
        LOOP
            RETURN NEXT __record;
        END LOOP;
END ;
$$;

alter function fn_get_users(integer) owner to parcel_user_main;

-- --
create or replace function fn_get_all_users()
    returns TABLE
            (
                user_id           integer,
                role_id           integer,
                role_name         character varying,
                app_user          character varying,
                firstname         character varying,
                lastname          character varying,
                email             character varying,
                username          character varying,
                activity_status   boolean,
                app_user_type     integer,
                app_user_type_txt character varying,
                date_creation     timestamptz,
                date_modification timestamptz,
                usr_creates_id    integer,
                usr_creates       character varying,
                usr_modifies_id   integer,
                usr_modifies      character varying,
                total_count       bigint
            )
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_get_all_users
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record record;
    __query  text;
BEGIN

    __query := 'SELECT * ,COUNT(user_id) OVER() AS total_count FROM vw_users ORDER BY user_id DESC';

    FOR __record IN EXECUTE __query
        LOOP
            user_id := __record.user_id;
            role_id := __record.role_id;
            role_name := __record.role_name;
            app_user := __record.app_user;
            firstname := __record.firstname;
            lastname := __record.lastname;
            username := __record.username;
            email := __record.email;
            activity_status := __record.activity_status;
            app_user_type := __record.app_user_type;
            app_user_type_txt := __record.app_user_type_txt;
            date_creation := __record.date_creation;
            date_modification := __record.date_modification;
            usr_creates_id := __record.usr_creates_id;
            usr_creates := __record.usr_creates;
            usr_modifies_id := __record.usr_modifies_id;
            usr_modifies := __record.usr_modifies;
            total_count := __record.total_count;

            RETURN NEXT;
        END LOOP;
END;
$$;

alter function fn_get_all_users() owner to parcel_user_main;
