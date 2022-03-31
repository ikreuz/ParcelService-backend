create or replace view vw_roles(role_id, role_name) as
select r.role_id,
       r.role_name
from roles r;

alter table vw_roles
    owner to parcel_user_main;

create or replace view vw_last_role_id(role_id) as
SELECT role_id AS role_id
FROM roles
ORDER BY role_id DESC
LIMIT 1;
alter table vw_last_role_id
    owner to parcel_user_main;


create or replace view vw_users
            (user_id, role_id, role_name, app_user, firstname, lastname, email,
             username, activity_status, app_user_type, app_user_type_txt, date_creation,
             date_modification, usr_creates_id, usr_creates, usr_modifies_id, usr_modifies
                )
as
select u.user_id,
       r.role_id,
       r.role_name,
       (u.firstname::text || ' '::text) || u.lastname::text as app_user,
       u.firstname,
       u.lastname,
       u.email,
       u.username,
       acc.activity_status,
       acc.is_staff                                    as app_user_type,
       CasE acc.is_staff > 1
           WHEN true THEN 'Customer'::varchar
           ELSE 'Employee'::varchar
           END                                         as app_user_type_txt,
       u.date_creation,
       u.date_modification,
       u.usr_creates_id,
       CasE p.usr_creates_id = 0
           WHEN TRUE THEN 'N/A'::text
           ELSE
                   (u2.firstname::text || ' '::text) || (u2.lastname::text || ' '::text)
           END                                         as usr_creates,
       p.usr_modifies_id,
       CasE p.usr_modifies_id = 0
           WHEN TRUE THEN 'N/A'::text
           ELSE
                   (u3.firstname::text || ' '::text) || (u3.lastname::text || ' '::text)
           END                                         as usr_modifies

from users u
         LEFT JOIN parcel p on u.user_id = p.user_id
         LEFT JOIN customers u2 ON u.usr_creates_id = u2.usr_creates_id
         LEFT JOIN customers u3 ON u.usr_modifies_id = u3.usr_modifies_id
         LEFT JOIN user_access acc ON u.user_id = acc.user_id
         LEFT JOIN roles r ON p.role_id = r.role_id;

alter table vw_users
    owner to parcel_user_main;


-- --
create or replace view vw_last_user_id(user_id) as
SELECT user_id AS user_id
FROM users
ORDER BY user_id DESC
LIMIT 1;

alter table vw_last_user_id
    owner to parcel_user_main;


create or replace view vw_login
            (user_id, mid, auth, app_user, firstname, lastname, email, username,
             password, activity_status, activity_status_txt, app_user_type, app_user_type_txt, date_creation,
             date_modification, usr_creates_id, usr_modifies_id)
as
select u.user_id,
       ua.mid,
       ua.auth,
       u.app_user,
       u.firstname,
       u.lastname,
       u.email,
       u.username,
       p.password,
       u.activity_status,
       CasE u.activity_status
           WHEN true THEN 'Active'::varchar
           ELSE 'Inactive'::varchar
           END as activity_status_txt,
       u.app_user_type,
       CasE u.app_user_type > 1
           WHEN true THEN 'Customer'::varchar
           ELSE 'Employee'::varchar
           END as app_user_type_txt,
       u.date_creation,
       u.date_modification,
       u.usr_creates_id,
       u.usr_modifies_id

from vw_users u
         JOIN user_access ua ON u.user_id = ua.user_id
         JOIN parcel p ON u.user_id = p.user_id;

alter table vw_login
    owner to parcel_user_main;