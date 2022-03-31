-- --
create sequence app_id_seq;
alter sequence app_id_seq owner to parcel_user_main;
create table app
(
    app_id           integer          default nextval('app_id_seq'::regclass),
    name             varchar(50)      default ''::character varying not null,
    code_name        varchar(30)      default ''::character varying not null,
    version          numeric not null default 0,
    observations     varchar(50)      default ''::character varying not null,
    date_creation      timestamptz      default NOW()::timestamptz,
    date_cancellation  timestamptz      default NOW()::timestamptz,
    date_activation    timestamptz      default NOW()::timestamptz,
    usr_creates_id   integer not null default 0,
    usr_cancels_id   integer not null default 0,
    usr_activates_id integer not null default 0,
    constraint app_key primary key (app_id)
);
alter table app
    owner to parcel_user_main;

-- --
create sequence company_id_seq;
alter sequence company_id_seq owner to parcel_user_main;
create table company
(
    company_id       integer     default nextval('company_id_seq'::regclass),
    name             varchar(50) default ''::character varying not null,
    rfc              varchar(14) default ''::character varying not null,
    contact_name     varchar(30) default ''::character varying,
    contact_title    varchar(30) default ''::character varying,
    business_name    varchar(70) default ''::character varying not null,
    company_name     varchar(70) default ''::character varying not null,
    email            varchar(50) default ''::character varying not null,
    area_code        varchar(3)  default ''::character varying not null,
    phone            varchar(10) default ''::character varying not null,
    home_page        varchar(50) default ''::character varying,
    zip_code         char(7)     default ''::bpchar            not null,
    street           varchar(70) default ''::character varying not null,
    street_number    varchar(10) default ''::bpchar            not null,
    suburb           char(40)    default ''::bpchar            not null,
    township         char(40)    default ''::bpchar            not null,
    city             char(40)    default ''::bpchar            not null,
    state_id         integer     default 0                     not null,
    note             varchar(50) default ''::character varying not null,
    observations     varchar(50) default ''::character varying not null,
    date_creation      timestamptz default NOW()::timestamptz,
    date_modification  timestamptz default NOW()::timestamptz,
    date_cancellation  timestamptz default NOW()::timestamptz,
    date_activation    timestamptz default NOW()::timestamptz,
    usr_creates_id   integer                                   not null default 0,
    usr_modifies_id  integer                                   not null default 0,
    usr_cancels_id   integer                                   not null default 0,
    usr_activates_id integer                                   not null default 0,
    constraint company_key primary key (company_id)
);
alter table company
    owner to parcel_user_main;

-- --
create sequence roles_id_seq;
alter sequence roles_id_seq owner to parcel_user_main;
create table roles
(
    role_id   integer               not null default nextval('roles_id_seq'::regclass),
    role_name character varying(35) not null default ''::character varying UNIQUE,
    primary key (role_id)
);
alter table roles
    owner to parcel_user_main;

-- --
create sequence users_id_seq;
alter sequence users_id_seq owner to parcel_user_main;
create table users
(
    user_id         integer               not null default nextval('users_id_seq'::regclass),
    firstname       character varying(30) not null default ''::character varying,
    lastname        character varying(60) not null default ''::character varying,
    email           character varying(50) not null default ''::character varying,
    username        character varying(20) not null,
    date_creation     timestamptz                    default NOW()::timestamptz,
    date_modification timestamptz                    default NOW()::timestamptz,
    usr_creates_id  integer               not null default 0,
    usr_modifies_id integer               not null default 0,
    primary key (user_id),
    unique (user_id)
);
alter table users
    owner to parcel_user_main;

-- --
create sequence parcel_id_seq;
alter sequence parcel_id_seq owner to parcel_user_main;
create table parcel
(
    parcel_id       integer               not null default nextval('parcel_id_seq'::regclass),
    role_id         integer               not null,
    user_id         integer               not null UNIQUE,
    mid             uuid                  not null UNIQUE,
    auth            varchar(100)          not null UNIQUE,
    password        character varying(90) not null default ''::character varying,
    is_staff        integer               not null default 0,
    date_creation     timestamptz                    default NOW()::timestamptz,
    date_modification timestamptz                    default NOW()::timestamptz,
    usr_creates_id  integer               not null default 0,
    usr_modifies_id integer               not null default 0,
    primary key (parcel_id),
    foreign key (user_id) references users (user_id),
    foreign key (role_id) references roles (role_id),
    unique (user_id, mid, auth)
);

alter table parcel
    owner to parcel_user_main;

-- --
create sequence user_access_id_seq;
alter sequence user_access_id_seq owner to parcel_user_main;
create table user_access
(
    user_access_id       integer      not null default nextval('user_access_id_seq'::regclass) UNIQUE,
    user_id              integer      not null UNIQUE,
    mid                  uuid         not null UNIQUE,
    auth                 varchar(100) not null UNIQUE,
    last_login           timestamptz  not null default NOW()::timestamptz,
    activity_status      boolean      not null default false::boolean,
    is_staff             integer      not null default 0,
    operation_id         integer      not null default 0,
    operation_context_id integer      not null default 0,
    date_creation          timestamptz           default NOW()::timestamptz,
    date_modification      timestamptz           default NOW()::timestamptz,
    date_activation        timestamptz           default NOW()::timestamptz,
    usr_creates_id       integer      not null default 0,
    usr_modifies_id      integer      not null default 0,
    usr_activates_id     integer      not null default 0,
    primary key (user_access_id),
    foreign key (user_id, mid, auth) references parcel (user_id, mid, auth) on delete cascade on update cascade
);
alter table user_access
    owner to parcel_user_main;

-- --
create sequence session_id_seq;
alter sequence session_id_seq owner to parcel_user_main;
create table session
(
    session_id         integer not null default nextval('session_id_seq'::regclass),
    user_id            integer not null,
    mid                uuid    not null,
    active             boolean          default false not null,
    branch_office_id   integer          default 0 not null,
    entity_id          integer          default 0 not null,
    activity_entity_id integer not null default 0,
    activity_action_id integer not null default 0,
    date_creation        timestamptz      default NOW()::timestamptz,
    last_access        timestamptz      default NOW()::timestamptz,
    constraint session_key primary key (session_id),
    foreign key (user_id) references user_access (user_id) on update cascade
);

alter table session
    owner to parcel_user_main;

-- --
create sequence det_session_id_seq;
alter sequence det_session_id_seq owner to parcel_user_main;
create table det_session
(
    detail_id  integer                                   not null default nextval('det_session_id_seq'::regclass),
    session_id integer                                   not null,
    ipv4       varchar(15) default ''::character varying not null,
    device     varchar(20) default ''::character varying not null,
    browser    varchar(20) default ''::character varying not null,
    os         varchar(20) default ''::character varying not null,
    constraint session_detail_key primary key (detail_id),
    foreign key (session_id) references session (session_id)
);
alter table det_session
    owner to parcel_user_main;

-- --
create sequence activity_id_seq;
alter sequence activity_id_seq owner to parcel_user_main;
create table activity
(
    activity_id          integer not null default nextval('activity_id_seq'::regclass),
    mid                  uuid    not null,
    branch_office_id     integer not null default 0,
-- -- fe pagina donde se crea: contexto
    context_view_id      integer not null default 0,
    -- -- fe id del objeto que lo genera: contactoId, usuarioId, guiaId, pagoId,
    tracking_id          integer not null default 0,
    -- -- be entidad del objeto: usuario, guia, personal,
    activity_entity_id   integer not null default 0,
    -- -- be accion del objeto: inicio de sesion, cerrar sesion
    activity_action_id   integer not null default 0,
    -- -- be notf objecto
    notification_obj     integer not null default 0,
    -- -- be notf nivel
    notification_lvl     integer not null default 0,
    -- -- fe agregar, crear asignar
    operation_id         integer          default 0 not null,
    -- -- fe agregar cuenta, crear cuenta, asignar rol
    operation_context_id integer          default 0 not null,
    date_creation          timestamptz      default NOW()::timestamptz,
    constraint activity_key primary key (activity_id)
);
alter table activity
    owner to parcel_user_main;

-- --
create sequence employee_id_seq;
alter sequence employee_id_seq owner to parcel_user_main;
create table employee
(
    employee_id       integer not null default nextval('employee_id_seq'::regclass),
    user_access_id    integer not null,
    firstname  varchar(20)      default ''::character varying not null,
    lastname   varchar(20)      default ''::character varying not null,
    branch_office_id  integer not null default 0,
    job_id            integer not null default 0,
    date_creation       timestamptz      default NOW()::timestamptz,
    date_authorization  timestamptz      default NOW()::timestamptz,
    date_modification   timestamptz      default NOW()::timestamptz,
    usr_creates_id    integer not null default 0,
    usr_authorizes_id integer not null default 0,
    usr_modifies_id   integer not null default 0,
    constraint employee_key primary key (employee_id),
    foreign key (user_access_id) references user_access (user_access_id) on update cascade
);
alter table employee
    owner to parcel_user_main;

-- --
create sequence detail_employee_id_seq;
alter sequence detail_employee_id_seq owner to parcel_user_main;
create table detail_employee
(
    detail_employee_id             integer not null default nextval('detail_employee_id_seq'::regclass),
    employee_id                    integer not null,
    business_hours_input           integer not null default 0,
    business_hours_saturday_input  integer not null default 0,
    business_hours_sunday_input    integer not null default 0,
    business_hours_output          integer not null default 0,
    business_hours_saturday_output integer not null default 0,
    business_hours_sunday_output   integer not null default 0,
    constraint detail_employee_key primary key (detail_employee_id),
    foreign key (employee_id) references employee (employee_id) on update cascade
);
alter table detail_employee
    owner to parcel_user_main;

-- --
create sequence customers_id_seq;
alter sequence customers_id_seq owner to parcel_user_main;
create table customers
(
    customer_id       integer                                   not null default nextval('customers_id_seq'::regclass),
    user_access_id    integer                                   not null,
    branch_office_id  integer     default 0                     not null,
    third_type_id     integer     default 0                     not null,
    firstname         varchar(30) default ''::character varying not null,
    lastname          varchar(20) default ''::character varying not null,
    business_name     varchar(70) default ''::character varying not null,
    company_name      varchar(70) default ''::character varying not null,
    rfc               varchar(14) default ''::character varying not null,
    email             varchar(50) default ''::character varying not null,
    area_code         varchar(3)  default ''::character varying not null,
    phone             varchar(10) default ''::character varying not null,
    customer_type_id  integer     default 0                     not null,
    with_agreement    boolean     default false                 not null,
    date_creation       timestamptz default NOW()::timestamptz,
    date_modification   timestamptz default NOW()::timestamptz,
    date_authorization  timestamptz default NOW()::timestamptz,
    usr_creates_id    integer                                   not null default 0,
    usr_modifies_id   integer                                   not null default 0,
    usr_authorizes_id integer                                   not null default 0,
    constraint customer_key primary key (customer_id),
    foreign key (user_access_id) references user_access (user_access_id)
);

alter table customers
    owner to parcel_user_main;

-- --

create sequence customer_address_id_seq;
alter sequence customer_address_id_seq owner to parcel_user_main;
create table customer_address
(
    customer_address_id integer     default nextval('customer_address_id_seq'::regclass),
    customer_id         integer                                   not null,
    zip_code            char(7)     default ''::bpchar            not null,
    address             varchar(70) default ''::character varying not null,
    street_number       varchar(10) default ''::bpchar            not null,
    suburb              char(40)    default ''::bpchar            not null,
    township            char(40)    default ''::bpchar            not null,
    city                char(40)    default ''::bpchar            not null,
    state_id            integer     default 0                     not null,
    note                varchar(50) default ''::character varying not null,
    observations        varchar(50) default ''::character varying not null,
    constraint customer_address_key primary key (customer_address_id),
    foreign key (customer_id) references customers (customer_id)
);
alter table customer_address
    owner to parcel_user_main;

-- --
create sequence customers_agreement_id_seq;
alter sequence customers_agreement_id_seq owner to u_mpm_main;
create table customers_agreement
(
    customer_agreement_id integer not null      default nextval('customers_agreement_id_seq'::regclass),
    customer_id           integer not null,
    user_access_id        integer not null,
    context               character varying(30) default ''::character varying NOT NULL,
    date_creation           timestamptz           default NOW()::timestamptz,
    date_modification       timestamptz           default NOW()::timestamptz,
    usr_creates_id        integer not null      default 0,
    usr_modifies_id       integer not null      default 0,
    constraint customer_agreement_id_key primary key (customer_agreement_id),
    foreign key (customer_id) references customers (customer_id),
    foreign key (user_access_id) references user_access (user_access_id)
);

alter table customers_agreement
    owner to parcel_user_main;

-- --
create sequence customers_credit_id_seq;
alter sequence customers_credit_id_seq owner to parcel_user_main;
create table customer_credit
(
    customer_credit_id integer not null      default nextval('customers_credit_id_seq'::regclass),
    customer_id        integer not null,
    user_access_id     integer not null,
    context            character varying(30) default ''::character varying NOT NULL,
    status             boolean not null      default false::boolean,
    maximum_quantity   numeric               default 0 not null,
    discount_rate_id   integer not null      default 0,
    date_creation        timestamptz           default NOW()::timestamptz,
    date_modification    timestamptz           default NOW()::timestamptz,
    dt_payment         timestamptz           default NOW()::timestamptz,
    date_cancellation    timestamptz           default NOW()::timestamptz,
    date_activation      timestamptz           default NOW()::timestamptz,
    date_expiration      timestamptz           default NOW()::timestamptz,
    usr_creates_id     integer not null      default 0,
    usr_modifies_id    integer not null      default 0,
    usr_collects_id    integer not null      default 0,
    usr_cancels_id     integer not null      default 0,
    usr_activates_id   integer not null      default 0,
    constraint customer_credit_key primary key (customer_credit_id),
    foreign key (customer_id) references customers (customer_id),
    foreign key (user_access_id) references user_access (user_access_id)
);

alter table customer_credit
    owner to parcel_user_main;

-- --
create sequence license_id_seq;
alter sequence license_id_seq owner to parcel_user_main;
-- TYPE: mercurio/mercury, PRICE: MXN549.00/mo, STARTER
-- TYPE: hierro/iron, PRICE: MXN719.00/mo, BASIC
-- TYPE: plata/silver, PRICE: MXN899.00/mo, STANDARD
-- TYPE: oro/gold, PRICE: MXN999.00/mo, PREMIUM
create table license
(
    license_id           integer     not null default nextval('license_id_seq'::regclass),
    customer_id          integer     not null,
    license_code_id      integer     not null default 0,
    license_price_id     integer     not null default 0,
    license_status       boolean     not null default false,
    license_canceled     boolean     not null default false,
    license_key          uuid        not null,
    month_fees           numeric     not null default 0, -- cuotas mensuales
    description          varchar(50) not null default ''::character varying,
    purchase_date        timestamptz          default NOW()::timestamptz,
    activation_date      timestamptz          default NOW()::timestamptz,
    expiration_date      timestamptz          default NOW()::timestamptz,
    days_valid           integer     not null default 30,
    date_creation          timestamptz          default NOW()::timestamptz,
    date_modification      timestamptz          default NOW()::timestamptz,
    date_cancellation      timestamptz          default NOW()::timestamptz,
    date_activation_change timestamptz          default NOW()::timestamptz,
    usr_creates_id       integer     not null default 0,
    usr_modifies_id      integer     not null default 0,
    usr_activates_id     integer     not null default 0,
    usr_cancels_id       integer     not null default 0,
    constraint license_key primary key (license_id),
    foreign key (customer_id) references customers (customer_id)
);
alter table license
    owner to parcel_user_main;

-- --
create sequence concepts_id_seq;
alter sequence concepts_id_seq owner to parcel_user_main;
create table concepts
(
    root_concept_id integer      not null default 0,
    concept         varchar(100) not null default 0,
    level           smallint     not null default 0,
    concept_id      integer      not null default 0,
    constraint concepts_key primary key (root_concept_id)
);

alter table concepts
    owner to parcel_user_main;

-- --
create sequence branch_offices_id_seq;
alter sequence branch_offices_id_seq owner to parcel_user_main;
create table branch_offices
(
    branch_office_id integer not null default nextval('branch_offices_id_seq'::regclass),
    status           boolean not null default false,
    is_suspended     boolean not null default false,
    tax_residence_id integer          default 0 not null,
    state_id         integer not null,
    name             varchar(40)      default ''::character varying not null,
    abbreviation     varchar(6)       default ''::character varying not null,
    code             integer not null,
    address          varchar(60)      default ''::character varying not null,
    phone            varchar(17)      default ''::character varying not null,
    email            varchar(100)     default ''::character varying not null,
    date_creation      timestamptz      default NOW()::timestamptz,
    date_modification  timestamptz      default NOW()::timestamptz,
    date_cancellation  timestamptz      default NOW()::timestamptz,
    date_activation    timestamptz      default NOW()::timestamptz,
    usr_creates_id   integer not null default 0,
    usr_modifies_id  integer not null default 0,
    usr_cancels_id   integer not null default 0,
    usr_activates_id integer not null default 0,
    constraint branch_office_id_key primary key (branch_office_id)
);

alter table branch_offices
    owner to parcel_user_main;