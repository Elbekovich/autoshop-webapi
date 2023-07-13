CREATE TABLE users
(
    id bigint generated always as identity primary key,
    first_name character varying(50) NOT NULL,
    last_name character varying(50) NOT NULL,
    phone_number character varying(50) NOT NULL,
    phone_number_confirmed boolean NOT NULL,
    passport_seria_number character varying(9) NOT NULL,
    is_male boolean NOT NULL,
    birth_date date NOT NULL,
    country text NOT NULL,
    region text NOT NULL,
    password_hash text NOT NULL,
    salt text NOT NULL,
    created_at timestamp without time zone default now(),
    updated_at timestamp without time zone default now(),
    role text NOT NULL
);
CREATE TABLE category
(
    id bigint generated always as identity primary key,
    name text NOT NULL,
    description text NOT NULL,
    image_path text NOT NULL,
    created_at timestamp without time zone default now(),
    updated_at timestamp without time zone default now()
);
CREATE TABLE cars
(
    id bigint generated always as identity primary key,
    category_id bigint references category(id),
    name text NOT NULL,
    image_path text NOT NULL,
    color text NOT NULL,
    type text NOT NULL,
    transmission_is_automatic boolean NOT NULL,
    made_at date NOT NULL,
    price text NOT NULL,
    description text NOT NULL,
    car_id bigint references cars(id),
    created_at timestamp without time zone default now(),
    updated_at timestamp with time zone default now() 
);
CREATE TABLE marka
(
    id bigint generated always as identity primary key,
    name text NOT NULL,
    description text NOT NULL,
    image_path text NOT NULL,
    created_at timestamp without time zone default now(),
    updated_at timestamp without time zone default now(),
    marka_id bigint references marka(id)
);

CREATE TABLE seller
(
    id bigint generated always as identity primary key,
    seller_id bigint references seller(id),
    first_name character varying(50) NOT NULL,
    last_name character varying(50) NOT NULL,
    birth_date date NOT NULL,
    phone_number text NOT NULL,
    region text NOT NULL,
    created_at timestamp without time zone default now(),
    updated_at timestamp with time zone default now()
);
